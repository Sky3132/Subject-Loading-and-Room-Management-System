CREATE OR ALTER PROCEDURE DeleteSubject
    @subjectId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 FROM tblsubject WHERE subjectId = @subjectId
    )
    BEGIN
        THROW 50010, 'Subject not found.', 1;
    END

    -- 1️⃣ Delete child records FIRST
    DELETE FROM tblsubjectOffering
    WHERE subjectId = @subjectId;

    -- 2️⃣ Delete parent record
    DELETE FROM tblsubject
    WHERE subjectId = @subjectId;
END
GO
