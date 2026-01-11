-- Remove it first so we can recreate it cleanly
IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_FacultyLoading_Program')
    ALTER TABLE tblFacultyLoading DROP CONSTRAINT FK_FacultyLoading_Program;
GO

-- Re-add the constraint referencing the correct table 'tblProgram'
ALTER TABLE tblFacultyLoading
ADD CONSTRAINT FK_FacultyLoading_Program
FOREIGN KEY (ProgramID) REFERENCES tblProgram(ProgramID);
GO

-- Ensure data is synced so 'Section' logic works
UPDATE fl
SET fl.ProgramID = p.ProgramID
FROM tblFacultyLoading fl
JOIN tblProgram p ON fl.Section = p.ProgramName;
GO