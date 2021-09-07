CREATE PROCEDURE [dbo].[SP_Game] (
	@DeveloperId int,
	@PublisherId int,
	@Picture nvarchar(MAX),
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

	INSERT INTO [dbo].[Game] VALUES(
		@DeveloperId, @PublisherId, @PictureId,
		@Name, @Description, @Appearance
	)

	SELECT TOP 1 * FROM [dbo].[GameView] ORDER BY Id DESC
END