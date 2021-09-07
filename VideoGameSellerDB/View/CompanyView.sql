CREATE VIEW [dbo].[CompanyView]
	AS SELECT dbo.Company.Name, dbo.Company.Appearance, dbo.Picture.Url AS [Picture.Url], dbo.Picture.PublishedAt AS [Picture.PublishedAt], dbo.Company.Id, dbo.Picture.Id AS [Picture.Id]
	FROM dbo.Company INNER JOIN
    dbo.Picture ON dbo.Company.PictureId = dbo.Picture.Id
