CREATE PROCEDURE [dbo].[SP_Platform] (
	@CompanyId int,
	@Picture nvarchar(max),
	@Name nvarchar(MAX),
	@Description nvarchar(MAX),
	@Appearance datetime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @PictureId int
	EXEC SPI_Picture @Picture, @PictureId out

	INSERT INTO [dbo].[Platform] 
		VALUES(@CompanyId, @PictureId, @Name, @Description, @Appearance)

	SELECT TOP(1) * FROM [dbo].[PlatformView] ORDER BY Id DESC
END