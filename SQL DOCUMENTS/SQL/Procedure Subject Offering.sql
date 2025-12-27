CREATE OR ALTER PROCEDURE SubjectOffering
    @subjectId INT,
    @Semester NVARCHAR(50),
    @SchoolYear NVARCHAR(50)
AS
BEGIN
    INSERT INTO tblsubjectOffering (subjectId, Semester, SchoolYear)
    VALUES (@subjectId, @Semester ,@SchoolYear);
END
GO
