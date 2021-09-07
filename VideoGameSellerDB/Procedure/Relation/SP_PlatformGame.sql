CREATE PROCEDURE [dbo].[SP_PlatformGame] (
	@PlatformId int,
	@GameId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[PlatformGameRelation] VALUES(@PlatformId, @GameId)

	SELECT TOP 1 * FROM PlatformView ORDER BY Id DESC
END
