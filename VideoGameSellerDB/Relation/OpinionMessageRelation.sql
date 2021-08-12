CREATE TABLE [dbo].[OpinionMessageRelation]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [MessageId] INT NOT NULL, 
    [OpinionId] INT NOT NULL, 
    CONSTRAINT [FK_Message_OpinionMessage_Relation] FOREIGN KEY ([MessageId]) REFERENCES [Message]([Id]), 
    CONSTRAINT [FK_Opinion_OpinionMessage_Relation] FOREIGN KEY ([OpinionId]) REFERENCES [Opinion]([Id])
)
