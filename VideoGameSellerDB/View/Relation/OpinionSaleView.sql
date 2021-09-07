CREATE VIEW [dbo].[OpinionSaleView]
	AS SELECT dbo.OpinionView.[User.Id], dbo.OpinionView.[User.Username], dbo.OpinionView.[User.Email], dbo.OpinionView.[User.Grade], dbo.OpinionView.Id, dbo.OpinionView.Type, dbo.OpinionView.PublishedAt, 
    dbo.OpinionView.[User.CreatedAt], dbo.OpinionSaleRelation.SaleId
    FROM dbo.OpinionSaleRelation INNER JOIN
    dbo.Sale ON dbo.OpinionSaleRelation.SaleId = dbo.Sale.Id INNER JOIN
    dbo.OpinionView ON dbo.OpinionSaleRelation.OpinionId = dbo.OpinionView.Id
