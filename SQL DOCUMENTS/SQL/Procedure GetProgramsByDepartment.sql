CREATE OR ALTER PROCEDURE GetProgramsByDepartment
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ProgramID, ProgramName
    FROM tblProgram
    WHERE DepartmentID = @DepartmentID
    ORDER BY ProgramName;
END
GO