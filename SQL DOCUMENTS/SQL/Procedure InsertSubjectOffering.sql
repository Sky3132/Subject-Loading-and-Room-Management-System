CREATE PROCEDURE InsertSubjectOffering
    @Semester NVARCHAR(50),
    @SchoolYear NVARCHAR(50),
    @SubjectId INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO tblsubjectOffering (Semester, SchoolYear, subjectId)
    VALUES (@Semester, @SchoolYear, @SubjectId);
END;
