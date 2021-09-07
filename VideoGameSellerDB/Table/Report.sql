CREATE TABLE [dbo].[Report]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [SupportId] INT NOT NULL, 
    [SaleId] INT NOT NULL, 
    [Type] INT NOT NULL , 
    [PublishedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    [IsTreated] BIT NOT NULL DEFAULT 0 , 
    CONSTRAINT [FK_User_Report] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Support_Report] FOREIGN KEY ([SupportId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_Sale_Report] FOREIGN KEY ([SaleId]) REFERENCES [Sale]([Id])
)
