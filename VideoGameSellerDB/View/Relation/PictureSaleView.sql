CREATE VIEW [dbo].[PictureSaleView]
	AS SELECT dbo.Picture.Url, dbo.Picture.PublishedAt, dbo.Picture.Id, dbo.PictureSaleRelation.SaleId
    FROM dbo.Picture INNER JOIN
    dbo.PictureSaleRelation ON dbo.Picture.Id = dbo.PictureSaleRelation.PictureId INNER JOIN
    dbo.Sale ON dbo.PictureSaleRelation.SaleId = dbo.Sale.Id
