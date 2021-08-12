CREATE TABLE [dbo].[MessageSaleRelation]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [MessageId] INT NOT NULL, 
    [SaleId] INT NOT NULL, 
    CONSTRAINT [FK_Message_MessageSale_Relation] FOREIGN KEY ([MessageId]) REFERENCES [Message]([Id]),
    CONSTRAINT [FK_Sale_MessageSale_Relation] FOREIGN KEY ([SaleId]) REFERENCES [Sale]([Id])
)
