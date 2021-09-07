CREATE PROCEDURE [dbo].[SP_User] (
	@Username nvarchar(50),
	@Email nvarchar(50),
	@Password nvarchar(255),
	@Grade smallint
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @PasswordHash varbinary(Max), @GUID nvarchar(255)
	EXEC SPI_EncryptPassword @Password, @GUID out, @PasswordHash out

	INSERT INTO [dbo].[User](
		Username,
		Email, 
		Password,
		Salt,
		Grade
	) VALUES(
		@Username,
		@Email,
		@PasswordHash,
		@GUID,
		@Grade
	)

	SELECT TOP 1 * FROM [dbo].[User] ORDER BY Id DESC
END
