CREATE PROCEDURE [dbo].[SPI_Message]
(
	@UserId int,
	@Message nvarchar(MAX),
	@MessageId int output
)
AS
BEGIN
	INSERT INTO [dbo].[Message](UserId, Message, PublishedAt) 
	VALUES(@UserId, @Message, GETDATE())

	SET @MessageId = SCOPE_IDENTITY()
END
