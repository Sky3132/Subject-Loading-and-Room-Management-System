CREATE OR ALTER PROCEDURE GetCodeandTitle
AS
BEGIN
    SET NOCOUNT ON;

   SELECT
        subjectId,
        CAST(Code AS VARCHAR(10)) + ' - ' + Title AS DisplayText
    FROM tblsubject
    ORDER BY Title;
END;
