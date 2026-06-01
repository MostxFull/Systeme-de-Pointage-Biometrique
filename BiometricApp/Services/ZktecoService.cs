using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HRSchedulingSystem.Models;
using zkemkeeper;

namespace HRSchedulingSystem.Services
{
    public class ZktecoService : IDisposable
    {
        private CZKEM sdk;
        private bool isConnected;
        private int machineNumber;
        private string deviceIP;
        private int devicePort;
        private bool disposed = false;

        public event EventHandler<string> OnError;
        public event EventHandler<string> OnStatusChanged;

        public ZktecoService()
        {
            sdk = new CZKEM();
            isConnected = false;
            machineNumber = 1;
        }

        public bool Connect(string ip, int port, int machineNumber = 1)
        {
            try
            {
                this.deviceIP = ip;
                this.devicePort = port;
                this.machineNumber = machineNumber;

                if (isConnected)
                {
                    Disconnect();
                }

                isConnected = sdk.Connect_Net(ip, port);

                if (isConnected)
                {
                    OnStatusChanged?.Invoke(this, $"Connected to {ip}:{port}");
                    return true;
                }
                else
                {
                    int errorCode = 0;
                    sdk.GetLastError(ref errorCode);
                    OnError?.Invoke(this, $"Failed to connect to {ip}:{port}. Error: {errorCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Connection error: {ex.Message}");
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (isConnected && sdk != null)
                {
                    sdk.Disconnect();
                    isConnected = false;
                    OnStatusChanged?.Invoke(this, $"Disconnected from {deviceIP}:{devicePort}");
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Disconnect error: {ex.Message}");
            }
        }

        public bool IsConnected => isConnected;

        public Dictionary<string, string> GetBiometricIdMap()
        {
            var biometricMap = new Dictionary<string, string>();

            if (!isConnected) return biometricMap;

            try
            {
                sdk.EnableDevice(machineNumber, false);

                string enrollNumber = "";
                string name = "";
                string password = "";
                int privilege = 0;
                bool enabled = false;

                sdk.ReadAllUserID(machineNumber);

                while (sdk.SSR_GetAllUserInfo(machineNumber, out enrollNumber, out name, out password, out privilege, out enabled))
                {
                    if (!string.IsNullOrEmpty(enrollNumber))
                    {
                        biometricMap[enrollNumber] = name ?? enrollNumber; // Use name if available, otherwise enrollNumber
                    }
                }

                sdk.EnableDevice(machineNumber, true);
                OnStatusChanged?.Invoke(this, $"Retrieved {biometricMap.Count} biometric user mappings");
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error reading biometric user IDs: {ex.Message}");
                sdk.EnableDevice(machineNumber, true);
            }

            return biometricMap;
        }

        public List<AttendanceLogEntry> GetAttendanceLogs(Dictionary<string, string> biometricRef, int pointeuseId)
        {
            var logs = new List<AttendanceLogEntry>();

            if (!isConnected) return logs;

            try
            {
                sdk.EnableDevice(machineNumber, false);

                if (sdk.ReadGeneralLogData(machineNumber))
                {
                    string enrollNumber = "";
                    int verifyMode = 0;
                    int inOutMode = 0;
                    int year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0;
                    int workCode = 0;

                    while (sdk.SSR_GetGeneralLogData(machineNumber, out enrollNumber, out verifyMode,
                           out inOutMode, out year, out month, out day, out hour, out minute, out second, ref workCode))
                    {
                        if (!string.IsNullOrEmpty(enrollNumber))
                        {
                            var logEntry = new AttendanceLogEntry
                            {
                                UserId = int.TryParse(enrollNumber, out int userId) ? userId : 0,
                                DateTime = new DateTime(year, month, day, hour, minute, second),
                                VerifyMode = verifyMode,
                                InOutMode = inOutMode,
                                WorkCode = workCode,
                                EmployeeMatricule = enrollNumber, // This is the BiometricId
                                PointeuseId = pointeuseId
                            };

                            logs.Add(logEntry);
                        }
                    }
                }

                sdk.EnableDevice(machineNumber, true);
                OnStatusChanged?.Invoke(this, $"Retrieved {logs.Count} attendance log entries");
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error reading attendance logs: {ex.Message}");
                sdk.EnableDevice(machineNumber, true);
            }

            return logs;
        }

        public bool ClearAttendanceLogs()
        {
            if (!isConnected) return false;

            try
            {
                sdk.EnableDevice(machineNumber, false);
                bool result = sdk.ClearGLog(machineNumber);
                sdk.EnableDevice(machineNumber, true);
                return result;
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, $"Error clearing logs: {ex.Message}");
                sdk.EnableDevice(machineNumber, true);
                return false;
            }
        }

        public string GetDeviceInfo()
        {
            if (!isConnected) return "Device not connected";

            try
            {
                int returnValue = 0;
                if (sdk.GetDeviceInfo(machineNumber, 1, ref returnValue))
                {
                    return $"Device Info: {returnValue}";
                }
                return "Unable to get device info";
            }
            catch (Exception ex)
            {
                return $"Error getting device info: {ex.Message}";
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Disconnect();
                    sdk = null;
                }
                disposed = true;
            }
        }

        
    }
}
