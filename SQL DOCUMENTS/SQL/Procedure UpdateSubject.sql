CREATE OR ALTER PROCEDURE UpdateSubject
    @SubjectID INT,
    @Code INT,
    @Title NVARCHAR(50),
    @ProgramName NVARCHAR(50),
    @DepartmentName NVARCHAR(50),
    @LectureUnits INT,
    @LaboratoryUnits INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ProgramID INT;

    -- Subject must exist
    IF NOT EXISTS (SELECT 1 FROM tblSubject WHERE SubjectID = @SubjectID)
        THROW 50010, 'Subject not found.', 1;

    -- Resolve ProgramID and validate Department
    SELECT @ProgramID = p.ProgramID
    FROM tblProgram p
    INNER JOIN tblDepartment d
        ON d.DepartmentID = p.DepartmentID
    WHERE p.ProgramName = @ProgramName
      AND d.DepartmentName = @DepartmentName;

    IF @ProgramID IS NULL
        THROW 50001, 'Program does not exist or does not belong to the selected department.', 1;

    -- Prevent duplicate subject
    IF EXISTS (
        SELECT 1
        FROM tblSubject
        WHERE Code = @Code
          AND ProgramID = @ProgramID
          AND SubjectID <> @SubjectID
    )
        THROW 50002, 'Another subject with the same code already exists for this program.', 1;

    -- Update subject
    UPDATE tblSubject
    SET
        Code = @Code,
        Title = @Title,
        LectureUnits = @LectureUnits,
        LaboratoryUnits = @LaboratoryUnits,
        ProgramID = @ProgramID
    WHERE SubjectID = @SubjectID;
END
GO
