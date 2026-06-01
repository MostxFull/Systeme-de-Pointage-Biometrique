using Dapper;
using Microsoft.Data.SqlClient;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Data;

namespace HRSchedulingSystem.Services
{
    public class ShiftService
    {
        private readonly string _connectionString;

        public ShiftService()
        {
            _connectionString = new DatabaseHelper().GetConnectionString();
        }

        public async Task<IEnumerable<Shift>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Shift ORDER BY Nom";
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Shift>(sql);
        }

        public async Task<Shift?> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Shift WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Shift>(sql, new { Id = id });
        }

        public async Task<Shift> CreateAsync(Shift shift)
        {
            const string sql = @"
                INSERT INTO Shift (Nom, HeureDebut, HeureFin, Retardautorise, Departautorise)
                VALUES (@Nom, @HeureDebut, @HeureFin, @Retardautorise, @Departautorise);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = new SqlConnection(_connectionString);
            var id = await connection.QuerySingleAsync<int>(sql, shift);
            shift.Id = id;
            return shift;
        }

        public async Task<Shift> UpdateAsync(Shift shift)
        {
            const string sql = @"
                UPDATE Shift 
                SET Nom = @Nom, HeureDebut = @HeureDebut, HeureFin = @HeureFin, 
                    Retardautorise = @Retardautorise, Departautorise = @Departautorise
                WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(sql, shift);
            return shift;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Shift WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
        }
    }
}
