using Dapper;
using Microsoft.Data.SqlClient;
using HRSchedulingSystem.Models;
using HRSchedulingSystem.Data;

namespace HRSchedulingSystem.Services
{
    public class EmployeeService
    {
        private readonly string _connectionString;

        public EmployeeService()
        {
            _connectionString = new DatabaseHelper().GetConnectionString();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            const string sql = @"
                SELECT e.*, s.Nom as ServiceNom, d.Nom as DepartementNom, so.Nom as SocieteNom
                FROM Employee e
                INNER JOIN Service s ON e.ServiceId = s.Id
                INNER JOIN Departement d ON s.DepartementId = d.Id
                INNER JOIN Societe so ON d.SocieteId = so.Id
                ORDER BY e.Nom, e.Prenom";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Employee>(sql);
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            const string sql = "SELECT * FROM Employee WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            const string sql = @"
                INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche,
                                    Telephone, BiometricId, Statut, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId, Photo)
                VALUES (@Nom, @Prenom, @Matricule, @Email, @CIN, @Genre, @DateNaissance, @DateEmbauche, 
                        @Telephone, @BiometricId, @Statut, @Salaire, @NbHeuretravail, @NbJourtravail, @Poste, @ServiceId, @Photo);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            using var connection = new SqlConnection(_connectionString);
            var id = await connection.QuerySingleAsync<int>(sql, employee);
            employee.Id = id;
            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            const string sql = @"
                UPDATE Employee 
                SET Nom = @Nom, Prenom = @Prenom, Matricule = @Matricule, Email = @Email, CIN = @CIN, 
                    Genre = @Genre, DateNaissance = @DateNaissance, DateEmbauche = @DateEmbauche, 
                    Telephone = @Telephone, BiometricId = @BiometricId, Statut = @Statut, Salaire = @Salaire, 
                    NbHeuretravail = @NbHeuretravail, NbJourtravail = @NbJourtravail, 
                    Poste = @Poste, ServiceId = @ServiceId, Photo = @Photo
                WHERE Id = @Id";

            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(sql, employee);
            return employee;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Employee WHERE Id = @Id";
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteAsync(sql, new { Id = id }) > 0;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByServiceAsync(int serviceId)
        {
            const string sql = @"
                SELECT e.*, s.Nom as ServiceNom, d.Nom as DepartementNom, so.Nom as SocieteNom
                FROM Employee e
                INNER JOIN Service s ON e.ServiceId = s.Id
                INNER JOIN Departement d ON s.DepartementId = d.Id
                INNER JOIN Societe so ON d.SocieteId = so.Id
                WHERE e.ServiceId = @ServiceId AND e.Statut = 1
                ORDER BY e.Nom, e.Prenom";

            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Employee>(sql, new { ServiceId = serviceId });
        }
    }
}
