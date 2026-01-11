ALTER TABLE tblFacultyLoading
DROP CONSTRAINT FK_FacultyLoading_Program;
GO

/* 2. Remove the ProgramID column */
ALTER TABLE tblFacultyLoading
DROP COLUMN ProgramID;
GO