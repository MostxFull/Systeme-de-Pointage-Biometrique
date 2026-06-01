using Dapper;
using Microsoft.Data.SqlClient;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Data;

namespace HRSchedulingSystem.Services
{
    public class ServiceService
    {
        private readonly string _connectionString;

        public ServiceService()
        {
            _connectionString = new DatabaseHelper().GetConnectionString();
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            const string sql = @"
                SELECT s.*, d.Nom as DepartementNom 
                FROM Service s 
                INNER JOIN Departement d ON s.DepartementId = d.Id 
                ORDER BY s.Nom";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Service>(sql);
        }

        public async Task<Service?> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Service WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Service>(sql, new { Id = id });
        }

        public async Task<Service> CreateAsync(Service service)
        {
            const string sql = @"
                INSERT INTO Service (Nom, DepartementId) 
                VALUES (@Nom, @DepartementId);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = new SqlConnection(_connectionString);
            var id = await connection.QuerySingleAsync<int>(sql, service);
            service.Id = id;
            return service;
        }

        public async Task<Service> UpdateAsync(Service service)
        {
            const string sql = "UPDATE Service SET Nom = @Nom, DepartementId = @DepartementId WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(sql, service);
            return service;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Service WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
        }

        public async Task<IEnumerable<Service>> GetServicesByDepartementAsync(int departementId)
        {
            const string sql = @"
                SELECT s.*, d.Nom as DepartementNom 
                FROM Service s 
                INNER JOIN Departement d ON s.DepartementId = d.Id 
                WHERE s.DepartementId = @DepartementId
                ORDER BY s.Nom";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Service>(sql, new { DepartementId = departementId });
        }
    }
}
