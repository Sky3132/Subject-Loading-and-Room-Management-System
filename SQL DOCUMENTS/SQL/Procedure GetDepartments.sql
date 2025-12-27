CREATE OR ALTER PROCEDURE GetDepartments
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DepartmentID, DepartmentName
    FROM tblDepartment
    ORDER BY DepartmentName;
END
GO
