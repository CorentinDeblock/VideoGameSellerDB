CREATE TABLE [dbo].[PictureSaleRelation]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [PictureId] INT NOT NULL, 
    [SaleId] INT NOT NULL, 
    CONSTRAINT [FK_Picture_SalePicture_Relation] FOREIGN KEY ([PictureId]) REFERENCES [Picture]([Id]),
    CONSTRAINT [FK_Sale_SalePicture_Relation] FOREIGN KEY ([SaleId]) REFERENCES [Sale]([Id])
)
