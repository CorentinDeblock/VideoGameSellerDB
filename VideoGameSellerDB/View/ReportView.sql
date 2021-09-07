CREATE VIEW [dbo].[ReportView]
	AS SELECT dbo.SaleView.[Game.Id] AS [Sale.Game.Id], dbo.SaleView.[Game.Name] AS [Sale.Game.Name], dbo.SaleView.[Game.Description] AS [Sale.Game.Description], dbo.SaleView.[Game.Appearance] AS [Sale.Game.Appearance], 
    dbo.SaleView.[Game.Developer.Id] AS [Sale.Game.Developer.Id], dbo.SaleView.[Game.Developer.Name] AS [Sale.Game.Developer.Name], dbo.SaleView.[Game.Developer.Appearance] AS [Sale.Game.Developer.Appearance], 
    dbo.SaleView.[Game.Developer.Picture.Id] AS [Sale.Game.Developer.Picture.Id], dbo.SaleView.[Game.Developer.Picture.Url] AS [Sale.Game.Developer.Picture.Url], 
    dbo.SaleView.[Game.Developer.Picture.PublishedAt] AS [Sale.Game.Developer.Picture.PublishedAt], dbo.SaleView.[Game.Publisher.Name] AS [Sale.Game.Publisher.Name], 
    dbo.SaleView.[Game.Publisher.Id] AS [Sale.Game.Publisher.Id], dbo.SaleView.[Game.Publisher.Appearance] AS [Sale.Game.Publisher.Appearance], dbo.SaleView.[Game.Publisher.Picture.Id] AS [Sale.Game.Publisher.Picture.Id], 
    dbo.SaleView.[Game.Publisher.Picture.Url] AS [Sale.Game.Publisher.Picture.Url], dbo.SaleView.[Game.Publisher.Picture.PublishedAt] AS [Sale.Game.Publisher.Picture.PublishedAt], 
    dbo.SaleView.[Game.Picture.Url] AS [Sale.Game.Picture.Url], dbo.SaleView.[Game.Picture.PublishedAt] AS [Sale.Game.Picture.PublishedAt], dbo.SaleView.[Game.Picture.Id] AS [Sale.Game.Picture.Id], 
    dbo.SaleView.[Provider.Id] AS [Sale.Provider.Id], dbo.SaleView.[Provider.Email] AS [Sale.Provider.Email], dbo.SaleView.[Provider.Username] AS [Sale.Provider.Username], dbo.SaleView.[Provider.Grade] AS [Sale.Provider.Grade], 
    dbo.SaleView.[Provider.CreatedAt] AS [Sale.Porvider.CreatedAt], dbo.SaleView.Title AS [Sale.Title], dbo.SaleView.Type AS [Sale.Type], dbo.SaleView.Price AS [Sale.Price], dbo.SaleView.Description AS [Sale.Description], 
    dbo.SaleView.IsSale AS [Sale.IsSale], dbo.SaleView.PublishedAt AS [Sale.PublishedAt], dbo.[User].Id AS [User.Id], dbo.[User].Username AS [User.Username], dbo.[User].Email AS [User.Email], dbo.[User].Grade AS [User.Grade], 
    dbo.[User].CreatedAt AS [User.CreatedAt], User_1.Id AS [Support.Id], User_1.Username AS [Support.Username], User_1.Email AS [Support.Email], User_1.Grade AS [Support.Grade], User_1.CreatedAt AS [Support.CreatedAt], 
    dbo.Report.Id, dbo.Report.Type, dbo.Report.PublishedAt, dbo.Report.IsTreated, dbo.SaleView.Id AS [Sale.Id]
    FROM dbo.[User] INNER JOIN
    dbo.Report ON dbo.[User].Id = dbo.Report.UserId INNER JOIN
    dbo.[User] AS User_1 ON dbo.Report.SupportId = User_1.Id INNER JOIN
    dbo.SaleView ON dbo.Report.SaleId = dbo.SaleView.Id
