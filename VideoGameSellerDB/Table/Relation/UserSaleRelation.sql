CREATE TABLE [dbo].[UserSaleRelation]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [SaleId] INT NOT NULL, 
    CONSTRAINT [FK_User_UserSale_Relation] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Sale_UserSale_Relation] FOREIGN KEY ([SaleId]) REFERENCES [Sale]([Id])
)
