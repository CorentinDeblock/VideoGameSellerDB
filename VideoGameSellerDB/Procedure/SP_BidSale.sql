CREATE PROCEDURE [dbo].[SP_BidSale]
	@UserId int,
	@SaleId int,
	@Price int
AS
BEGIN
	DECLARE @Type int

	SELECT @Type = [Type] FROM Sale WHERE Id = @SaleId

	UPDATE Sale SET Price = @Price WHERE Id = @SaleId

	EXEC SP_SaleTransaction @SaleId, @UserId, @Price, 0
END