CREATE PROCEDURE [dbo].[SPI_Picture]
(
	@Url nvarchar(MAX),
	@PictureId int output
)
AS
BEGIN
	INSERT INTO [dbo].[Picture](Url) VALUES(CONCAT('Image/',@Url))

	SET @PictureId = SCOPE_IDENTITY()
END
