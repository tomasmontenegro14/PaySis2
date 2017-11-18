
CREATE DATABASE [Paysis]
GO
USE [Paysis]
GO

CREATE TABLE [dbo].[DIM_USERS](
	[ID_USER] Int PRIMARY KEY identity(1,1)  NOT NULL ,
	[USERNAME] [nvarchar](255) NOT NULL,
	[PASSWORD] [nvarchar](255) NOT NULL, 
	[ID_ROLEUSER] int NOT NULL
)


CREATE TABLE [dbo].[DIM_ROLES_USER](
	[ID_ROLEUSER] Int PRIMARY KEY identity(1,1)  NOT NULL ,
	[NAME_ROLE] [nvarchar](255) NOT NULL
)


CREATE TABLE [dbo].[DIM_TRANSACTIONS](
	[ID_TRANSACTION] Int PRIMARY KEY identity(1,1) NOT NULL ,
	[STEP_TRANSACTION] INT  NULL,
	[TYPE_TRANSACTION] [NVARCHAR](255) NULL,
	[AMOUNT_TRANSACTION] MONEY,
	[NAMEORIG_TRANSACTION] [nvarchar](255) NULL,
	[OLDBALANCEORG_TRANSACTION] money NULL,
	[NEWBALANCEORIG_TRANSACTION] money NULL,
	[NAMEDEST_TRANSACTION] [NVARCHAR](255) NULL,
	[OLDBALANCEDEST_TRANSACTION] MONEY NULL,
	[NEWBALANCEDEST_TRANSACTION] MONEY NULL,
	[ISFRAUD_TRANSACTION] INT  NULL,
	[ISFLAGGEDFRAUD_TRANSACTION] INT  NULL 
)

GO


CREATE TABLE [dbo].[DIM_TYPES_TRANSACTION]
(		
[ID_TYPE_TRANSACTION] Int PRIMARY KEY identity(1,1)  NOT NULL , 
DESC_TYPE_TRX [nvarchar](255)
)
GO


CREATE TABLE [dbo].[DIM_ACCOUNTS](
	ID_ACCOUNT INT PRIMARY KEY IDENTITY(1,1) NOT NULL ,
	[NUM_ACCOUNT] [nvarchar](255) NULL
) 
	
