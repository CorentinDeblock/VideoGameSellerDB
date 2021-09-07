CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Username] NVARCHAR(50) NOT NULL UNIQUE, 
    [Email] NVARCHAR(50) NOT NULL UNIQUE, 
    [Password] VARBINARY(MAX) NOT NULL, 
    [Salt] NVARCHAR(MAX) NOT NULL, 
    [Grade] SMALLINT NOT NULL DEFAULT 2, 
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [CK_User_Email] check (Email like '%_@__%.__%')
)