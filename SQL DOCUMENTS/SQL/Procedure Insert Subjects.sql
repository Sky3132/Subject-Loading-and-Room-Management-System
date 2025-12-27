CREATE OR ALTER PROCEDURE InsertSubjects
    @Code INT,
    @Title NVARCHAR(50),
    @ProgramName NVARCHAR(50),
    @DepartmentName NVARCHAR(50), -- used only for validation
    @LectureUnits INT,
    @LaboratoryUnits INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ProgramID INT;
    DECLARE @DepartmentID INT;

    -- Resolve ProgramID
    SELECT 
        @ProgramID = p.ProgramID,
        @DepartmentID = p.DepartmentID
    FROM tblProgram p
    INNER JOIN tblDepartment d
        ON d.DepartmentID = p.DepartmentID
    WHERE p.ProgramName = @ProgramName
      AND d.DepartmentName = @DepartmentName;

    IF @ProgramID IS NULL
    BEGIN
        THROW 50001, 'Program does not exist or does not belong to the selected department.', 1;
    END

    -- Prevent duplicate subject per program
    IF EXISTS (
        SELECT 1
        FROM tblSubject
        WHERE Code = @Code
          AND ProgramID = @ProgramID
    )
    BEGIN
        THROW 50002, 'Subject already exists for this program.', 1;
    END

    -- Insert subject (ProgramID ONLY)
    INSERT INTO tblSubject
    (
        Code,
        Title,
        LectureUnits,
        LaboratoryUnits,
        ProgramID
    )
    VALUES
    (
        @Code,
        @Title,
        @LectureUnits,
        @LaboratoryUnits,
        @ProgramID
    );
END
GO
