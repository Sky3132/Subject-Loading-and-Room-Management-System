CREATE OR ALTER PROCEDURE GetSubjectOffering
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        o.offeringId,
		 s.subjectId,
		 o.Semester,   
        o.SchoolYear,
  
        CAST(s.Code AS VARCHAR(10)) + ' - ' + s.Title AS Subject
    FROM tblsubjectOffering o
    INNER JOIN tblsubject s
        ON o.subjectId = s.subjectId
    ORDER BY o.SchoolYear, o.Semester;
END
GO
