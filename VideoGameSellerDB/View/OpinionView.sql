CREATE VIEW [dbo].[OpinionView]
	AS SELECT dbo.[User].Id AS [User.Id], dbo.[User].Username AS [User.Username], dbo.[User].Email AS [User.Email], dbo.[User].Grade AS [User.Grade], dbo.[User].CreatedAt AS [User.CreatedAt], dbo.Opinion.Id, dbo.Opinion.Type, 
    dbo.Opinion.PublishedAt
    FROM dbo.Opinion INNER JOIN
    dbo.[User] ON dbo.Opinion.UserId = dbo.[User].Id