CREATE PROCEDURE [dbo].[SPI_DecryptPassword]
	@GUID nvarchar(MAX),
	@Password nvarchar(MAX),
	@PasswordOut varbinary(MAX) output
AS
BEGIN
	SET @PasswordOut = HASHBYTES('SHA2_512', CONCAT(@GUID,@Password,@GUID))
END
GO
