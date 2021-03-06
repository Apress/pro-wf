USE [master]
GO
IF  EXISTS (SELECT name FROM sys.databases 
    WHERE name = N'ProWorkflow')
DROP DATABASE [ProWorkflow]
GO
CREATE DATABASE [ProWorkflow]
GO
USE ProWorkflow
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[account]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[account](
	[accountId] [int] NOT NULL,
	[description] [nvarchar](50) NULL,
	[balance] [money] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[itemInventory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[itemInventory](
	[itemId] [int] NOT NULL,
	[description] [nvarchar](50) NULL,
	[qtyOnHand] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[orderDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[orderDetail](
	[orderId] [int] NOT NULL,
	[accountId] [int] NOT NULL,
	[itemId] [int] NOT NULL,
	[quantity] [int] NOT NULL
) ON [PRIMARY]
END
