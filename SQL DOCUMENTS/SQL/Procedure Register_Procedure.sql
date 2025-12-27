CREATE or ALTER PROCEDURE Register_Procedure
@Username nvarchar(200),
@Password nvarchar(200)

AS
BEGIN

Insert into Users(Username, Password, Roleid)
Values(@Username, @Password, 2)

Insert into register(Username, Password)
Values(@Username, @Password)

END
GO
