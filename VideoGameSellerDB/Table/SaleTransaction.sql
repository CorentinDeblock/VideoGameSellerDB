CREATE TABLE [dbo].[SaleTransaction]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [UserId] INT NOT NULL,
    [SaleId] INT NOT NULL,
    [Price] FLOAT NOT NULL, 
    [Type] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_User_SaleTransaction] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Sale_SaleTransaction] FOREIGN KEY ([SaleId]) REFERENCES [Sale]([Id])
)
