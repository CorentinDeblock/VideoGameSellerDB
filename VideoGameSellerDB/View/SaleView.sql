CREATE VIEW [dbo].[SaleView]
	AS SELECT dbo.GameView.Id AS [Game.Id], dbo.GameView.Name AS [Game.Name], dbo.GameView.Description AS [Game.Description], dbo.GameView.Appearance AS [Game.Appearance], 
    dbo.GameView.[Developer.Id] AS [Game.Developer.Id], dbo.GameView.[Developer.Name] AS [Game.Developer.Name], dbo.GameView.[Developer.Appearance] AS [Game.Developer.Appearance], 
    dbo.GameView.[Developer.Picture.Id] AS [Game.Developer.Picture.Id], dbo.GameView.[Developer.Picture.Url] AS [Game.Developer.Picture.Url], 
    dbo.GameView.[Developer.Picture.PublishedAt] AS [Game.Developer.Picture.PublishedAt], dbo.GameView.[Publisher.Id] AS [Game.Publisher.Id], dbo.GameView.[Publisher.Name] AS [Game.Publisher.Name], 
    dbo.GameView.[Publisher.Appearance] AS [Game.Publisher.Appearance], dbo.GameView.[Publisher.Picture.Id] AS [Game.Publisher.Picture.Id], dbo.GameView.[Publisher.Picture.Url] AS [Game.Publisher.Picture.Url], 
    dbo.GameView.[Publisher.Picture.PublishedAt] AS [Game.Publisher.Picture.PublishedAt], dbo.GameView.[Picture.Url] AS [Game.Picture.Url], dbo.GameView.[Picture.PublishedAt] AS [Game.Picture.PublishedAt], 
    dbo.GameView.[Picture.Id] AS [Game.Picture.Id], dbo.[User].Id AS [Provider.Id], dbo.[User].Email AS [Provider.Email], dbo.[User].Username AS [Provider.Username], dbo.[User].Grade AS [Provider.Grade], 
    dbo.[User].CreatedAt AS [Provider.CreatedAt], dbo.Sale.Title, dbo.Sale.Type, dbo.Sale.Id, dbo.Sale.Price, dbo.Sale.Description, dbo.Sale.IsSale, dbo.Sale.PublishedAt
    FROM dbo.Sale INNER JOIN
    dbo.[User] ON dbo.Sale.ProviderId = dbo.[User].Id INNER JOIN
    dbo.GameView ON dbo.Sale.GameId = dbo.GameView.Id
