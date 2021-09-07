CREATE VIEW [dbo].[OpinionMessageView]
	AS SELECT dbo.OpinionView.[User.Username], dbo.OpinionView.[User.Email], dbo.OpinionView.[User.Grade], dbo.OpinionView.[User.Id], dbo.OpinionView.Type, dbo.OpinionView.PublishedAt, dbo.OpinionView.Id, 
    dbo.OpinionMessageRelation.MessageId, dbo.OpinionView.[User.CreatedAt]
    FROM dbo.Message INNER JOIN
    dbo.OpinionMessageRelation ON dbo.Message.Id = dbo.OpinionMessageRelation.MessageId INNER JOIN
    dbo.OpinionView ON dbo.OpinionMessageRelation.OpinionId = dbo.OpinionView.Id