CREATE PROCEDURE [dbo].[SP_PictureSale] (
	@Picture nvarchar(MAX),
	@SaleId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @PictureId int
	EXEC SPI_Picture @Picture, @PictureId out

	INSERT INTO [dbo].[PictureSaleRelation] VALUES (@PictureId, @SaleId)

	SELECT TOP 1 * FROM Picture ORDER BY Id DESC
END