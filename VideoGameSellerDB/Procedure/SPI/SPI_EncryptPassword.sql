CREATE PROCEDURE [dbo].[SPI_EncryptPassword] 
(
	@Password nvarchar(Max),
	@GUID nvarchar(255) output,
	@PasswordHash varbinary(Max) output
)
AS
BEGIN
	SET @GUID = NEWID()

	SET @PasswordHash = HASHBYTES('SHA2_512', CONCAT(@GUID,@Password,@GUID))
END
GO