CREATE VIEW [dbo].[PlatformGameView]
	AS SELECT dbo.PlatformView.[Company.Id], dbo.PlatformView.[Company.Name], dbo.PlatformView.[Company.Appearance], dbo.PlatformView.[Company.Picture.Url], dbo.PlatformView.[Company.Picture.PublishedAt], 
    dbo.PlatformView.[Company.Picture.Id], dbo.PlatformView.[Picture.Id]]], dbo.PlatformView.[Picture.Url], dbo.PlatformView.[Picture.PublishedAt], dbo.PlatformView.Name, dbo.PlatformView.Description, 
    dbo.PlatformView.Appearance, dbo.PlatformView.Id, dbo.PlatformGameRelation.GameId
    FROM dbo.Game INNER JOIN
    dbo.PlatformGameRelation ON dbo.Game.Id = dbo.PlatformGameRelation.GameId INNER JOIN
    dbo.PlatformView ON dbo.PlatformGameRelation.PlatformId = dbo.PlatformView.Id