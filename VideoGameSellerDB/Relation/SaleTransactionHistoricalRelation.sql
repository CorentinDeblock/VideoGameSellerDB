CREATE TABLE [dbo].[SaleTransactionHistoricalRelation]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SaleTransactionId] INT NOT NULL, 
    [HistoricalId] INT NOT NULL, 
    CONSTRAINT [FK_SaleTransaction_SaleTransactionHistorical_Relation] FOREIGN KEY ([SaleTransactionId]) REFERENCES [SaleTransaction]([Id]),
    CONSTRAINT [FK_Historical_SaleTransactionHistorical_Relation] FOREIGN KEY ([HistoricalId]) REFERENCES [Historical]([Id])
)
