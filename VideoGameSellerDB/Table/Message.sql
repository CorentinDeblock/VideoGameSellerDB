CREATE TABLE [dbo].[Message]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [Message] NVARCHAR(MAX) NOT NULL, 
    [PublishedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_Message_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
