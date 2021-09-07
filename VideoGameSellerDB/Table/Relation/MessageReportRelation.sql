CREATE TABLE [dbo].[MessageReportRelation]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [ReportId] INT NOT NULL, 
    [MessageId] INT NOT NULL, 
    CONSTRAINT [FK_MessageReportRelation_Report] FOREIGN KEY (ReportId) REFERENCES [Report]([Id]), 
    CONSTRAINT [FK_MessageReportRelation_Message] FOREIGN KEY (MessageId) REFERENCES [Message]([Id])
)
