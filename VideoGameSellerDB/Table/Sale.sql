CREATE TABLE [dbo].[Sale]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [ProviderId] INT NULL, 
    [GameId] INT NULL, 
    [Type] INT NOT NULL DEFAULT 0, 
    [Price] FLOAT NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [IsSale] BIT NOT NULL DEFAULT 0, 
    [PublishedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Provider_Sale] FOREIGN KEY ([ProviderId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Game_Sale] FOREIGN KEY ([GameId]) REFERENCES [Game]([Id])
)
