CREATE VIEW [dbo].[MessageView]
	AS SELECT dbo.[User].Id AS [User.Id], dbo.[User].Username AS [User.Username], dbo.[User].Email AS [User.Email], dbo.[User].Grade AS [User.Grade], dbo.[User].CreatedAt AS [User.CreatedAt], dbo.Message.Message, 
    dbo.Message.PublishedAt, dbo.Message.Id
    FROM dbo.Message INNER JOIN
    dbo.[User] ON dbo.Message.UserId = dbo.[User].Id
