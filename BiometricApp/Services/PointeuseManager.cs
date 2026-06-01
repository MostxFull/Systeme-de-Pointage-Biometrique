using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HRSchedulingSystem.Services
{
    public class PointeuseManager : IDisposable
    {
        private readonly List<Pointeuse> connectedDevices;
        private readonly Dictionary<int, ZktecoService> services;
        private readonly Dictionary<string, int> biometricToEmployeeMap; // Changed to string key for BiometricId
        private readonly Dictionary<string, string> unmatchedBiometricIds; // Track unmatched IDs
        private CancellationTokenSource pollingTokenSource;
        private readonly DatabaseHelper databaseHelper;
        private bool isPolling = false;
        private readonly object lockObject = new object();

        public event EventHandler<Pointage> OnAttendanceLogReceived;
        public event EventHandler<DeviceStatus> OnDeviceStatusChanged;
        public event EventHandler<string> OnError;
        public event EventHandler<string> OnLogMessage;

        public PointeuseManager()
        {
            connectedDevices = new List<Pointeuse>();
            services = new Dictionary<int, ZktecoService>();
            biometricToEmployeeMap = new Dictionary<string, int>(); // Changed from employeeMatriculeMap
            unmatchedBiometricIds = new Dictionary<string, string>();
            databaseHelper = new DatabaseHelper();
            LoadBiometricEmployeeMap();
        }

        private void LoadBiometricEmployeeMap()
        {
            try
            {
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                var query = @"SELECT Id, Matricule, BiometricId, Nom, Prenom 
                     FROM Employee 
                     WHERE Statut = 1 AND BiometricId IS NOT NULL AND BiometricId != '' ";

                using var command = new SqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                biometricToEmployeeMap.Clear();
                var duplicateBiometricIds = new List<string>();

                while (reader.Read())
                {
                    var employeeId = reader.GetInt32("Id");
                    var matricule = reader.GetString("Matricule");
                    var biometricId = reader.GetString("BiometricId");
                    var nom = reader.GetString("Nom");
                    var prenom = reader.GetString("Prenom");

                    // Check for duplicate BiometricId
                    if (biometricToEmployeeMap.ContainsKey(biometricId))
                    {
                        duplicateBiometricIds.Add(biometricId);
                        OnError?.Invoke(this, $"Duplicate BiometricId found: {biometricId} for employees {matricule} and existing employee");
                        continue;
                    }

                    biometricToEmployeeMap[biometricId] = employeeId;
                }

                OnLogMessage?.Invoke(this, $"Loaded {biometricToEmployeeMap.Count} biometric-to-employee mappings");

                if (duplicateBiometricIds.Count > 0)
                {
                    OnError?.Invoke(this, $"Found {duplicateBiometricIds.Count} duplicate BiometricId entries. Please ensure uniqueness in Employee table.");
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error loading biometric employee mappings: {ex.Message}");
            }
        }

        public async Task<bool> ConnectDevice(Pointeuse device)
        {
            try
            {
                if (services.ContainsKey(device.Id))
                {
                    services[device.Id].Disconnect();
                    services.Remove(device.Id);
                }

                var service = new ZktecoService();
                service.OnError += (s, e) => OnError?.Invoke(this, $"Device {device.Nom}: {e}");
                service.OnStatusChanged += (s, e) => OnLogMessage?.Invoke(this, $"Device {device.Nom}: {e}");

                bool connected = await Task.Run(() => service.Connect(device.IP, device.Port, device.Numero));

                if (connected)
                {
                    services[device.Id] = service;
                    device.IsConnected = true;
                    device.Status = "Connected";
                    device.LastSync = DateTime.Now;

                    if (!connectedDevices.Any(d => d.Id == device.Id))
                    {
                        connectedDevices.Add(device);
                    }

                    UpdateDeviceInDatabase(device);

                    OnDeviceStatusChanged?.Invoke(this, new DeviceStatus
                    {
                        DeviceId = device.Id,
                        DeviceName = device.Nom,
                        IsConnected = true,
                        Status = "Connected",
                        LastUpdate = DateTime.Now
                    });

                    OnLogMessage?.Invoke(this, $"Successfully connected to device: {device.Nom} ({device.IP}:{device.Port})");
                    return true;
                }
                else
                {
                    device.IsConnected = false;
                    device.Status = "Connection Failed";
                    OnDeviceStatusChanged?.Invoke(this, new DeviceStatus
                    {
                        DeviceId = device.Id,
                        DeviceName = device.Nom,
                        IsConnected = false,
                        Status = "Connection Failed",
                        LastUpdate = DateTime.Now,
                        ErrorMessage = "Unable to establish connection"
                    });
                    return false;
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error connecting to device {device.Nom}: {ex.Message}");
                return false;
            }
        }

        public void DisconnectDevice(int deviceId)
        {
            try
            {
                if (services.ContainsKey(deviceId))
                {
                    services[deviceId].Disconnect();
                    services.Remove(deviceId);
                }

                var device = connectedDevices.FirstOrDefault(d => d.Id == deviceId);
                if (device != null)
                {
                    device.IsConnected = false;
                    device.Status = "Disconnected";
                    connectedDevices.Remove(device);
                    UpdateDeviceInDatabase(device);

                    OnDeviceStatusChanged?.Invoke(this, new DeviceStatus
                    {
                        DeviceId = deviceId,
                        DeviceName = device.Nom,
                        IsConnected = false,
                        Status = "Disconnected",
                        LastUpdate = DateTime.Now
                    });

                    OnLogMessage?.Invoke(this, $"Disconnected from device: {device.Nom}");
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error disconnecting device {deviceId}: {ex.Message}");
            }
        }

        public async Task ConnectAll()
        {
            try
            {
                var devices = await LoadDevicesFromDatabase();
                var connectionTasks = devices.Select(ConnectDevice);
                await Task.WhenAll(connectionTasks);

                OnLogMessage?.Invoke(this, $"Connection attempt completed for {devices.Count} devices");
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error connecting all devices: {ex.Message}");
            }
        }

        public void DisconnectAll()
        {
            try
            {
                var deviceIds = connectedDevices.Select(d => d.Id).ToList();
                foreach (var deviceId in deviceIds)
                {
                    DisconnectDevice(deviceId);
                }

                OnLogMessage?.Invoke(this, "All devices disconnected");
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error disconnecting all devices: {ex.Message}");
            }
        }

        public void StartPolling(int intervalSeconds = 30)
        {
            lock (lockObject)
            {
                if (isPolling) return;

                pollingTokenSource = new CancellationTokenSource();
                isPolling = true;

                Task.Run(async () => await PollingLoop(intervalSeconds, pollingTokenSource.Token));
                OnLogMessage?.Invoke(this, $"Started polling with {intervalSeconds}s interval");
            }
        }

        public void StopPolling()
        {
            lock (lockObject)
            {
                if (!isPolling) return;

                pollingTokenSource?.Cancel();
                isPolling = false;
                OnLogMessage?.Invoke(this, "Stopped polling");
            }
        }

        private async Task PollingLoop(int intervalSeconds, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await PollAllDevices();
                    await Task.Delay(intervalSeconds * 1000, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    OnError?.Invoke(this, $"Error in polling loop: {ex.Message}");
                    await Task.Delay(5000, cancellationToken); // Wait 5 seconds before retrying
                }
            }
        }

        private async Task PollAllDevices()
        {
            var pollingTasks = connectedDevices.Select(device => Task.Run(() => PollDevice(device)));
            await Task.WhenAll(pollingTasks);
        }

        private void PollDevice(Pointeuse device)
        {
            try
            {
                if (!services.ContainsKey(device.Id) || !services[device.Id].IsConnected)
                {
                    // Try to reconnect
                    Task.Run(() => ConnectDevice(device));
                    return;
                }

                var service = services[device.Id];
                var userMap = service.GetBiometricIdMap();
                var logs = service.GetAttendanceLogs(userMap, device.Id);

                int newLogsCount = 0;
                foreach (var log in logs)
                {
                    if (ProcessAttendanceLog(log, device))
                    {
                        newLogsCount++;
                    }
                }

                device.LastSync = DateTime.Now;
                UpdateDeviceInDatabase(device);

                if (newLogsCount > 0)
                {
                    OnLogMessage?.Invoke(this, $"Device {device.Nom}: Processed {newLogsCount} new attendance logs");
                }

                OnDeviceStatusChanged?.Invoke(this, new DeviceStatus
                {
                    DeviceId = device.Id,
                    DeviceName = device.Nom,
                    IsConnected = true,
                    Status = "Active",
                    LastUpdate = DateTime.Now,
                    LogsCollected = newLogsCount
                });
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error polling device {device.Nom}: {ex.Message}");

                OnDeviceStatusChanged?.Invoke(this, new DeviceStatus
                {
                    DeviceId = device.Id,
                    DeviceName = device.Nom,
                    IsConnected = false,
                    Status = "Error",
                    LastUpdate = DateTime.Now,
                    ErrorMessage = ex.Message
                });
            }
        }

        private bool ProcessAttendanceLog(AttendanceLogEntry logEntry, Pointeuse device)
        {
            try
            {
                // Check if log already exists
                if (IsLogAlreadyProcessed(logEntry))
                {
                    return false;
                }

                // Find employee by BiometricId
                var employeeId = GetEmployeeIdByBiometricId(logEntry.EmployeeMatricule);
                if (employeeId == 0)
                {
                    // Track unmatched biometric IDs
                    if (!unmatchedBiometricIds.ContainsKey(logEntry.EmployeeMatricule))
                    {
                        unmatchedBiometricIds[logEntry.EmployeeMatricule] = device.Nom;
                        OnError?.Invoke(this, $"Unmatched BiometricId: {logEntry.EmployeeMatricule} from device {device.Nom}. Please assign this BiometricId to an employee.");
                    }
                    return false;
                }

                // Determine IN/OUT type
                string entryType = DetermineEntryType(employeeId, logEntry.DateTime);

                var pointage = new Pointage
                {
                    DateTime = logEntry.DateTime,
                    Type = entryType,
                    Flag = "Auto",
                    EmployeeId = employeeId,
                    PointeuseId = device.Id,
                    EmployeeMatricule = logEntry.EmployeeMatricule, // This is actually BiometricId
                    DeviceName = device.Nom
                };

                // Insert into database
                if (InsertPointage(pointage))
                {
                    OnAttendanceLogReceived?.Invoke(this, pointage);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error processing attendance log: {ex.Message}");
                return false;
            }
        }

        private bool IsLogAlreadyProcessed(AttendanceLogEntry logEntry)
        {
            try
            {
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                var query = @"SELECT COUNT(*) FROM Pointage p 
                             INNER JOIN Employee e ON p.EmployeeId = e.Id 
                             WHERE e.Matricule = @Matricule 
                             AND p.DateTime = @DateTime 
                             AND p.PointeuseId = @PointeuseId";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Matricule", logEntry.EmployeeMatricule);
                command.Parameters.AddWithValue("@DateTime", logEntry.DateTime);
                command.Parameters.AddWithValue("@PointeuseId", logEntry.PointeuseId);

                return (int)command.ExecuteScalar() > 0;
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error checking duplicate log: {ex.Message}");
                return true; // Assume it exists to prevent duplicates
            }
        }

        private int GetEmployeeIdByBiometricId(string biometricId)
        {
            try
            {
                // First check the in-memory mapping
                if (biometricToEmployeeMap.ContainsKey(biometricId))
                {
                    return biometricToEmployeeMap[biometricId];
                }

                // If not found in memory, check database directly (in case of recent updates)
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                var query = "SELECT Id FROM Employee WHERE BiometricId = @BiometricId AND Statut = 1";
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BiometricId", biometricId);

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    var employeeId = (int)result;
                    // Update in-memory mapping
                    biometricToEmployeeMap[biometricId] = employeeId;
                    return employeeId;
                }

                return 0;
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error getting employee ID by BiometricId: {ex.Message}");
                return 0;
            }
        }

        private int GetEmployeeIdByMatricule(string matricule)
        {
            try
            {
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                var query = "SELECT Id FROM Employee WHERE Matricule = @Matricule AND Statut = 1";
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Matricule", matricule);

                var result = command.ExecuteScalar();
                return result != null ? (int)result : 0;
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error getting employee ID: {ex.Message}");
                return 0;
            }
        }

        private string DetermineEntryType(int employeeId, DateTime logDateTime)
        {
            try
            {
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                // Get the last entry for this employee on the same day
                var query = @"SELECT TOP 1 Type FROM Pointage 
                             WHERE EmployeeId = @EmployeeId 
                             AND CAST(DateTime AS DATE) = CAST(@LogDate AS DATE)
                             AND DateTime < @LogDateTime
                             ORDER BY DateTime DESC";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                command.Parameters.AddWithValue("@LogDate", logDateTime.Date);
                command.Parameters.AddWithValue("@LogDateTime", logDateTime);

                var lastType = command.ExecuteScalar()?.ToString();

                // If no previous entry today, or last was OUT, this should be IN
                return string.IsNullOrEmpty(lastType) || lastType == "OUT" ? "IN" : "OUT";
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error determining entry type: {ex.Message}");
                return "IN"; // Default to IN
            }
        }

        private bool InsertPointage(Pointage pointage)
        {
            try
            {
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                var query = @"INSERT INTO Pointage (DateTime, Type, Flag, EmployeeId, PointeuseId) 
                             VALUES (@DateTime, @Type, @Flag, @EmployeeId, @PointeuseId)";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DateTime", pointage.DateTime);
                command.Parameters.AddWithValue("@Type", pointage.Type);
                command.Parameters.AddWithValue("@Flag", pointage.Flag);
                command.Parameters.AddWithValue("@EmployeeId", pointage.EmployeeId);
                command.Parameters.AddWithValue("@PointeuseId", pointage.PointeuseId);

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error inserting pointage: {ex.Message}");
                return false;
            }
        }

        private async Task<List<Pointeuse>> LoadDevicesFromDatabase()
        {
            var devices = new List<Pointeuse>();

            try
            {
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                await connection.OpenAsync();

                var query = "SELECT Id, Numero, Nom, IP, Port, Password FROM Pointeuse";
                using var command = new SqlCommand(query, connection);
                using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    devices.Add(new Pointeuse
                    {
                        Id = reader.GetInt32("Id"),
                        Numero = reader.GetInt32("Numero"),
                        Nom = reader.GetString("Nom"),
                        IP = reader.GetString("IP"),
                        Port = reader.GetInt32("Port"),
                        Password = reader.IsDBNull("Password") ? "" : reader.GetString("Password")
                    });
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error loading devices from database: {ex.Message}");
            }

            return devices;
        }

        private void UpdateDeviceInDatabase(Pointeuse device)
        {
            try
            {
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                var query = @"UPDATE Pointeuse SET 
                             Numero = @Numero, Nom = @Nom, IP = @IP, Port = @Port, Password = @Password 
                             WHERE Id = @Id";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", device.Id);
                command.Parameters.AddWithValue("@Numero", device.Numero);
                command.Parameters.AddWithValue("@Nom", device.Nom);
                command.Parameters.AddWithValue("@IP", device.IP);
                command.Parameters.AddWithValue("@Port", device.Port);
                command.Parameters.AddWithValue("@Password", device.Password ?? "");

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error updating device in database: {ex.Message}");
            }
        }

        public List<Pointeuse> GetConnectedDevices()
        {
            return new List<Pointeuse>(connectedDevices);
        }

        // Add method to get unmatched biometric IDs for reporting
        public Dictionary<string, string> GetUnmatchedBiometricIds()
        {
            return new Dictionary<string, string>(unmatchedBiometricIds);
        }

        // Add method to refresh biometric mappings
        public void RefreshBiometricMappings()
        {
            LoadBiometricEmployeeMap();
            unmatchedBiometricIds.Clear();
            OnLogMessage?.Invoke(this, "Biometric employee mappings refreshed");
        }

        public bool IsPolling => isPolling;

        public void Dispose()
        {
            StopPolling();
            DisconnectAll();

            foreach (var service in services.Values)
            {
                service?.Dispose();
            }

            services.Clear();
            connectedDevices.Clear();
        }
    }
}
