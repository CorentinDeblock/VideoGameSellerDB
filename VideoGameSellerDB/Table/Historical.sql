CREATE TABLE [dbo].[Historical]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_User_Historical] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
