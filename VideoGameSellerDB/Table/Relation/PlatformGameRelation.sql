CREATE TABLE [dbo].[PlatformGameRelation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [GameId] INT NOT NULL, 
    [PlatformId] INT NOT NULL, 
    CONSTRAINT [FK_PlatformGameRelation_Game] FOREIGN KEY ([GameId]) REFERENCES [Game]([Id]), 
    CONSTRAINT [FK_PlatformGameRelation_Platform] FOREIGN KEY ([PlatformId]) REFERENCES [Platform]([Id])
)
