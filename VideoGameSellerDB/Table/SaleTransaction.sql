CREATE TABLE [dbo].[SaleTransaction]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [SaleId] INT NOT NULL, 
    [Type] INT NOT NULL, 
    CONSTRAINT [FK_User_SaleTransaction] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Sale_SaleTransaction] FOREIGN KEY ([SaleId]) REFERENCES [Sale]([Id])
)
