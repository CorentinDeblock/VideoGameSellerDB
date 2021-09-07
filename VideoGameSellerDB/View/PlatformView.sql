CREATE VIEW [dbo].[PlatformView]
	AS SELECT dbo.CompanyView.Id AS [Company.Id], dbo.CompanyView.Name AS [Company.Name], dbo.CompanyView.Appearance AS [Company.Appearance], dbo.CompanyView.[Picture.Url] AS [Company.Picture.Url], 
    dbo.CompanyView.[Picture.PublishedAt] AS [Company.Picture.PublishedAt], dbo.CompanyView.[Picture.Id] AS [Company.Picture.Id], dbo.Picture.Id AS [Picture.Id]]], dbo.Picture.Url AS [Picture.Url], 
    dbo.Picture.PublishedAt AS [Picture.PublishedAt], dbo.Platform.Name, dbo.Platform.Description, dbo.Platform.Appearance, dbo.Platform.Id
    FROM dbo.Platform INNER JOIN
    dbo.Picture ON dbo.Platform.PictureId = dbo.Picture.Id INNER JOIN
    dbo.CompanyView ON dbo.Platform.CompanyId = dbo.CompanyView.Id