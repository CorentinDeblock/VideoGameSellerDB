CREATE VIEW [dbo].[MessageReportView]
	AS SELECT dbo.MessageView.[User.Id], dbo.MessageView.[User.Username], dbo.MessageView.[User.Email], dbo.MessageView.[User.Grade], dbo.MessageView.[User.CreatedAt], dbo.MessageView.Message, 
    dbo.MessageView.PublishedAt, dbo.MessageView.Id
    FROM dbo.Report INNER JOIN
    dbo.MessageReportRelation ON dbo.Report.Id = dbo.MessageReportRelation.ReportId INNER JOIN
    dbo.MessageView ON dbo.MessageReportRelation.MessageId = dbo.MessageView.Id
