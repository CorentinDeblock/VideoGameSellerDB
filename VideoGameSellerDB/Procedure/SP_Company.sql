CREATE PROCEDURE [dbo].[SP_Company] (
	@Picture nvarchar(max),
	@Name nvarchar(max),
	@Appearance datetime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Picture](Url) VALUES(CONCAT('Image/',@Picture))

    -- Insert statements for procedure here
	INSERT INTO Company(PictureId, Name, Appearance) 
		VALUES(SCOPE_IDENTITY(), @Name, @Appearance)

	SELECT TOP(1) * FROM [dbo].[CompanyView] ORDER BY Id DESC
END