/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[User](Username,Email,Password,Salt) VALUES('Root','root@root.com',CONVERT(varbinary(30),N'root'),'78998')
INSERT INTO [dbo].[User](Username,Email,Password,Salt) VALUES('Michel','michel@gmail.com',CONVERT(varbinary(30),N'mimi'),'4444')
INSERT INTO [dbo].[User](Username,Email,Password,Salt) VALUES('Pierre','pierre@gmail.com',CONVERT(varbinary(30),N'pierre'),'4646')
INSERT INTO [dbo].[User](Username,Email,Password,Salt) VALUES('Jean','jean@gmail.com',CONVERT(varbinary(30),N'jean'),'7845')

INSERT INTO [dbo].[Message](UserId,Message) VALUES(2,'Hello ! I like this sale')
INSERT INTO [dbo].[Opinion](UserId,Type) VALUES(3,0)
INSERT INTO [dbo].[OpinionMessageRelation](MessageId,OpinionId) VALUES(1,1)

INSERT INTO [dbo].[Picture](Url) VALUES('Image/Atari.png')
INSERT INTO [dbo].[Picture](Url) VALUES('Image/Atari2600.png')
INSERT INTO [dbo].[Picture](Url) VALUES('Image/Pacman.png')
INSERT INTO [dbo].[Picture](URL) VALUES('Image/SpaceInvaders.png')

INSERT INTO [dbo].[Picture](URL) VALUES('Image/SalePacman.png')
INSERT INTO [dbo].[Picture](URL) VALUES('Image/SaleSpaceInvaders.png')

INSERT INTO [dbo].[Company](PictureId,Name,Appearance) VALUES(1,'Atari','06-27-1972')

INSERT INTO [dbo].[Platform](CompanyId,PictureId,Name,Description,Appearance) VALUES(1,2,'Atari2600','Une veille console','09-11-1977')

INSERT INTO [dbo].[Game](PictureId,DeveloperId,PublisherId,Name,Description,Appearance) VALUES(3,1,1,'Pacman','Un camembert qui mange des balles de ping pong jaune','05-12-1980')
INSERT INTO [dbo].[Game](PictureId,DeveloperId,PublisherId,Name,Description,Appearance) VALUES(4,1,1,'Space invaders','Un camembert qui mange des balles de ping pong jaune','01-22-1978')

INSERT INTO [dbo].[Sale](GameId,ProviderId,Description,Price,Type) VALUES(1,4,'Je vends mon jeu pacman de 1977', 1000, 0)
INSERT INTO [dbo].[Sale](GameId,ProviderId,Description,Price,Type) VALUES(1,2,'I put my game space invaders in bid', 1000, 1)

INSERT INTO [dbo].[Opinion](UserId,Type) VALUES(2,0)
INSERT INTO [dbo].[Opinion](UserId,Type) VALUES(3,0)

INSERT INTO [dbo].[OpinionSaleRelation](OpinionId,SaleId) VALUES(2,1)
INSERT INTO [dbo].[PictureSaleRelation](PictureId,SaleId) VALUES(5,1)
INSERT INTO [dbo].[MessageSaleRelation](MessageId,SaleId) VALUES(1,1)
INSERT INTO [dbo].[UserSaleRelation](UserId,SaleId) VALUES(1,1)

INSERT INTO [dbo].[OpinionSaleRelation](OpinionId,SaleId) VALUES(3,2)
INSERT INTO [dbo].[PictureSaleRelation](PictureId,SaleId) VALUES(6,2)