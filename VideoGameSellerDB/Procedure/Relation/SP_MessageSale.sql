CREATE PROCEDURE [dbo].[SP_MessageSale] (
	@Message nvarchar(max),
	@UserId int,
	@SaleId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @MessageId int
	EXEC SPI_Message @UserId, @Message, @MessageId out

	INSERT INTO MessageSaleRelation(MessageId,SaleId) 
		VALUES(@MessageId,@SaleId)

	SELECT TOP 1 * FROM MessageView ORDER BY Id DESC
END