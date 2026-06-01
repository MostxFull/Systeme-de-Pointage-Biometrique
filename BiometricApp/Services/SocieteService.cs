using Dapper;
using Microsoft.Data.SqlClient;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Data;

namespace HRSchedulingSystem.Services
{
    public class SocieteService
    {
        private readonly string _connectionString;

        public SocieteService()
        {
            _connectionString = new DatabaseHelper().GetConnectionString();
        }

        public async Task<IEnumerable<Societe>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Societe ORDER BY Nom";
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Societe>(sql);
        }

        public async Task<Societe?> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Societe WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Societe>(sql, new { Id = id });
        }

        public async Task<Societe> CreateAsync(Societe societe)
        {
            const string sql = @"
                INSERT INTO Societe (Nom, Adresse, Telephone, Email, RaisonSociale, Logo) 
                VALUES (@Nom, @Adresse, @Telephone, @Email, @RaisonSociale, @Logo);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = new SqlConnection(_connectionString);
            var id = await connection.QuerySingleAsync<int>(sql, societe);
            societe.Id = id;
            return societe;
        }

        public async Task<Societe> UpdateAsync(Societe societe)
        {
            const string sql = @"
                UPDATE Societe 
                SET Nom = @Nom, 
                    Adresse = @Adresse, 
                    Telephone = @Telephone, 
                    Email = @Email, 
                    RaisonSociale = @RaisonSociale, 
                    Logo = @Logo 
                WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(sql, societe);
            return societe;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Societe WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
        }

        public async Task<bool> IsEmailUniqueAsync(string email, int? excludeId = null)
        {
            var sql = "SELECT COUNT(*) FROM Societe WHERE Email = @Email";
            if (excludeId.HasValue)
            {
                sql += " AND Id != @ExcludeId";
            }

            using var connection = new SqlConnection(_connectionString);
            var count = await connection.QuerySingleAsync<int>(sql, new { Email = email, ExcludeId = excludeId });
            return count == 0;
        }
    }
}
