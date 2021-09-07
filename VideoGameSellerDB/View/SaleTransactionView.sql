CREATE VIEW [dbo].[SaleTransactionView]
	AS SELECT dbo.SaleView.[Game.Id] AS [Sale.Game.Id], dbo.SaleView.[Game.Name] AS [Sale.Game.Name], dbo.SaleView.[Game.Description] AS [Sale.Game.Description], dbo.SaleView.[Game.Appearance] AS [Sale.Game.Appearance], 
    dbo.SaleView.[Game.Developer.Id] AS [Sale.Game.Developer.Id], dbo.SaleView.[Game.Developer.Name] AS [Sale.Game.Developer.Name], dbo.SaleView.[Game.Developer.Appearance] AS [Sale.Game.Developer.Appearance], 
    dbo.SaleView.[Game.Developer.Picture.Id] AS [Sale.Game.Developer.Picture.Id], dbo.SaleView.[Game.Developer.Picture.Url] AS [Sale.Game.Developer.Picture.Url], 
    dbo.SaleView.[Game.Developer.Picture.PublishedAt] AS [Sale.Game.Developer.Picture.PublishedAt], dbo.SaleView.[Game.Publisher.Name] AS [Sale.Game.Publisher.Name], 
    dbo.SaleView.[Game.Publisher.Id] AS [Sale.Game.Publisher.Id], dbo.SaleView.[Game.Publisher.Appearance] AS [Sale.Game.Publisher.Appearance], dbo.SaleView.[Game.Publisher.Picture.Id] AS [Sale.Game.Publisher.Picture.Id], 
    dbo.SaleView.[Game.Publisher.Picture.Url] AS [Sale.Game.Publisher.Picture.Url], dbo.SaleView.[Game.Publisher.Picture.PublishedAt] AS [Sale.Game.Publisher.Picture.PublishedAt], 
    dbo.SaleView.[Game.Picture.Url] AS [Sale.Game.Picture.Url], dbo.SaleView.[Game.Picture.PublishedAt] AS [Sale.Game.Picture.PublishedAt], dbo.SaleView.[Game.Picture.Id] AS [Sale.Game.Picture.Id], 
    dbo.SaleView.[Provider.Id] AS [Sale.Provider.Id], dbo.SaleView.[Provider.Email] AS [Sale.Provider.Email], dbo.SaleView.[Provider.Username] AS [Sale.Provider.Username], dbo.SaleView.[Provider.Grade] AS [Sale.Provider.Grade], 
    dbo.SaleView.Title AS [Sale.Title], dbo.SaleView.Type AS [Sale.Type], dbo.SaleView.Id AS [Sale.Id], dbo.SaleView.Price AS [Sale.Price], dbo.SaleView.Description AS [Sale.Description], dbo.SaleView.IsSale AS [Sale.IsSale], 
    dbo.SaleView.PublishedAt AS [Sale.PublishedAt], dbo.SaleTransaction.Price,dbo.SaleView.[Provider.CreatedAt] AS [Sale.Provider.CreatedAt], dbo.SaleTransaction.UserId, dbo.SaleView.[Provider.CreatedAt], dbo.SaleTransaction.Type
    FROM dbo.SaleTransaction INNER JOIN
    dbo.[User] ON dbo.SaleTransaction.UserId = dbo.[User].Id INNER JOIN
    dbo.SaleView ON dbo.SaleTransaction.SaleId = dbo.SaleView.Id