CREATE PROCEDURE [dbo].[SP_ConfirmBid]
	@UserId int,
	@SaleId int
AS
BEGIN
	DECLARE @Type int, @ProviderId int, @Price int, @Winner int

	SELECT @Type = [Type], @ProviderId = ProviderId, @Price = Price FROM Sale WHERE Id = @SaleId

	IF @ProviderId = @UserId
		UPDATE Sale SET IsSale = 1 WHERE Id = @SaleId

		SELECT TOP(1) @Winner = Id FROM SaleTransaction WHERE SaleId = @SaleId ORDER BY Id DESC

		EXEC SP_SaleTransaction @SaleId, @UserId, @Price, 2
		EXEC SP_SaleTransaction @SaleId, @Winner, @Price, 1

		RETURN 0
	RETURN -1
END