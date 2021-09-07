CREATE PROCEDURE [dbo].[SPI_Opinion]
(
	@UserId int,
	@Type int,
	@OpinionId int output
)
AS
BEGIN
	INSERT INTO [dbo].[Opinion] VALUES (@UserId, @Type, GETDATE())

	SET @OpinionId = SCOPE_IDENTITY()
END
