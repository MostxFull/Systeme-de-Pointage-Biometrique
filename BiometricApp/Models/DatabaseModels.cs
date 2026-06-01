namespace HRSchedulingSystem.Models
{
    public class Societe
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? RaisonSociale { get; set; }
        public byte[]? Logo { get; set; }
    }

    public class Departement
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public int SocieteId { get; set; }

        // Navigation properties
        public Societe? Societe { get; set; }
    }

    public class Service
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public int DepartementId { get; set; }

        // Navigation properties
        public Departement? Departement { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Matricule { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? BiometricId { get; set; }
        public string CIN { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; }
        public DateTime DateEmbauche { get; set; }
        public long? Telephone { get; set; }
        public bool Statut { get; set; } = true;
        public double? Salaire { get; set; }
        public int? NbHeuretravail { get; set; }
        public int? NbJourtravail { get; set; }
        public string? Poste { get; set; }
        public int ServiceId { get; set; }
        public byte[]? Photo { get; set; }

        // Navigation properties
        public Service? Service { get; set; }
    }

    public class Shift
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public double Retardautorise { get; set; } = 0;
        public double Departautorise { get; set; } = 0;
    }

    public class Programme
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public DateTime DateDebut { get; set; }
    }

    public class ProgrammeHoraire
    {
        public int Id { get; set; }
        public int ProgrammeId { get; set; }
        public int JourDeSemaine { get; set; } // 0=Sunday, 1=Monday, etc.
        public int ShiftId { get; set; }

        // Navigation properties
        public Programme? Programme { get; set; }
        public Shift? Shift { get; set; }
    }

    public class EmployeeProgramme
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProgrammeId { get; set; }
        public DateTime DateAffectation { get; set; }

        // Navigation properties
        public Employee? Employee { get; set; }
        public Programme? Programme { get; set; }
    }

    // View models for complex queries
    public class EmployeeScheduleView
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string ProgrammeName { get; set; } = string.Empty;
        public int JourDeSemaine { get; set; }
        public string ShiftNom { get; set; } = string.Empty;
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public DateTime DateAffectation { get; set; }
    }

    public class EmployeeAssignmentView
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string ProgrammeName { get; set; } = string.Empty;
        public DateTime DateAffectation { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string DepartementName { get; set; } = string.Empty;
    }

    public class Absence
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string TypeAbsence { get; set; } = string.Empty;
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;

        // Navigation properties
        public Employee? Employee { get; set; }
    }

    // View model for absence display
    public class AbsenceView
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public string DepartementName { get; set; } = string.Empty;
        public string SocieteName { get; set; } = string.Empty;
        public string TypeAbsence { get; set; } = string.Empty;
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int NbJours { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreation { get; set; }
    }
    // Helper class for in-memory schedule management
    public class HoraireTravail
    {
        public DayOfWeek Jour { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public DateTime DateDebut { get; set; }
        public string ShiftName { get; set; } = string.Empty;
    }
}
