CREATE VIEW [dbo].[GameView]
	AS SELECT CompanyView_1.Id AS [Developer.Id], CompanyView_1.Name AS [Developer.Name], CompanyView_1.Appearance AS [Developer.Appearance], CompanyView_1.[Picture.Id] AS [Developer.Picture.Id], 
    CompanyView_1.[Picture.Url] AS [Developer.Picture.Url], CompanyView_1.[Picture.PublishedAt] AS [Developer.Picture.PublishedAt], dbo.CompanyView.Id AS [Publisher.Id], dbo.CompanyView.Name AS [Publisher.Name], 
    dbo.CompanyView.Appearance AS [Publisher.Appearance], dbo.CompanyView.[Picture.Id] AS [Publisher.Picture.Id], dbo.CompanyView.[Picture.Url] AS [Publisher.Picture.Url], 
    dbo.CompanyView.[Picture.PublishedAt] AS [Publisher.Picture.PublishedAt], dbo.Game.Id, dbo.Game.Name, dbo.Game.Description, dbo.Game.Appearance, dbo.Picture.Id AS [Picture.Id], dbo.Picture.Url AS [Picture.Url], 
    dbo.Picture.PublishedAt AS [Picture.PublishedAt]
    FROM dbo.Game RIGHT OUTER JOIN
    dbo.CompanyView ON dbo.Game.PublisherId = dbo.CompanyView.Id INNER JOIN
    dbo.Picture ON dbo.Game.PictureId = dbo.Picture.Id INNER JOIN
    dbo.CompanyView AS CompanyView_1 ON dbo.Game.DeveloperId = CompanyView_1.Id
