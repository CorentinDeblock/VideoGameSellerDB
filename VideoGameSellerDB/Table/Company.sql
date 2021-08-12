CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [PictureId] INT NOT NULL, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Appearance] DATETIME NOT NULL , 
    CONSTRAINT [FK_PictureId_Company] FOREIGN KEY ([PictureId]) REFERENCES [Picture]([Id])
)
