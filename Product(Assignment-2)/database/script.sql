USE [AllDB]
GO
/****** Object:  Table [dbo].[ProductTable]    Script Date: 10/15/2024 4:33:14 PM ******/
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
/****** Object:  Table [dbo].[ProductUnit]    Script Date: 10/15/2024 4:33:14 PM ******/
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
/****** Object:  Table [dbo].[Unit]    Script Date: 10/15/2024 4:33:14 PM ******/
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

INSERT [dbo].[ProductTable] ([id], [product_id], [product_name], [product_price]) VALUES (1, N'C-0001', N'orange', N'300')
INSERT [dbo].[ProductTable] ([id], [product_id], [product_name], [product_price]) VALUES (2, N'C-0002', N'water', N'300')
INSERT [dbo].[ProductTable] ([id], [product_id], [product_name], [product_price]) VALUES (3, N'C-0003', N'milk', N'2000')
INSERT [dbo].[ProductTable] ([id], [product_id], [product_name], [product_price]) VALUES (4, N'C-0004', N'sugar', N'300')
INSERT [dbo].[ProductTable] ([id], [product_id], [product_name], [product_price]) VALUES (7, N'C-0005', N'Apple', N'600')
INSERT [dbo].[ProductTable] ([id], [product_id], [product_name], [product_price]) VALUES (8, N'C-0008', N'chocolet', N'1500')
INSERT [dbo].[ProductTable] ([id], [product_id], [product_name], [product_price]) VALUES (9, N'C-0009', N'Royal D', N'1500')
SET IDENTITY_INSERT [dbo].[ProductTable] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductUnit] ON 

INSERT [dbo].[ProductUnit] ([product_unit_id], [product_id], [unit_id]) VALUES (1, N'C-0001', N'1')
INSERT [dbo].[ProductUnit] ([product_unit_id], [product_id], [unit_id]) VALUES (2, N'C-0002', N'2')
INSERT [dbo].[ProductUnit] ([product_unit_id], [product_id], [unit_id]) VALUES (3, N'C-0003', N'3')
INSERT [dbo].[ProductUnit] ([product_unit_id], [product_id], [unit_id]) VALUES (4, N'C-0004', N'4')
INSERT [dbo].[ProductUnit] ([product_unit_id], [product_id], [unit_id]) VALUES (7, N'C-0005', N'7')
INSERT [dbo].[ProductUnit] ([product_unit_id], [product_id], [unit_id]) VALUES (8, N'C-0008', N'8')
SET IDENTITY_INSERT [dbo].[ProductUnit] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([unit_id], [unit_name]) VALUES (1, N'grams')
INSERT [dbo].[Unit] ([unit_id], [unit_name]) VALUES (2, N'llters')
INSERT [dbo].[Unit] ([unit_id], [unit_name]) VALUES (3, N'tank')
INSERT [dbo].[Unit] ([unit_id], [unit_name]) VALUES (4, N'packs')
INSERT [dbo].[Unit] ([unit_id], [unit_name]) VALUES (7, N'kilos')
INSERT [dbo].[Unit] ([unit_id], [unit_name]) VALUES (8, N'sticks')
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
