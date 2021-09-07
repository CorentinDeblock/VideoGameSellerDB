CREATE TABLE [dbo].[OpinionSaleRelation]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [OpinionId] INT NOT NULL, 
    [SaleId] INT NOT NULL, 
    CONSTRAINT [FK_Opinion_OpinionSale_Relation] FOREIGN KEY ([OpinionId]) REFERENCES [Opinion]([Id]),
    CONSTRAINT [FK_Sale_OpinionSale_Relation] FOREIGN KEY ([SaleId]) REFERENCES [Sale]([Id])
)
