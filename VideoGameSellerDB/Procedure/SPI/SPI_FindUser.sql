CREATE PROCEDURE [dbo].[SPI_FindUser]
	@Email nvarchar(MAX),
	@Password nvarchar(MAX)
AS
BEGIN
	DECLARE @Counted int, @Salt nvarchar(255), @PasswordEncrypt varbinary(MAX)

	SELECT TOP(1) @Salt = Salt FROM [dbo].[User] WHERE Email = @Email

	EXEC SPI_DecryptPassword @Salt, @Password, @PasswordEncrypt out

	IF (@Counted > 0)
		RETURN SELECT TOP(1) Id, Email, Username, Grade, CreatedAt FROM [dbo].[User] WHERE Password = @PasswordEncrypt
END