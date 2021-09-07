CREATE PROCEDURE [dbo].[SP_Sale] (
	@GameId int,
	@ProviderId int,
	@Title nvarchar(50),
	@Description nvarchar(MAX),
	@Price float,
	@Type int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Sale] VALUES(
		@ProviderId, @GameId, @Title, @Type,
		@Price, @Description, 0, GETDATE()
	)

	SELECT TOP(1) * FROM [dbo].[SaleView] ORDER BY Id DESC
END