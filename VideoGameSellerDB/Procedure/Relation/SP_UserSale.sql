CREATE PROCEDURE [dbo].[SP_UserSale]
	@UserId int,
	@SaleId int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[UserSaleRelation]
		VALUES (@UserId, @SaleId)

	SELECT TOP 1 * FROM [User] ORDER BY Id DESC
END
