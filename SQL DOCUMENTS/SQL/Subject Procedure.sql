CREATE or alter PROCEDURE Faculty_register
@username nvarchar(50),
@password nvarchar(50)
AS
BEGIN
insert into register(username, password)
values (@username, @password);
END
GO