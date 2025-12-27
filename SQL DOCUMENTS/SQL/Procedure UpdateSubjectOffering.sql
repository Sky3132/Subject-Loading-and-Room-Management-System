CREATE OR ALTER PROCEDURE UpdateSubjectOffering
    @OfferingId INT,
    @SubjectId INT,
    @Semester NVARCHAR(50),
    @SchoolYear NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tblsubjectOffering
    SET
        subjectId = @SubjectId,
        Semester = @Semester,
        SchoolYear = @SchoolYear
    WHERE offeringId = @OfferingId;
END
GO
