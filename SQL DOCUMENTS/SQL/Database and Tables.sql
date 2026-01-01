/* ================================
   DATABASE: Schooldb
   Purpose: Main database for school system
================================ */
IF DB_ID('Schooldb') IS NOT NULL
    DROP DATABASE Schooldb;
GO

CREATE DATABASE Schooldb;
GO

USE Schooldb;
GO

/* ================================
   TABLE: roles
   Purpose: Stores user roles (Admin, Faculty)
================================ */
CREATE TABLE roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,  
    RoleName NVARCHAR(50)                  
);

SET IDENTITY_INSERT dbo.roles ON;

INSERT INTO roles (RoleId, RoleName)
VALUES 
(1, 'Admin'),
(2, 'Faculty_Member');

/* ================================
   TABLE: Users
   Purpose: Stores system users
================================ */
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,   -- Unique user ID
    Username NVARCHAR(50),                  -- Login username
    Password NVARCHAR(200),                 -- User password
    RoleId INT,                             -- User role
    CONSTRAINT fk_roleID 
        FOREIGN KEY (RoleId) REFERENCES roles (RoleId)
);

/* ================================
   TABLE: log_in
   Purpose: Simple login table (temporary / testing)
================================ */
CREATE TABLE log_in (
    Id INT IDENTITY(1,1) PRIMARY KEY,        -- Login ID
    Username NVARCHAR(50) NOT NULL,          -- Username
    Password NVARCHAR(50) NOT NULL           -- Password
);

/* ================================
   Insert default admin user
================================ */
INSERT INTO Users (Username, Password, RoleId)
VALUES ('admin', 'admin123#', 1);

/* ================================
   TABLE: register
   Purpose: Stores newly registered users
================================ */
CREATE TABLE register (
    Id INT IDENTITY(1,1) PRIMARY KEY,        -- Register ID
    Username NVARCHAR(200) NOT NULL,         -- Registered username
    Password NVARCHAR(200) NOT NULL          -- Registered password
);

/* ================================
   TABLE: tblDepartment
   Purpose: College departments
================================ */
CREATE TABLE tblDepartment (
    DepartmentID INT IDENTITY(1,1) PRIMARY KEY, 
    DepartmentName NVARCHAR(50) NOT NULL        
);

INSERT INTO tblDepartment (DepartmentName)
VALUES
('CCE'), ('CBA'), ('CTE'), ('CCJE'),
('CHS'), ('CAS'), ('CHE'), ('CE');

/* ================================
   TABLE: tblProgram
   Purpose: Academic programs per department
================================ */
CREATE TABLE tblProgram (
    ProgramID INT IDENTITY(1,1) PRIMARY KEY, -- Program ID
    ProgramName NVARCHAR(50) NOT NULL,        -- Program name
    DepartmentID INT,                         -- Linked department
    CONSTRAINT fk_departmentID 
        FOREIGN KEY (DepartmentID) 
        REFERENCES tblDepartment (DepartmentID)
);

INSERT INTO tblProgram (ProgramName, DepartmentID)
VALUES
('BSIT', 1), ('BSCS', 1), ('ACT', 1),
('BSBA', 2), ('BSA', 2), ('BSMA', 2),
('BEEd', 3), ('BSEd', 3),
('BS Criminology', 4),
('BSN', 5), ('BS Midwifery', 5),
('AB English', 6), ('AB Political Science', 6), ('BS Psychology', 6),
('BSHM', 7),
('BSCE', 8);

/* ================================
   TABLE: tblsubject
   Purpose: Subjects offered by programs
================================ */
CREATE TABLE tblsubject (
    subjectId INT IDENTITY(1,1) PRIMARY KEY, -- Subject ID
    Code INT NOT NULL,                        -- Subject code
    Title NVARCHAR(50) NOT NULL,              -- Subject title
    LectureUnits INT NOT NULL,                -- Lecture units
    LaboratoryUnits INT NOT NULL,             -- Lab units
    ProgramID INT NOT NULL,                   -- Linked program
    CONSTRAINT FK_tblsubject_Program
        FOREIGN KEY (ProgramID)
        REFERENCES tblProgram (ProgramID)
);

INSERT INTO tblsubject
(Code, Title, LectureUnits, LaboratoryUnits, ProgramID)
VALUES
(105, 'Programming', 3, 1, 4),
(2080, 'IT/13L', 3, 3, 4);

/* ================================
   TABLE: tblsubjectOffering
   Purpose: Subjects per semester & year
================================ */
CREATE TABLE tblsubjectOffering (
    offeringId INT IDENTITY(1,1) PRIMARY KEY, -- Offering ID
    Semester NVARCHAR(50) NOT NULL,            -- Semester
    SchoolYear NVARCHAR(50) NOT NULL,          -- School year
    subjectId INT NOT NULL,                    -- Linked subject
    CONSTRAINT FK_tblsubjectOffering_Subject
        FOREIGN KEY (subjectId)
        REFERENCES tblsubject (subjectId)
);

INSERT INTO tblsubjectOffering
(Semester, SchoolYear, subjectId)
VALUES
('1st Semester', '2024-2025', 1),
('2nd Semester', '2024-2025', 2);

/* ================================
   VERIFY DATA
================================ */
SELECT * FROM roles;
SELECT * FROM Users;
SELECT * FROM log_in;
SELECT * FROM register;
SELECT * FROM tblDepartment;
SELECT * FROM tblProgram;
SELECT * FROM tblsubject;
SELECT * FROM tblsubjectOffering
SELECT * FROM tblFaculty;
SELECT * FROM tblFacultyLoading;
