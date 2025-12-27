CREATE OR ALTER PROCEDURE GetDepartmentByProgram
    @ProgramID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT d.DepartmentID, d.DepartmentName
    FROM tblProgram p
    INNER JOIN tblDepartment d ON d.DepartmentID = p.DepartmentID
    WHERE p.ProgramID = @ProgramID;
END
GO
