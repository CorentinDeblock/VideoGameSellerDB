CREATE PROCEDURE [dbo].[SP_BuySale]
	@UserId int,
	@SaleId int
AS
BEGIN
	DECLARE @Type int,@Price int, @ProviderId int

	SELECT @Type = [Type], @Price = Price, @ProviderId = [ProviderId] FROM Sale WHERE Id = @SaleId

	UPDATE Sale SET IsSale = 1 WHERE Id = @SaleId

	EXEC SP_SaleTransaction @SaleId, @UserId, @Price, 1
END