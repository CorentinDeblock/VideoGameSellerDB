CREATE VIEW [dbo].[UserSaleView]
	AS SELECT dbo.UserSaleRelation.SaleId, dbo.[User].Id, dbo.[User].Username, dbo.[User].Email, dbo.[User].Grade, dbo.[User].CreatedAt
    FROM dbo.[User] INNER JOIN
    dbo.UserSaleRelation ON dbo.[User].Id = dbo.UserSaleRelation.UserId INNER JOIN
    dbo.SaleView ON dbo.UserSaleRelation.SaleId = dbo.SaleView.Id
