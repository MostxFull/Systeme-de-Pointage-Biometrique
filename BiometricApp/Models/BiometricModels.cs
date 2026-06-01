using System;
using System.ComponentModel.DataAnnotations;

namespace HRSchedulingSystem.Models
{
    public class Pointeuse
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string IP { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Password { get; set; } = string.Empty;
        public bool IsConnected { get; set; }
        public DateTime? LastSync { get; set; }
        public string Status { get; set; } = "Disconnected";
    }

    public class Pointage
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Type { get; set; } = string.Empty; // "IN" or "OUT"
        public string Flag { get; set; } = string.Empty; // "Auto" or "Manuel"
        public int EmployeeId { get; set; }
        public int PointeuseId { get; set; }
        public string EmployeeMatricule { get; set; } = string.Empty;
        public string DeviceName { get; set; } = string.Empty;
    }
    // PointageView class for displaying pointage data
    public class PointageView
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Type { get; set; } = "";
        public string Flag { get; set; } = "";
        public int EmployeeId { get; set; }
        public int PointeuseId { get; set; }
        public string EmployeeName { get; set; } = "";
        public string Matricule { get; set; } = "";
        public string ServiceName { get; set; } = "";
        public string DepartementName { get; set; } = "";
        public string SocieteName { get; set; } = "";
        public string PointeuseName { get; set; } = "";
    }
    public class AttendanceLogEntry
    {
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
        public int VerifyMode { get; set; }
        public int InOutMode { get; set; }
        public int WorkCode { get; set; }
        public string EmployeeMatricule { get; set; } = string.Empty;
        public int PointeuseId { get; set; }
    }

    public class DeviceStatus
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; } = string.Empty;
        public bool IsConnected { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime LastUpdate { get; set; }
        public int LogsCollected { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
