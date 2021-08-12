﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Password] VARBINARY(MAX) NOT NULL, 
    [Salt] NVARCHAR(36) NOT NULL, 
    [Grade] SMALLINT NOT NULL DEFAULT 2, 
    [CreatedAt] DATETIME NOT NULL DEFAULT GETDATE()
)
