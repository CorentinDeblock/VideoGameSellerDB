CREATE TABLE [dbo].[Game]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [DeveloperId] INT NOT NULL, 
    [PublisherId] INT NOT NULL, 
    [PictureId] INT NOT NULL, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Appearance] DATETIME NOT NULL, 
    CONSTRAINT [FK_Developer_Game] FOREIGN KEY (DeveloperId) REFERENCES [Company]([Id]), 
    CONSTRAINT [FK_Publisher_Game] FOREIGN KEY ([PublisherId]) REFERENCES [Company]([Id]), 
    CONSTRAINT [FK_Picture_Game] FOREIGN KEY ([PictureId]) REFERENCES [Picture]([Id]) 
)
