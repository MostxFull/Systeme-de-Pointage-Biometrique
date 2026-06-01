using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Services;
using HRSchedulingSystem.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HRSchedulingSystem.Forms
{
    public partial class AttendanceCollectionForm : Form
    {
        private PointeuseManager pointeuseManager;
        private List<Pointage> attendanceLogs;
        private List<DeviceStatus> deviceStatuses;
        private DatabaseHelper databaseHelper;

        public AttendanceCollectionForm()
        {
            InitializeComponent();
            InitializeData();
            SetupEventHandlers();
            CreateDatabaseTables();
        }

        private void InitializeData()
        {
            attendanceLogs = new List<Pointage>();
            deviceStatuses = new List<DeviceStatus>();
            databaseHelper = new DatabaseHelper();

            pointeuseManager = new PointeuseManager();
            pointeuseManager.OnAttendanceLogReceived += OnAttendanceLogReceived;
            pointeuseManager.OnDeviceStatusChanged += OnDeviceStatusChanged;
            pointeuseManager.OnError += OnErrorReceived;
            pointeuseManager.OnLogMessage += OnLogMessageReceived;
        }

        private void SetupEventHandlers()
        {
            this.Load += AttendanceCollectionForm_Load;
            this.FormClosing += AttendanceCollectionForm_FormClosing;
        }

        private void CreateDatabaseTables()
        {
            try
            {
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                // Create Pointeuse table
                var createPointeuseTable = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Pointeuse' AND xtype='U')
                    CREATE TABLE Pointeuse (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        Numero INT NOT NULL,
                        Nom NVARCHAR(100) NOT NULL,
                        IP NVARCHAR(50) NOT NULL,
                        Port INT NOT NULL,
                        Password NVARCHAR(50)
                    )";

                using var command1 = new SqlCommand(createPointeuseTable, connection);
                command1.ExecuteNonQuery();

                // Create Pointage table
                var createPointageTable = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Pointage' AND xtype='U')
                    CREATE TABLE Pointage (
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        DateTime DATETIME NOT NULL,
                        Type NVARCHAR(10) NOT NULL CHECK (Type IN ('IN', 'OUT')),
                        Flag NVARCHAR(10) NOT NULL CHECK (Flag IN ('Auto', 'Manuel')),
                        EmployeeId INT NOT NULL,
                        PointeuseId INT NOT NULL,
                        FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
                        FOREIGN KEY (PointeuseId) REFERENCES Pointeuse(Id)
                    )";

                using var command2 = new SqlCommand(createPointageTable, connection);
                command2.ExecuteNonQuery();

                LogMessage("Tables de base de données créées avec succès");
            }
            catch (Exception ex)
            {
                LogError($"Erreur lors de la création des tables de base de données : {ex.Message}");
            }
        }

        private async void AttendanceCollectionForm_Load(object sender, EventArgs e)
        {
            await RefreshDeviceList();
            RefreshAttendanceLogs();
            UpdateUI();
        }

        private void AttendanceCollectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pointeuseManager?.Dispose();
        }

        private void OnAttendanceLogReceived(object sender, Pointage pointage)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, Pointage>(OnAttendanceLogReceived), sender, pointage);
                return;
            }

            attendanceLogs.Insert(0, pointage);
            if (attendanceLogs.Count > 1000) // Keep only last 1000 logs
            {
                attendanceLogs.RemoveAt(attendanceLogs.Count - 1);
            }

            RefreshAttendanceGrid();
            LogMessage($"Nouvelle présence : {pointage.EmployeeMatricule} - {pointage.Type} à {pointage.DateTime:dd/MM/yyyy HH:mm:ss}");
        }

        private void OnDeviceStatusChanged(object sender, DeviceStatus status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, DeviceStatus>(OnDeviceStatusChanged), sender, status);
                return;
            }

            var existingStatus = deviceStatuses.FirstOrDefault(d => d.DeviceId == status.DeviceId);
            if (existingStatus != null)
            {
                deviceStatuses.Remove(existingStatus);
            }
            deviceStatuses.Add(status);

            RefreshDeviceGrid();
        }

        private void OnErrorReceived(object sender, string error)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, string>(OnErrorReceived), sender, error);
                return;
            }

            LogError(error);
        }

        private void OnLogMessageReceived(object sender, string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, string>(OnLogMessageReceived), sender, message);
                return;
            }

            LogMessage(message);
        }

        private async void btnConnectAll_Click(object sender, EventArgs e)
        {
            try
            {
                btnConnectAll.Enabled = false;
                lblStatus.Text = "Connexion à tous les appareils...";
                lblStatus.ForeColor = Color.Orange;

                await pointeuseManager.ConnectAll();
                await RefreshDeviceList();

                lblStatus.Text = "Tentative de connexion terminée";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                LogError($"Erreur lors de la connexion de tous les appareils : {ex.Message}");
                lblStatus.Text = "Échec de la connexion";
                lblStatus.ForeColor = Color.Red;
            }
            finally
            {
                btnConnectAll.Enabled = true;
            }
        }

        private void btnDisconnectAll_Click(object sender, EventArgs e)
        {
            try
            {
                pointeuseManager.DisconnectAll();
                RefreshDeviceList();
                lblStatus.Text = "Tous les appareils déconnectés";
                lblStatus.ForeColor = Color.Orange;
            }
            catch (Exception ex)
            {
                LogError($"Erreur lors de la déconnexion des appareils : {ex.Message}");
            }
        }

        private void btnStartPolling_Click(object sender, EventArgs e)
        {
            try
            {
                int interval = (int)numPollingInterval.Value;
                pointeuseManager.StartPolling(interval);

                btnStartPolling.Enabled = false;
                btnStopPolling.Enabled = true;
                lblStatus.Text = $"Collecte démarrée (toutes les {interval}s)";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                LogError($"Erreur lors du démarrage de la collecte : {ex.Message}");
            }
        }

        private void btnStopPolling_Click(object sender, EventArgs e)
        {
            try
            {
                pointeuseManager.StopPolling();

                btnStartPolling.Enabled = true;
                btnStopPolling.Enabled = false;
                lblStatus.Text = "Collecte arrêtée";
                lblStatus.ForeColor = Color.Orange;
            }
            catch (Exception ex)
            {
                LogError($"Erreur lors de l'arrêt de la collecte : {ex.Message}");
            }
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            using var addDeviceForm = new AddDeviceForm();
            if (addDeviceForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDeviceList();
            }
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            attendanceLogs.Clear();
            RefreshAttendanceGrid();
            txtErrorLog.Clear();
            LogMessage("Logs effacés");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDeviceList();
            RefreshAttendanceLogs();
        }

        private async Task RefreshDeviceList()
        {
            try
            {
                var devices = await LoadDevicesFromDatabase();
                var connectedDevices = pointeuseManager.GetConnectedDevices();

                dgvDevices.DataSource = null;
                dgvDevices.DataSource = devices.Select(d => new
                {
                    d.Id,
                    d.Nom,
                    d.IP,
                    Status = connectedDevices.Any(cd => cd.Id == d.Id) ? "Connecté" : "Déconnecté",
                    LastSync = connectedDevices.FirstOrDefault(cd => cd.Id == d.Id)?.LastSync?.ToString("dd/MM/yyyy HH:mm:ss") ?? "Jamais"
                }).ToList();

                FormatDeviceGrid();
            }
            catch (Exception ex)
            {
                LogError($"Erreur lors de l'actualisation de la liste des appareils : {ex.Message}");
            }
        }

        private void RefreshAttendanceLogs()
        {
            try
            {
                // Load recent attendance logs from database
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                connection.Open();

                var query = @"
                    SELECT TOP 100 p.Id, p.DateTime, p.Type, p.Flag, 
                           e.Matricule as EmployeeMatricule, 
                           pt.Nom as DeviceName,
                           p.EmployeeId, p.PointeuseId
                    FROM Pointage p
                    INNER JOIN Employee e ON p.EmployeeId = e.Id
                    INNER JOIN Pointeuse pt ON p.PointeuseId = pt.Id
                    ORDER BY p.DateTime DESC";

                using var command = new SqlCommand(query, connection);
                using var reader = command.ExecuteReader();

                attendanceLogs.Clear();
                while (reader.Read())
                {
                    attendanceLogs.Add(new Pointage
                    {
                        Id = reader.GetInt32("Id"),
                        DateTime = reader.GetDateTime("DateTime"),
                        Type = reader.GetString("Type"),
                        Flag = reader.GetString("Flag"),
                        EmployeeId = reader.GetInt32("EmployeeId"),
                        PointeuseId = reader.GetInt32("PointeuseId"),
                        EmployeeMatricule = reader.GetString("EmployeeMatricule"),
                        DeviceName = reader.GetString("DeviceName")
                    });
                }

                RefreshAttendanceGrid();
            }
            catch (Exception ex)
            {
                LogError($"Erreur lors de l'actualisation des logs de présence : {ex.Message}");
            }
        }

        private void RefreshAttendanceGrid()
        {
            dgvAttendance.DataSource = null;
            dgvAttendance.DataSource = attendanceLogs.Select(a => new
            {
                a.Id,
                DateTime = a.DateTime.ToString("dd/MM/yyyy HH:mm:ss"),
                Employee = a.EmployeeMatricule,
                a.Type,
                a.Flag,
                Device = a.DeviceName
            }).ToList();

            FormatAttendanceGrid();
        }

        private void RefreshDeviceGrid()
        {
            // Update device status colors
            foreach (DataGridViewRow row in dgvDevices.Rows)
            {
                if (row.Cells["Status"].Value?.ToString() == "Connecté")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void FormatDeviceGrid()
        {
            if (dgvDevices.Columns.Count > 0)
            {
                dgvDevices.Columns["Id"].Width = 30;
                dgvDevices.Columns["Nom"].Width = 130;
                dgvDevices.Columns["IP"].Width = 110;
                dgvDevices.Columns["Status"].Width = 180;
                dgvDevices.Columns["LastSync"].Width = 100;
            }
        }

        private void FormatAttendanceGrid()
        {
            if (dgvAttendance.Columns.Count > 0)
            {
                dgvAttendance.Columns["Id"].Width = 50;
                dgvAttendance.Columns["DateTime"].Width = 150;
                dgvAttendance.Columns["Employee"].Width = 120;
                dgvAttendance.Columns["Type"].Width = 60;
                dgvAttendance.Columns["Flag"].Width = 60;
                dgvAttendance.Columns["Device"].Width = 150;

                // Color code the Type column
                foreach (DataGridViewRow row in dgvAttendance.Rows)
                {
                    if (row.Cells["Type"].Value?.ToString() == "IN")
                    {
                        row.Cells["Type"].Style.BackColor = Color.LightGreen;
                    }
                    else if (row.Cells["Type"].Value?.ToString() == "OUT")
                    {
                        row.Cells["Type"].Style.BackColor = Color.LightCoral;
                    }
                }
            }
        }

        private async Task<List<Pointeuse>> LoadDevicesFromDatabase()
        {
            var devices = new List<Pointeuse>();

            try
            {
                using var connection = new SqlConnection(databaseHelper.GetConnectionString());
                await connection.OpenAsync();

                var query = "SELECT Id, Numero, Nom, IP, Port, Password FROM Pointeuse ORDER BY Nom";
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
                LogError($"Erreur lors du chargement des appareils : {ex.Message}");
            }

            return devices;
        }

        private void UpdateUI()
        {
            btnStopPolling.Enabled = pointeuseManager.IsPolling;
            btnStartPolling.Enabled = !pointeuseManager.IsPolling;
        }

        private void LogMessage(string message)
        {
            var logEntry = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] {message}";
            txtErrorLog.AppendText(logEntry + Environment.NewLine);
            txtErrorLog.ScrollToCaret();
        }

        private void LogError(string error)
        {
            var logEntry = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] ERREUR : {error}";
            txtErrorLog.AppendText(logEntry + Environment.NewLine);
            txtErrorLog.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var aboutForm = new PointageManuelForm();
            aboutForm.ShowDialog();
        }
    }
}
