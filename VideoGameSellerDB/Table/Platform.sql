CREATE TABLE [dbo].[Platform]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [CompanyId] INT NOT NULL, 
    [PictureId] INT NOT NULL, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Appearance] DATE NOT NULL , 
    CONSTRAINT [FK_Company_Platform] FOREIGN KEY ([CompanyId]) REFERENCES [Company]([Id]), 
    CONSTRAINT [FK_Picture_Platform] FOREIGN KEY ([PictureId]) REFERENCES [Picture]([Id])
)
