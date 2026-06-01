using Dapper;
using Microsoft.Data.SqlClient;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Data;

namespace HRSchedulingSystem.Services
{
    public class DepartementService
    {
        private readonly string _connectionString;

        public DepartementService()
        {
            _connectionString = new DatabaseHelper().GetConnectionString();
        }

        public async Task<IEnumerable<Departement>> GetAllAsync()
        {
            const string sql = @"
                SELECT d.*, s.Nom as SocieteNom 
                FROM Departement d 
                INNER JOIN Societe s ON d.SocieteId = s.Id 
                ORDER BY d.Nom";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Departement>(sql);
        }

        public async Task<Departement?> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Departement WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Departement>(sql, new { Id = id });
        }

        public async Task<Departement> CreateAsync(Departement departement)
        {
            const string sql = @"
                INSERT INTO Departement (Nom, SocieteId) 
                VALUES (@Nom, @SocieteId);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = new SqlConnection(_connectionString);
            var id = await connection.QuerySingleAsync<int>(sql, departement);
            departement.Id = id;
            return departement;
        }

        public async Task<Departement> UpdateAsync(Departement departement)
        {
            const string sql = "UPDATE Departement SET Nom = @Nom, SocieteId = @SocieteId WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(sql, departement);
            return departement;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Departement WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
        }

        public async Task<IEnumerable<Departement>> GetDepartementsBySocieteAsync(int societeId)
        {
            const string sql = @"
                SELECT d.*, s.Nom as SocieteNom 
                FROM Departement d 
                INNER JOIN Societe s ON d.SocieteId = s.Id 
                WHERE d.SocieteId = @SocieteId
                ORDER BY d.Nom";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Departement>(sql, new { SocieteId = societeId });
        }
    }
}
