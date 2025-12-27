CREATE OR ALTER PROCEDURE GetSubjectsWithDepartment
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        s.subjectId,
        s.Code,
        s.Title,
        s.LectureUnits,
        s.LaboratoryUnits,
        p.ProgramID,
        p.ProgramName,
        d.DepartmentID,
        d.DepartmentName
    FROM tblsubject s
    INNER JOIN tblProgram p ON s.ProgramID = p.ProgramID
    INNER JOIN tblDepartment d ON p.DepartmentID = d.DepartmentID
    ORDER BY d.DepartmentName, p.ProgramName, s.Code;
END
GO
