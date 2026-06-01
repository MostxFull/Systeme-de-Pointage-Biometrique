CREATE DATABASE BiometricApp;
USE BiometricApp; 
CREATE TABLE Societe (
     Id INT IDENTITY(1,1) PRIMARY KEY,
     Nom NVARCHAR(100) NOT NULL UNIQUE,
     Adresse NVARCHAR(500),
     Telephone NVARCHAR(20),
     Email NVARCHAR(100),
     RaisonSociale NVARCHAR(200),
     Logo VARBINARY(MAX)
 )
CREATE TABLE Departement (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nom NVARCHAR(100) NOT NULL,
    SocieteId INT NOT NULL,
    FOREIGN KEY (SocieteId) REFERENCES Societe(Id)
)
CREATE TABLE Service (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nom NVARCHAR(100) NOT NULL,
    DepartementId INT NOT NULL,
    FOREIGN KEY (DepartementId) REFERENCES Departement(Id)
)
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
)
CREATE TABLE Shift (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nom NVARCHAR(100) NOT NULL,
    HeureDebut TIME NOT NULL,
    HeureFin TIME NOT NULL,
    Retardautorise FLOAT NOT NULL DEFAULT 0,
    Departautorise FLOAT NOT NULL DEFAULT 0
)
CREATE TABLE Programme (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nom NVARCHAR(100) NOT NULL,
    DateDebut DATE NOT NULL
)
CREATE TABLE ProgrammeHoraire (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProgrammeId INT NOT NULL,
    JourDeSemaine INT NOT NULL,
    ShiftId INT NOT NULL,
    FOREIGN KEY (ProgrammeId) REFERENCES Programme(Id),
    FOREIGN KEY (ShiftId) REFERENCES Shift(Id)
)
CREATE TABLE EmployeeProgramme (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,
    ProgrammeId INT NOT NULL,
    DateAffectation DATE NOT NULL,
    FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
    FOREIGN KEY (ProgrammeId) REFERENCES Programme(Id)
)
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
)
CREATE TABLE Pointeuse (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Numero INT NOT NULL,
    Nom NVARCHAR(100) NOT NULL,
    IP NVARCHAR(50) NOT NULL,
    Port INT NOT NULL,
    Password NVARCHAR(50)
)
CREATE TABLE Pointage (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DateTime DATETIME NOT NULL,
    Type NVARCHAR(10) NOT NULL CHECK (Type IN ('IN', 'OUT')),
    Flag NVARCHAR(10) NOT NULL CHECK (Flag IN ('Auto', 'Manuel')),
    EmployeeId INT NOT NULL,
    PointeuseId INT NOT NULL,
    FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
    FOREIGN KEY (PointeuseId) REFERENCES Pointeuse(Id)
)
