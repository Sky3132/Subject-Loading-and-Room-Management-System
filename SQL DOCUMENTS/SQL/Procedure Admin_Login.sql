CREATE OR ALTER PROCEDURE Admin_Login
    @Username NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if admin user exists with matching credentials
    IF NOT EXISTS (
        SELECT 1
        FROM Users
        WHERE Username = @Username
          AND Password = @Password
          AND Roleid = 1
    )
    BEGIN
        THROW 50010, 'Invalid admin username or password.', 1;
    END

    -- Optional: return admin info on success
    SELECT 
        UserId,
        Username,
        Roleid
    FROM Users
    WHERE Username = @Username
      AND Roleid = 1;
END
GO
