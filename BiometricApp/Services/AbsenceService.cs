using Dapper;
using Microsoft.Data.SqlClient;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Data;

namespace HRSchedulingSystem.Services
{
    public class AbsenceService
    {
        private readonly string _connectionString;

        public AbsenceService()
        {
            _connectionString = new DatabaseHelper().GetConnectionString();
        }

        public async Task<IEnumerable<AbsenceView>> GetAllAsync()
        {
            const string sql = @"
                SELECT 
                    a.Id,
                    CONCAT(e.Nom, ' ', e.Prenom) as EmployeeName,
                    s.Nom as ServiceName,
                    d.Nom as DepartementName,
                    so.Nom as SocieteName,
                    a.TypeAbsence,
                    a.DateDebut,
                    a.DateFin,
                    DATEDIFF(day, a.DateDebut, a.DateFin) + 1 as NbJours,
                    a.Description,
                    a.DateCreation
                FROM Absence a
                INNER JOIN Employee e ON a.EmployeeId = e.Id
                INNER JOIN Service s ON e.ServiceId = s.Id
                INNER JOIN Departement d ON s.DepartementId = d.Id
                INNER JOIN Societe so ON d.SocieteId = so.Id
                ORDER BY a.DateCreation DESC, a.DateDebut DESC";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<AbsenceView>(sql);
        }

        public async Task<IEnumerable<AbsenceView>> GetByEmployeeAsync(int employeeId)
        {
            const string sql = @"
                SELECT 
                    a.Id,
                    CONCAT(e.Nom, ' ', e.Prenom) as EmployeeName,
                    s.Nom as ServiceName,
                    d.Nom as DepartementName,
                    so.Nom as SocieteName,
                    a.TypeAbsence,
                    a.DateDebut,
                    a.DateFin,
                    DATEDIFF(day, a.DateDebut, a.DateFin) + 1 as NbJours,
                    a.Description,
                    a.DateCreation
                FROM Absence a
                INNER JOIN Employee e ON a.EmployeeId = e.Id
                INNER JOIN Service s ON e.ServiceId = s.Id
                INNER JOIN Departement d ON s.DepartementId = d.Id
                INNER JOIN Societe so ON d.SocieteId = so.Id
                WHERE e.Id = @EmployeeId
                ORDER BY a.DateDebut DESC";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<AbsenceView>(sql, new { EmployeeId = employeeId });
        }

        public async Task<IEnumerable<AbsenceView>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            const string sql = @"
                SELECT 
                    a.Id,
                    CONCAT(e.Nom, ' ', e.Prenom) as EmployeeName,
                    s.Nom as ServiceName,
                    d.Nom as DepartementName,
                    so.Nom as SocieteName,
                    a.TypeAbsence,
                    a.DateDebut,
                    a.DateFin,
                    DATEDIFF(day, a.DateDebut, a.DateFin) + 1 as NbJours,
                    a.Description,
                    a.DateCreation
                FROM Absence a
                INNER JOIN Employee e ON a.EmployeeId = e.Id
                INNER JOIN Service s ON e.ServiceId = s.Id
                INNER JOIN Departement d ON s.DepartementId = d.Id
                INNER JOIN Societe so ON d.SocieteId = so.Id
                WHERE a.DateDebut <= @EndDate AND a.DateFin >= @StartDate
                ORDER BY a.DateDebut DESC";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<AbsenceView>(sql, new { StartDate = startDate, EndDate = endDate });
        }

        public async Task<Absence?> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Absence WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Absence>(sql, new { Id = id });
        }

        public async Task<Absence> CreateAsync(Absence absence)
        {
            const string sql = @"
                INSERT INTO Absence (EmployeeId, TypeAbsence, DateDebut, DateFin, Description, DateCreation)
                VALUES (@EmployeeId, @TypeAbsence, @DateDebut, @DateFin, @Description, @DateCreation);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = new SqlConnection(_connectionString);
            var id = await connection.QuerySingleAsync<int>(sql, absence);
            absence.Id = id;
            return absence;
        }

        public async Task<Absence> UpdateAsync(Absence absence)
        {
            const string sql = @"
                UPDATE Absence 
                SET EmployeeId = @EmployeeId, 
                    TypeAbsence = @TypeAbsence, 
                    DateDebut = @DateDebut, 
                    DateFin = @DateFin, 
                    Description = @Description
                WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(sql, absence);
            return absence;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Absence WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesBySocieteAsync(int societeId)
        {
            const string sql = @"
                SELECT e.*, s.Nom as ServiceNom, d.Nom as DepartementNom, so.Nom as SocieteNom
                FROM Employee e
                INNER JOIN Service s ON e.ServiceId = s.Id
                INNER JOIN Departement d ON s.DepartementId = d.Id
                INNER JOIN Societe so ON d.SocieteId = so.Id
                WHERE so.Id = @SocieteId AND e.Statut = 1
                ORDER BY e.Nom, e.Prenom";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Employee>(sql, new { SocieteId = societeId });
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartementAsync(int departementId)
        {
            const string sql = @"
                SELECT e.*, s.Nom as ServiceNom, d.Nom as DepartementNom
                FROM Employee e
                INNER JOIN Service s ON e.ServiceId = s.Id
                INNER JOIN Departement d ON s.DepartementId = d.Id
                WHERE d.Id = @DepartementId AND e.Statut = 1
                ORDER BY e.Nom, e.Prenom";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Employee>(sql, new { DepartementId = departementId });
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByServiceAsync(int serviceId)
        {
            const string sql = @"
                SELECT e.*, s.Nom as ServiceNom
                FROM Employee e
                INNER JOIN Service s ON e.ServiceId = s.Id
                WHERE s.Id = @ServiceId AND e.Statut = 1
                ORDER BY e.Nom, e.Prenom";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Employee>(sql, new { ServiceId = serviceId });
        }
    }
}
