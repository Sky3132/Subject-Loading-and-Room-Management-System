-- 1. Remove the foreign key if it exists under the wrong name
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_FacultyLoading_Program')
    ALTER TABLE tblFacultyLoading DROP CONSTRAINT FK_FacultyLoading_Program;

-- 2. Add the ProgramID column ONLY if it doesn't exist yet
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('tblFacultyLoading') AND name = 'ProgramID')
    ALTER TABLE tblFacultyLoading ADD ProgramID INT;
GO

-- 3. Create the relationship (Ensure it references 'tblProgram', not 'tblPrograms')
ALTER TABLE tblFacultyLoading
ADD CONSTRAINT FK_FacultyLoading_Program
FOREIGN KEY (ProgramID) REFERENCES tblProgram(ProgramID);
GO

-- 4. Sync the data from Section text to the new ID
UPDATE fl
SET fl.ProgramID = p.ProgramID
FROM tblFacultyLoading fl
JOIN tblProgram p ON fl.Section = p.ProgramName;
GO