USE [AllDB]
GO
/****** Object:  Table [dbo].[ProductTable]    Script Date: 10/14/2024 2:42:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [nvarchar](50) NOT NULL,
	[product_name] [nvarchar](100) NOT NULL,
	[product_price] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductUnit]    Script Date: 10/14/2024 2:42:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductUnit](
	[product_unit_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [nvarchar](50) NOT NULL,
	[unit_id] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 10/14/2024 2:42:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[unit_id] [int] IDENTITY(1,1) NOT NULL,
	[unit_name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ProductTable] ON 

INSERT [dbo].[ProductTable] ([id], [product_id], [product_name], [product_price]) VALUES (1, N'C-0001', N'orange', N'100')
INSERT [dbo].[ProductTable] ([id], [product_id], [product_name], [product_price]) VALUES (2, N'C-0002', N'water', N'300')
SET IDENTITY_INSERT [dbo].[ProductTable] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductUnit] ON 

INSERT [dbo].[ProductUnit] ([product_unit_id], [product_id], [unit_id]) VALUES (1, N'C-0001', N'1')
INSERT [dbo].[ProductUnit] ([product_unit_id], [product_id], [unit_id]) VALUES (2, N'C-0002', N'2')
SET IDENTITY_INSERT [dbo].[ProductUnit] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([unit_id], [unit_name]) VALUES (1, N'gram')
INSERT [dbo].[Unit] ([unit_id], [unit_name]) VALUES (2, N'liters')
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
