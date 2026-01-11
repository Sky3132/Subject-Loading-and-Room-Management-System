ALTER TABLE tblFacultyLoading
ADD CONSTRAINT FK_FacultyLoading_Program 
FOREIGN KEY (ProgramID) REFERENCES tblProgram(ProgramID);
GO

/* 3. Sync the data from your 'Section' column to the new ID column */
UPDATE fl
SET fl.ProgramID = p.ProgramID
FROM tblFacultyLoading fl
JOIN tblProgram p ON fl.Section = p.ProgramName;
GO