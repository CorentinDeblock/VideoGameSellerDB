CREATE PROCEDURE [dbo].[SP_OpinionSale] (
	@SaleId int,
	@UserId int,
	@Type smallint
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @OpinionId int
	EXEC SPI_Opinion @UserId, @Type, @OpinionId out

	INSERT INTO [dbo].[OpinionSaleRelation] 
		VALUES (@OpinionId,@SaleId)

	SELECT TOP 1 * FROM OpinionView ORDER BY Id DESC
END