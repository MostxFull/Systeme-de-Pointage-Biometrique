using Microsoft.Data.SqlClient;

namespace HRSchedulingSystem.Data
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BiometricApp;Integrated Security=true;TrustServerCertificate=true;";
        }

        public void InitializeDatabase()
        {
            //CreateDatabaseIfNotExists();
            //CreateTables();
        }

        private void CreateDatabaseIfNotExists()
        {
            var masterConnectionString = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;TrustServerCertificate=true;";

            using var connection = new SqlConnection(masterConnectionString);
            connection.Open();

            var checkDbQuery = "SELECT COUNT(*) FROM sys.databases WHERE name = 'BiometricApp'";
            using var checkCommand = new SqlCommand(checkDbQuery, connection);
            var dbExists = (int)checkCommand.ExecuteScalar() > 0;

            if (!dbExists)
            {
                var createDbQuery = "CREATE DATABASE BiometricApp";
                using var createCommand = new SqlCommand(createDbQuery, connection);
                createCommand.ExecuteNonQuery();
            }
        }

        private void CreateTables()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            // Create Societe table with new fields
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Societe' AND xtype='U')
                CREATE TABLE Societe (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nom NVARCHAR(100) NOT NULL UNIQUE,
                    Adresse NVARCHAR(500),
                    Telephone NVARCHAR(20),
                    Email NVARCHAR(100),
                    RaisonSociale NVARCHAR(200),
                    Logo VARBINARY(MAX)
                )
                ELSE
                BEGIN
                    -- Add new columns if they don't exist
                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Societe') AND name = 'Adresse')
                        ALTER TABLE Societe ADD Adresse NVARCHAR(500);
                    
                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Societe') AND name = 'Telephone')
                        ALTER TABLE Societe ADD Telephone NVARCHAR(20);
                    
                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Societe') AND name = 'Email')
                        ALTER TABLE Societe ADD Email NVARCHAR(100);
                    
                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Societe') AND name = 'RaisonSociale')
                        ALTER TABLE Societe ADD RaisonSociale NVARCHAR(200);
                    
                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Societe') AND name = 'Logo')
                        ALTER TABLE Societe ADD Logo VARBINARY(MAX);
                END");

            // Create Departement table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Departement' AND xtype='U')
                CREATE TABLE Departement (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nom NVARCHAR(100) NOT NULL,
                    SocieteId INT NOT NULL,
                    FOREIGN KEY (SocieteId) REFERENCES Societe(Id)
                )");

            // Create Service table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Service' AND xtype='U')
                CREATE TABLE Service (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nom NVARCHAR(100) NOT NULL,
                    DepartementId INT NOT NULL,
                    FOREIGN KEY (DepartementId) REFERENCES Departement(Id)
                )");

            // Create Employee table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employee' AND xtype='U')
                CREATE TABLE Employee (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nom NVARCHAR(100) NOT NULL,
                    Prenom NVARCHAR(100) NOT NULL,
                    Matricule NVARCHAR(50) NOT NULL UNIQUE,
                    Email NVARCHAR(100),
                    CIN NVARCHAR(20) NOT NULL UNIQUE,
                    Genre NVARCHAR(10) NOT NULL CHECK (Genre IN ('Homme', 'Femme')),
                    DateNaissance DATE NOT NULL,
                    DateEmbauche DATE NOT NULL,
                    Telephone BIGINT,
                    BiometricId NVARCHAR(50) NULL,
                    Statut BIT NOT NULL DEFAULT 1,
                    Salaire FLOAT,
                    NbHeuretravail INT,
                    NbJourtravail INT,
                    Poste NVARCHAR(100),
                    ServiceId INT NOT NULL,
                    Photo VARBINARY(MAX),
                    FOREIGN KEY (ServiceId) REFERENCES Service(Id)
                )");

            // Create Shift table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Shift' AND xtype='U')
                CREATE TABLE Shift (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nom NVARCHAR(100) NOT NULL,
                    HeureDebut TIME NOT NULL,
                    HeureFin TIME NOT NULL,
                    Retardautorise FLOAT NOT NULL DEFAULT 0,
                    Departautorise FLOAT NOT NULL DEFAULT 0
                )");

            // Create Programme table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Programme' AND xtype='U')
                CREATE TABLE Programme (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nom NVARCHAR(100) NOT NULL,
                    DateDebut DATE NOT NULL
                )");

            // Create ProgrammeHoraire table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ProgrammeHoraire' AND xtype='U')
                CREATE TABLE ProgrammeHoraire (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    ProgrammeId INT NOT NULL,
                    JourDeSemaine INT NOT NULL,
                    ShiftId INT NOT NULL,
                    FOREIGN KEY (ProgrammeId) REFERENCES Programme(Id),
                    FOREIGN KEY (ShiftId) REFERENCES Shift(Id)
                )");

            // Create EmployeeProgramme table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='EmployeeProgramme' AND xtype='U')
                CREATE TABLE EmployeeProgramme (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    EmployeeId INT NOT NULL,
                    ProgrammeId INT NOT NULL,
                    DateAffectation DATE NOT NULL,
                    FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
                    FOREIGN KEY (ProgrammeId) REFERENCES Programme(Id)
                )");

            // Create Absence table
            ExecuteNonQuery(connection, @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Absence' AND xtype='U')
                CREATE TABLE Absence (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    EmployeeId INT NOT NULL,
                    TypeAbsence NVARCHAR(50) NOT NULL,
                    DateDebut DATE NOT NULL,
                    DateFin DATE NOT NULL,
                    Description NVARCHAR(500),
                    DateCreation DATETIME NOT NULL DEFAULT GETDATE(),
                    FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
                    CHECK (DateFin >= DateDebut)
                )");

            // Insert sample data
            //InsertSampleData(connection);
        }

        //private void InsertSampleData(SqlConnection connection)
        //{
        //    // Check if data already exists
        //    var checkQuery = "SELECT COUNT(*) FROM Societe";
        //    using var checkCommand = new SqlCommand(checkQuery, connection);
        //    var count = (int)checkCommand.ExecuteScalar();

        //    if (count > 0) return; // Data already exists

        //    // Insert OMP Company
        //    ExecuteNonQuery(connection, @"
        //        INSERT INTO Societe (Nom, Adresse, Telephone, Email, RaisonSociale) 
        //        VALUES ('OMP (OMINIUM Marocain de Peche)', 'Port de Tan-Tan, Maroc', '+212-522-123456', 'contact@omp.ma', 'OMINIUM Marocain de Peche SARL')");

        //    // Insert Departments
        //    ExecuteNonQuery(connection, "INSERT INTO Departement (Nom, SocieteId) VALUES ('DRH', 1)");
        //    ExecuteNonQuery(connection, "INSERT INTO Departement (Nom, SocieteId) VALUES ('Direction Technique', 1)");
        //    ExecuteNonQuery(connection, "INSERT INTO Departement (Nom, SocieteId) VALUES ('Direction Exploitation', 1)");
        //    ExecuteNonQuery(connection, "INSERT INTO Departement (Nom, SocieteId) VALUES ('DAF', 1)");
        //    ExecuteNonQuery(connection, "INSERT INTO Departement (Nom, SocieteId) VALUES ('Direction Juridique et Assurance', 1)");
        //    ExecuteNonQuery(connection, "INSERT INTO Departement (Nom, SocieteId) VALUES ('Direction d''Achat', 1)");

        //    // Insert Services
        //    // DRH Services
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Service gardinage', 1)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Service hygi�ne et s�curit�', 1)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Service personnel', 1)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Service d�claration sociale', 1)");

        //    // Direction Technique Services
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Chantier naval', 2)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Inspection', 2)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Maintenance Usine', 2)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Magasin inspection', 2)");

        //    // Direction Exploitation Services
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Service P�che', 3)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Armement', 3)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('D�halage', 3)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Service Commercial', 3)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Contr�le de Qualit�', 3)");

        //    // DAF Services
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('D�partement Financier', 4)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Service comptabilit�', 4)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Informatique', 4)");

        //    // Direction Juridique et Assurance Services
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('D�partement Juridique', 5)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Service Assurance', 5)");

        //    // Direction d'Achat Services
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Achat Complexe', 6)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Achat consommable', 6)");
        //    ExecuteNonQuery(connection, "INSERT INTO Service (Nom, DepartementId) VALUES ('Achat Technique', 6)");

        //    // Insert Shifts
        //    ExecuteNonQuery(connection, "INSERT INTO Shift (Nom, HeureDebut, HeureFin, Retardautorise, Departautorise) VALUES ('�quipe Administrative', '08:00', '17:00', 15, 10)");
        //    ExecuteNonQuery(connection, "INSERT INTO Shift (Nom, HeureDebut, HeureFin, Retardautorise, Departautorise) VALUES ('�quipe P�che Matin', '04:00', '12:00', 30, 15)");
        //    ExecuteNonQuery(connection, "INSERT INTO Shift (Nom, HeureDebut, HeureFin, Retardautorise, Departautorise) VALUES ('�quipe Technique', '07:00', '15:00', 20, 15)");
        //    ExecuteNonQuery(connection, "INSERT INTO Shift (Nom, HeureDebut, HeureFin, Retardautorise, Departautorise) VALUES ('�quipe Maintenance', '06:00', '14:00', 20, 15)");
        //    ExecuteNonQuery(connection, "INSERT INTO Shift (Nom, HeureDebut, HeureFin, Retardautorise, Departautorise) VALUES ('�quipe S�curit�', '00:00', '08:00', 15, 10)");
        //    ExecuteNonQuery(connection, "INSERT INTO Shift (Nom, HeureDebut, HeureFin, Retardautorise, Departautorise) VALUES ('�quipe Commercial', '09:00', '18:00', 15, 10)");

        //    // Insert Programmes
        //    ExecuteNonQuery(connection, "INSERT INTO Programme (Nom, DateDebut) VALUES ('Programme Administratif', '2024-01-01')");
        //    ExecuteNonQuery(connection, "INSERT INTO Programme (Nom, DateDebut) VALUES ('Programme P�che Maritime', '2024-01-01')");
        //    ExecuteNonQuery(connection, "INSERT INTO Programme (Nom, DateDebut) VALUES ('Programme Technique', '2024-01-01')");
        //    ExecuteNonQuery(connection, "INSERT INTO Programme (Nom, DateDebut) VALUES ('Programme Commercial', '2024-01-01')");

        //    // Insert Programme Horaires
        //    // Programme Administratif (Monday to Friday, Administrative shift)
        //    for (int day = 1; day <= 5; day++)
        //    {
        //        ExecuteNonQuery(connection, $"INSERT INTO ProgrammeHoraire (ProgrammeId, JourDeSemaine, ShiftId) VALUES (1, {day}, 1)");
        //    }

        //    // Programme P�che Maritime (Monday to Saturday, Fishing shift)
        //    for (int day = 1; day <= 6; day++)
        //    {
        //        ExecuteNonQuery(connection, $"INSERT INTO ProgrammeHoraire (ProgrammeId, JourDeSemaine, ShiftId) VALUES (2, {day}, 2)");
        //    }

        //    // Programme Technique (Monday to Friday, Technical shift)
        //    for (int day = 1; day <= 5; day++)
        //    {
        //        ExecuteNonQuery(connection, $"INSERT INTO ProgrammeHoraire (ProgrammeId, JourDeSemaine, ShiftId) VALUES (3, {day}, 3)");
        //    }

        //    // Programme Commercial (Monday to Saturday, Commercial shift)
        //    for (int day = 1; day <= 6; day++)
        //    {
        //        ExecuteNonQuery(connection, $"INSERT INTO ProgrammeHoraire (ProgrammeId, JourDeSemaine, ShiftId) VALUES (4, {day}, 6)");
        //    }

        //    // Insert Employees with Arabic names
        //    // Service gardinage (Service ID: 1)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Alaoui', 'Mohammed', 'OMP001', 'mohammed.alaoui@omp.ma', 'BE123456', 'Homme', '1985-03-15', '2020-01-15', 212661234567, 4500, 8, 5, 'Jardinier', 1)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Benali', 'Fatima', 'OMP002', 'fatima.benali@omp.ma', 'BE123457', 'Femme', '1990-07-22', '2021-03-10', 212661234568, 4200, 8, 5, 'Jardini�re', 1)");

        //    // Service hygi�ne et s�curit� (Service ID: 2)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Hassani', 'Ahmed', 'OMP003', 'ahmed.hassani@omp.ma', 'BE123458', 'Homme', '1982-11-08', '2019-05-20', 212661234569, 5500, 8, 5, 'Responsable S�curit�', 2)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Idrissi', 'Khadija', 'OMP004', 'khadija.idrissi@omp.ma', 'BE123459', 'Femme', '1988-04-12', '2020-08-15', 212661234570, 5200, 8, 5, 'Agent Hygi�ne', 2)");

        //    // Service personnel (Service ID: 3)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Tazi', 'Omar', 'OMP005', 'omar.tazi@omp.ma', 'BE123460', 'Homme', '1980-09-25', '2018-02-01', 212661234571, 6500, 8, 5, 'Gestionnaire RH', 3)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Amrani', 'Aicha', 'OMP006', 'aicha.amrani@omp.ma', 'BE123461', 'Femme', '1987-12-03', '2019-11-10', 212661234572, 6000, 8, 5, 'Assistant RH', 3)");

        //    // Service d�claration sociale (Service ID: 4)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Berrada', 'Youssef', 'OMP007', 'youssef.berrada@omp.ma', 'BE123462', 'Homme', '1984-06-18', '2020-04-05', 212661234573, 5800, 8, 5, 'D�clarant Social', 4)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Cherkaoui', 'Nadia', 'OMP008', 'nadia.cherkaoui@omp.ma', 'BE123463', 'Femme', '1991-01-30', '2021-07-12', 212661234574, 5500, 8, 5, 'Assistant Social', 4)");

        //    // Chantier naval (Service ID: 5)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Fassi', 'Khalid', 'OMP009', 'khalid.fassi@omp.ma', 'BE123464', 'Homme', '1979-08-14', '2017-03-20', 212661234575, 7000, 8, 5, 'Chef Chantier', 5)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Lahlou', 'Rachid', 'OMP010', 'rachid.lahlou@omp.ma', 'BE123465', 'Homme', '1986-05-07', '2019-09-15', 212661234576, 6200, 8, 5, 'Ouvrier Naval', 5)");

        //    // Inspection (Service ID: 6)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Mansouri', 'Abdelaziz', 'OMP011', 'abdelaziz.mansouri@omp.ma', 'BE123466', 'Homme', '1983-10-11', '2018-12-01', 212661234577, 6800, 8, 5, 'Inspecteur', 6)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Nejjar', 'Samira', 'OMP012', 'samira.nejjar@omp.ma', 'BE123467', 'Femme', '1989-02-28', '2020-06-18', 212661234578, 6300, 8, 5, 'Contr�leur Qualit�', 6)");

        //    // Maintenance Usine (Service ID: 7)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Ouali', 'Mustapha', 'OMP013', 'mustapha.ouali@omp.ma', 'BE123468', 'Homme', '1981-07-05', '2018-04-10', 212661234579, 6500, 8, 5, 'Technicien Maintenance', 7)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Qadiri', 'Hassan', 'OMP014', 'hassan.qadiri@omp.ma', 'BE123469', 'Homme', '1985-12-20', '2019-08-25', 212661234580, 6000, 8, 5, 'M�canicien', 7)");

        //    // Magasin inspection (Service ID: 8)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Rami', 'Abdellah', 'OMP015', 'abdellah.rami@omp.ma', 'BE123470', 'Homme', '1987-04-16', '2020-01-08', 212661234581, 5200, 8, 5, 'Magasinier', 8)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Sabri', 'Latifa', 'OMP016', 'latifa.sabri@omp.ma', 'BE123471', 'Femme', '1992-09-12', '2021-05-20', 212661234582, 4800, 8, 5, 'Gestionnaire Stock', 8)");

        //    // Service P�che (Service ID: 9)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Tahiri', 'Said', 'OMP017', 'said.tahiri@omp.ma', 'BE123472', 'Homme', '1978-11-24', '2016-07-15', 212661234583, 8000, 8, 6, 'Capitaine P�che', 9)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Wahbi', 'Driss', 'OMP018', 'driss.wahbi@omp.ma', 'BE123473', 'Homme', '1984-03-09', '2018-10-12', 212661234584, 7200, 8, 6, 'Marin P�cheur', 9)");

        //    // Armement (Service ID: 10)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Zaki', 'Brahim', 'OMP019', 'brahim.zaki@omp.ma', 'BE123474', 'Homme', '1982-06-27', '2019-02-18', 212661234585, 6800, 8, 5, 'Responsable Armement', 10)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Alami', 'Fouad', 'OMP020', 'fouad.alami@omp.ma', 'BE123475', 'Homme', '1988-01-14', '2020-09-05', 212661234586, 6200, 8, 5, 'Technicien Armement', 10)");

        //    // D�halage (Service ID: 11)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Bennani', 'Karim', 'OMP021', 'karim.bennani@omp.ma', 'BE123476', 'Homme', '1986-08-31', '2019-12-22', 212661234587, 5800, 8, 5, 'Chef D�halage', 11)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Chraibi', 'Youssef', 'OMP022', 'youssef.chraibi@omp.ma', 'BE123477', 'Homme', '1990-05-19', '2021-01-30', 212661234588, 5400, 8, 5, 'Ouvrier D�halage', 11)");

        //    // Service Commercial (Service ID: 12)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Douiri', 'Noureddine', 'OMP023', 'noureddine.douiri@omp.ma', 'BE123478', 'Homme', '1983-10-06', '2018-06-14', 212661234589, 7500, 9, 6, 'Responsable Commercial', 12)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('El Fassi', 'Zineb', 'OMP024', 'zineb.elfassi@omp.ma', 'BE123479', 'Femme', '1989-12-15', '2020-11-08', 212661234590, 6800, 9, 6, 'Commerciale', 12)");

        //    // Contr�le de Qualit� (Service ID: 13)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Ghali', 'Abderrahim', 'OMP025', 'abderrahim.ghali@omp.ma', 'BE123480', 'Homme', '1985-07-23', '2019-04-16', 212661234591, 6500, 8, 5, 'Contr�leur Qualit�', 13)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Hajji', 'Malika', 'OMP026', 'malika.hajji@omp.ma', 'BE123481', 'Femme', '1991-03-02', '2021-08-25', 212661234592, 6000, 8, 5, 'Analyste Qualit�', 13)");

        //    // D�partement Financier (Service ID: 14)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Ibrahimi', 'Mostafa', 'OMP027', 'mostafa.ibrahimi@omp.ma', 'BE123482', 'Homme', '1980-09-17', '2017-11-20', 212661234593, 8500, 8, 5, 'Directeur Financier', 14)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Jamal', 'Leila', 'OMP028', 'leila.jamal@omp.ma', 'BE123483', 'Femme', '1987-04-25', '2020-02-10', 212661234594, 7200, 8, 5, 'Analyste Financier', 14)");

        //    // Service comptabilit� (Service ID: 15)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Kettani', 'Hicham', 'OMP029', 'hicham.kettani@omp.ma', 'BE123484', 'Homme', '1984-11-13', '2019-01-07', 212661234595, 6800, 8, 5, 'Chef Comptable', 15)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Lamrani', 'Rajae', 'OMP030', 'rajae.lamrani@omp.ma', 'BE123485', 'Femme', '1990-06-08', '2021-03-15', 212661234596, 6200, 8, 5, 'Comptable', 15)");

        //    // Informatique (Service ID: 16)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Mernissi', 'Amine', 'OMP031', 'amine.mernissi@omp.ma', 'BE123486', 'Homme', '1988-02-21', '2020-05-12', 212661234597, 7800, 8, 5, 'Responsable IT', 16)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Naciri', 'Soukaina', 'OMP032', 'soukaina.naciri@omp.ma', 'BE123487', 'Femme', '1992-08-04', '2021-09-20', 212661234598, 7000, 8, 5, 'D�veloppeuse', 16)");

        //    // D�partement Juridique (Service ID: 17)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Ouazzani', 'Mehdi', 'OMP033', 'mehdi.ouazzani@omp.ma', 'BE123488', 'Homme', '1981-12-10', '2018-03-05', 212661234599, 9000, 8, 5, 'Conseiller Juridique', 17)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Pacha', 'Amina', 'OMP034', 'amina.pacha@omp.ma', 'BE123489', 'Femme', '1986-05-18', '2019-07-22', 212661234600, 8200, 8, 5, 'Juriste', 17)");

        //    // Service Assurance (Service ID: 18)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Qorchi', 'Tarik', 'OMP035', 'tarik.qorchi@omp.ma', 'BE123490', 'Homme', '1983-09-26', '2018-11-14', 212661234601, 7500, 8, 5, 'Gestionnaire Assurance', 18)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Raissouni', 'Houda', 'OMP036', 'houda.raissouni@omp.ma', 'BE123491', 'Femme', '1989-01-07', '2020-12-03', 212661234602, 7000, 8, 5, 'Courtier Assurance', 18)");

        //    // Achat Complexe (Service ID: 19)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Semlali', 'Jamal', 'OMP037', 'jamal.semlali@omp.ma', 'BE123492', 'Homme', '1982-04-14', '2018-08-28', 212661234603, 7200, 8, 5, 'Acheteur Senior', 19)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Tounsi', 'Karima', 'OMP038', 'karima.tounsi@omp.ma', 'BE123493', 'Femme', '1988-10-29', '2020-04-17', 212661234604, 6800, 8, 5, 'Acheteuse', 19)");

        //    // Achat consommable (Service ID: 20)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Uysal', 'Abdelkader', 'OMP039', 'abdelkader.uysal@omp.ma', 'BE123494', 'Homme', '1985-07-11', '2019-06-09', 212661234605, 6000, 8, 5, 'Acheteur Consommables', 20)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Vidal', 'Nawal', 'OMP040', 'nawal.vidal@omp.ma', 'BE123495', 'Femme', '1991-11-22', '2021-02-14', 212661234606, 5600, 8, 5, 'Gestionnaire Achats', 20)");

        //    // Achat Technique (Service ID: 21)
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Wardi', 'Aziz', 'OMP041', 'aziz.wardi@omp.ma', 'BE123496', 'Homme', '1984-03-16', '2018-12-11', 212661234607, 7000, 8, 5, 'Acheteur Technique', 21)");
        //    ExecuteNonQuery(connection, @"INSERT INTO Employee (Nom, Prenom, Matricule, Email, CIN, Genre, DateNaissance, DateEmbauche, Telephone, Salaire, NbHeuretravail, NbJourtravail, Poste, ServiceId) 
        //VALUES ('Zouiten', 'Siham', 'OMP042', 'siham.zouiten@omp.ma', 'BE123497', 'Femme', '1990-12-05', '2021-04-26', 212661234608, 6500, 8, 5, 'Sp�cialiste Achats', 21)");

        //    // Insert Employee Programme assignments
        //    // Administrative services (DRH, DAF, Juridique) - Programme Administratif
        //    for (int empId = 1; empId <= 8; empId++) // DRH employees
        //    {
        //        ExecuteNonQuery(connection, $"INSERT INTO EmployeeProgramme (EmployeeId, ProgrammeId, DateAffectation) VALUES ({empId}, 1, '2024-01-01')");
        //    }
        //    for (int empId = 27; empId <= 32; empId++) // DAF employees
        //    {
        //        ExecuteNonQuery(connection, $"INSERT INTO EmployeeProgramme (EmployeeId, ProgrammeId, DateAffectation) VALUES ({empId}, 1, '2024-01-01')");
        //    }
        //    for (int empId = 33; empId <= 36; empId++) // Juridique employees
        //    {
        //        ExecuteNonQuery(connection, $"INSERT INTO EmployeeProgramme (EmployeeId, ProgrammeId, DateAffectation) VALUES ({empId}, 1, '2024-01-01')");
        //    }

        //    // Technical services - Programme Technique
        //    for (int empId = 9; empId <= 16; empId++) // Direction Technique employees
        //    {
        //        ExecuteNonQuery(connection, $"INSERT INTO EmployeeProgramme (EmployeeId, ProgrammeId, DateAffectation) VALUES ({empId}, 3, '2024-01-01')");
        //    }

        //    // Fishing services - Programme P�che Maritime
        //    ExecuteNonQuery(connection, "INSERT INTO EmployeeProgramme (EmployeeId, ProgrammeId, DateAffectation) VALUES (17, 2, '2024-01-01')"); // Service P�che
        //    ExecuteNonQuery(connection, "INSERT INTO EmployeeProgramme (EmployeeId, ProgrammeId, DateAffectation) VALUES (18, 2, '2024-01-01')");

        //    // Commercial and other exploitation services - Programme Commercial
        //    for (int empId = 19; empId <= 26; empId++) // Other Direction Exploitation employees
        //    {
        //        ExecuteNonQuery(connection, $"INSERT INTO EmployeeProgramme (EmployeeId, ProgrammeId, DateAffectation) VALUES ({empId}, 4, '2024-01-01')");
        //    }

        //    // Purchasing services - Programme Administratif
        //    for (int empId = 37; empId <= 42; empId++) // Direction d'Achat employees
        //    {
        //        ExecuteNonQuery(connection, $"INSERT INTO EmployeeProgramme (EmployeeId, ProgrammeId, DateAffectation) VALUES ({empId}, 1, '2024-01-01')");
        //    }
        //}

        private void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using var command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public string GetConnectionString() => _connectionString;
    }
}
