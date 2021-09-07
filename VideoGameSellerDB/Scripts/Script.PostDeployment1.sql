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

EXEC [dbo].SP_User 'Root', 'root@root.com', 'root', 0
EXEC [dbo].SP_User 'Michel', 'michel@gmail.com', 'mimi', 2
EXEC [dbo].SP_User 'Pierre', 'pierre@gmail.com', 'pierre', 2
EXEC [dbo].SP_User 'Jean', 'jean@gmail.com', 'jean', 2
EXEC [dbo].SP_User 'Supp', 'Supp@gmail.com', 'blab', 3

EXEC [dbo].SP_Company 'Atari.png', 'Atari', '06-27-1972'

EXEC [dbo].SP_Platform 1,'Atari2600.png','Atari2600','Une veille console','09-11-1977'
EXEC [dbo].SP_Platform 1,'PS1.png','PS1','Une veille console de salon','09-11-1998'

EXEC [dbo].SP_Game 1,1,'Pacman.png','Pacman','Un camembert qui mange des balles de ping pong jaune','05-12-1980'
EXEC [dbo].SP_Game 1,1,'SpaceInvaders.png','Space invaders','Un jeu dans l''espace','01-22-1978'

EXEC [dbo].SP_PlatformGame 1,1
EXEC [dbo].SP_PlatformGame 1,2
EXEC [dbo].SP_PlatformGame 2,1

EXEC [dbo].SP_Sale 1,4,'Pacman original de 1977','Je vends mon jeu pacman de 1977', 1000, 0
EXEC [dbo].SP_Sale 2,2,'My space invaders game buyed from day 1','I put my game space invaders in bid', 1000, 1

EXEC [dbo].SP_MessageSale 'Bonjour ! Pourriez vous mettre plus de photo ?', 2, 1

EXEC [dbo].SP_OpinionMessage 1,3,1

EXEC [dbo].SP_OpinionSale 1,2,0
EXEC [dbo].SP_OpinionSale 2,3,0

EXEC [dbo].SP_PictureSale 'SalePacman.jpg',1
EXEC [dbo].SP_PictureSale 'SaleSpaceInvaders.jpg',2

EXEC [dbo].SP_UserSale 1,1