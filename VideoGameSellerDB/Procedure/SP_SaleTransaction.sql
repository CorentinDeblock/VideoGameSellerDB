CREATE PROCEDURE [dbo].[SP_SaleTransaction]
	@SaleId int,
	@UserId int,
	@Money float,
	@Type int
AS
BEGIN
	INSERT INTO [dbo].[SaleTransaction]
		VALUES (@UserId, @SaleId, @Money, @Type)
END