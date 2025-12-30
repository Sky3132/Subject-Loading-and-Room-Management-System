/* ================================
   TABLE: tblFaculty
   Purpose: Stores instructor details (Designation removed)
================================ */
CREATE TABLE tblFaculty (
    FacultyID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DepartmentID INT, 
    ContactNo NVARCHAR(15),
    CONSTRAINT FK_Faculty_Department 
        FOREIGN KEY (DepartmentID) REFERENCES tblDepartment(DepartmentID)
);

/* ================================
   TABLE: tblRooms (REQUIRED for Monitoring)
================================ */
CREATE TABLE tblRooms (
    RoomID INT IDENTITY(1,1) PRIMARY KEY,
    RoomName NVARCHAR(50) NOT NULL,
    RoomType NVARCHAR(50) -- e.g., 'Laboratory' or 'Lecture'
);

/* ================================
   TABLE: tblFacultyLoading
   Purpose: Bridge table linking Faculty to a specific Subject Offering
================================ */
CREATE TABLE tblFacultyLoading (
    LoadID INT IDENTITY(1,1) PRIMARY KEY,
    FacultyID INT NOT NULL,
    offeringId INT NOT NULL, -- Correctly references the offering instance
    Section NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_Load_Faculty FOREIGN KEY (FacultyID) 
        REFERENCES tblFaculty(FacultyID),
    CONSTRAINT FK_Load_Offering FOREIGN KEY (offeringId) 
        REFERENCES tblsubjectOffering(offeringId)
);

/* ================================
   TABLE: tblSchedule (REQUIRED for Conflict Detection)
================================ */
CREATE TABLE tblSchedule (
    ScheduleID INT IDENTITY(1,1) PRIMARY KEY,
    LoadID INT NOT NULL, -- Links to the Faculty Assignment
    RoomID INT NOT NULL, -- Links to the Room
    DayOfWeek NVARCHAR(20) NOT NULL, -- e.g., 'Monday'
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    CONSTRAINT FK_Sched_Load FOREIGN KEY (LoadID) REFERENCES tblFacultyLoading(LoadID),
    CONSTRAINT FK_Sched_Room FOREIGN KEY (RoomID) REFERENCES tblRooms(RoomID)
);