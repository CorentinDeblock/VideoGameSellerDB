CREATE PROCEDURE [dbo].[SP_Report] (
	@UserId int,
	@SaleId int,
	@Message nvarchar(MAX),
	@Type int
)
AS
	DECLARE @MessageId int
	DECLARE @SupportId int

	INSERT INTO [dbo].[Message](UserId, Message, PublishedAt) 
		VALUES(@UserId, @Message, GETDATE())

	SET @MessageId = SCOPE_IDENTITY()

	SELECT TOP(1) @SupportId = Id FROM [dbo].[User] WHERE [Grade] = 3 ORDER BY RAND()

	INSERT INTO [dbo].[Report] VALUES (@UserId, @SupportId, @SaleId, @Type, GETDATE(), 0)

	INSERT INTO MessageReportRelation VALUES(SCOPE_IDENTITY(), @MessageId)
RETURN 0
