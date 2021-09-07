CREATE VIEW [dbo].[MessageSaleView]
	AS SELECT dbo.MessageView.[User.Id], dbo.MessageView.[User.Username], dbo.MessageView.[User.Email], dbo.MessageView.[User.Grade], dbo.MessageView.Message, dbo.MessageView.Id, dbo.MessageView.PublishedAt, 
    dbo.MessageSaleRelation.SaleId, dbo.MessageView.[User.CreatedAt]
    FROM dbo.MessageSaleRelation INNER JOIN
    dbo.Sale ON dbo.MessageSaleRelation.SaleId = dbo.Sale.Id INNER JOIN
    dbo.MessageView ON dbo.MessageSaleRelation.MessageId = dbo.MessageView.Id
