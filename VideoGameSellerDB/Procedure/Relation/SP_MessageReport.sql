CREATE PROCEDURE [dbo].[SP_MessageReport] (
	@ReportId int,
	@UserId int,
	@Message nvarchar(MAX)
)
AS
	SET NOCOUNT ON;

	DECLARE @MessageId int
	EXEC SPI_Message @UserId, @Message, @MessageId out

	INSERT INTO MessageReportRelation VALUES(@ReportId, @MessageId)

	SELECT TOP 1 * FROM MessageView ORDER BY Id DESC
RETURN 0
