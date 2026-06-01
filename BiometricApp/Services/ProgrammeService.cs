using Dapper;
using Microsoft.Data.SqlClient;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Data;

namespace HRSchedulingSystem.Services
{
    public class ProgrammeService
    {
        private readonly string _connectionString;

        public ProgrammeService()
        {
            _connectionString = new DatabaseHelper().GetConnectionString();
        }

        public async Task<IEnumerable<Programme>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Programme ORDER BY Nom";
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Programme>(sql);
        }

        public async Task<Programme?> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Programme WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Programme>(sql, new { Id = id });
        }

        public async Task<Programme> CreateAsync(Programme programme)
        {
            const string sql = @"
                INSERT INTO Programme (Nom, DateDebut) 
                VALUES (@Nom, @DateDebut);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = new SqlConnection(_connectionString);
            var id = await connection.QuerySingleAsync<int>(sql, programme);
            programme.Id = id;
            return programme;
        }

        public async Task<Programme> UpdateAsync(Programme programme)
        {
            const string sql = "UPDATE Programme SET Nom = @Nom, DateDebut = @DateDebut WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(sql, programme);
            return programme;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Programme WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
        }

        public async Task<IEnumerable<ProgrammeHoraire>> GetProgrammeHorairesAsync(int programmeId)
        {
            const string sql = @"
                SELECT ph.*, s.Nom as ShiftNom, s.HeureDebut, s.HeureFin
                FROM ProgrammeHoraire ph
                INNER JOIN Shift s ON ph.ShiftId = s.Id
                WHERE ph.ProgrammeId = @ProgrammeId
                ORDER BY ph.JourDeSemaine";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<ProgrammeHoraire>(sql, new { ProgrammeId = programmeId });
        }

        public async Task AddShiftToProgrammeAsync(int programmeId, int jourDeSemaine, int shiftId)
        {
            const string sql = @"
                INSERT INTO ProgrammeHoraire (ProgrammeId, JourDeSemaine, ShiftId)
                VALUES (@ProgrammeId, @JourDeSemaine, @ShiftId)";

            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(sql, new { ProgrammeId = programmeId, JourDeSemaine = jourDeSemaine, ShiftId = shiftId });
        }

        public async Task RemoveShiftFromProgrammeAsync(int horaireId)
        {
            const string sql = "DELETE FROM ProgrammeHoraire WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(sql, new { Id = horaireId });
        }

        public async Task AssignToEmployeeAsync(int employeeId, int programmeId, DateTime dateAffectation)
        {
            const string sql = @"
                INSERT INTO EmployeeProgramme (EmployeeId, ProgrammeId, DateAffectation)
                VALUES (@EmployeeId, @ProgrammeId, @DateAffectation)";

            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(sql, new { EmployeeId = employeeId, ProgrammeId = programmeId, DateAffectation = dateAffectation });
        }

        public async Task<IEnumerable<EmployeeAssignmentView>> GetEmployeeAssignmentsAsync()
        {
            const string sql = @"
                SELECT 
                    CONCAT(e.Nom, ' ', e.Prenom) as EmployeeName,
                    p.Nom as ProgrammeName,
                    ep.DateAffectation,
                    s.Nom as ServiceName,
                    d.Nom as DepartementName
                FROM EmployeeProgramme ep
                INNER JOIN Employee e ON ep.EmployeeId = e.Id
                INNER JOIN Programme p ON ep.ProgrammeId = p.Id
                INNER JOIN Service s ON e.ServiceId = s.Id
                INNER JOIN Departement d ON s.DepartementId = d.Id
                ORDER BY ep.DateAffectation DESC";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<EmployeeAssignmentView>(sql);
        }

        public async Task<IEnumerable<EmployeeScheduleView>> GetEmployeeWeeklyScheduleAsync(int employeeId, DateTime weekStart)
        {
            const string sql = @"
                SELECT 
                    CONCAT(e.Nom, ' ', e.Prenom) as EmployeeName,
                    p.Nom as ProgrammeName,
                    ph.JourDeSemaine,
                    s.Nom as ShiftNom,
                    s.HeureDebut,
                    s.HeureFin,
                    ep.DateAffectation
                FROM EmployeeProgramme ep
                INNER JOIN Employee e ON ep.EmployeeId = e.Id
                INNER JOIN Programme p ON ep.ProgrammeId = p.Id
                INNER JOIN ProgrammeHoraire ph ON p.Id = ph.ProgrammeId
                INNER JOIN Shift s ON ph.ShiftId = s.Id
                WHERE e.Id = @EmployeeId 
                AND ep.DateAffectation <= @WeekStart
                ORDER BY ph.JourDeSemaine";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<EmployeeScheduleView>(sql, new { EmployeeId = employeeId, WeekStart = weekStart });
        }
    }
}
