USE [AllDB]
GO
/****** Object:  Table [dbo].[CustomerTable]    Script Date: 9/30/2024 4:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customer_id] [nvarchar](50) NOT NULL,
	[customer_name] [nvarchar](100) NOT NULL,
	[nrc_number] [nvarchar](100) NOT NULL,
	[dob] [date] NULL,
	[member_card] [smallint] NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[gender] [smallint] NOT NULL,
	[phone_no_1] [nvarchar](50) NOT NULL,
	[phone_no_2] [nvarchar](50) NULL,
	[photo] [nvarchar](200) NULL,
	[address] [nvarchar](500) NULL,
	[created_user_id] [int] NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[updated_user_id] [int] NULL,
	[updated_datetime] [datetime] NULL,
	[is_deleted] [smallint] NOT NULL,
	[deleted_user_id] [int] NULL,
	[deleted_datetime] [datetime] NULL,
	[password] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CustomerTable] ON 

INSERT [dbo].[CustomerTable] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (1, N'C-0001', N'ye min aung', N'11/KHKJKJ(N)098338', CAST(N'2000-02-08' AS Date), 2, N'ye@.com', 1, N'0987623677', N'0989427387', N'C:\Users\AM\Desktop\Csharp\Tutorial4\Tutorial4\bin\Debug\net8.0-windows\images\ye min aungerr.png', N'yangon', 1, CAST(N'2024-09-27T14:12:37.203' AS DateTime), 1, CAST(N'2024-09-30T10:29:23.953' AS DateTime), 0, 1, CAST(N'2024-09-27T14:12:37.203' AS DateTime), N'+rB+7ig3unHIBuUjoi71CA==')
INSERT [dbo].[CustomerTable] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (2, N'C-0002', N'Ke Ke', N'14/KKSJKJ(N)098338', CAST(N'2004-06-15' AS Date), 1, N'la@.com', 2, N'093127489', N'0976343443', N'C:\Users\AM\Desktop\Csharp\Tutorial4\Tutorial4\bin\Debug\net8.0-windows\images\aung aungJ Fashion.png', N'mandalay', 1, CAST(N'2024-09-27T14:42:07.243' AS DateTime), 1, CAST(N'2024-09-30T15:16:01.410' AS DateTime), 0, 1, CAST(N'2024-09-27T14:42:07.243' AS DateTime), N'+rB+7ig3unHIBuUjoi71CA==')
INSERT [dbo].[CustomerTable] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (3, N'C-0003', N'ko ko', N'14/KHKJKJ(N)098338', CAST(N'2004-06-15' AS Date), 1, N'ko@.com', 0, N'0987623677', N'', N'C:\Users\AM\Desktop\Csharp\Tutorial4\Tutorial4\bin\Debug\net8.0-windows\images\ko kolo.png', N'mandalay', 1, CAST(N'2024-09-27T16:27:03.173' AS DateTime), 1, CAST(N'2024-09-27T16:27:03.173' AS DateTime), 0, 1, CAST(N'2024-09-27T16:27:03.173' AS DateTime), N'+rB+7ig3unHIBuUjoi71CA==')
INSERT [dbo].[CustomerTable] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (6, N'C-0006', N'la la', N'14/KKSJKJ(N)098338', CAST(N'2004-06-15' AS Date), 1, N'la@.com', 0, N'093127489', N'0976343443', N'C:\Users\AM\Desktop\Csharp\Tutorial4\Tutorial4\bin\Debug\net8.0-windows\images\la lapp.jpg', N'mandalay', 1, CAST(N'2024-09-27T16:33:59.570' AS DateTime), 1, CAST(N'2024-09-27T16:33:59.570' AS DateTime), 0, 1, CAST(N'2024-09-27T16:33:59.570' AS DateTime), N'+rB+7ig3unHIBuUjoi71CA==')
INSERT [dbo].[CustomerTable] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (7, N'C-0007', N'hla hla', N'13/HKSHKS(N)839223', CAST(N'1990-01-30' AS Date), 1, N'hla@.com', 0, N'0987345687', N'0987465234', N'C:\Users\AM\Desktop\Csharp\Tutorial4\Tutorial4\bin\Debug\net8.0-windows\images\hla hlaye min aungerr.png', N'yangon', 1, CAST(N'2024-09-30T13:12:30.780' AS DateTime), 1, CAST(N'2024-09-30T16:39:00.570' AS DateTime), 1, 1, CAST(N'2024-09-30T13:12:30.780' AS DateTime), N'+rB+7ig3unHIBuUjoi71CA==')
INSERT [dbo].[CustomerTable] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (4, N'C-0004', N'mama', N'14/KHKJKJ(N)098338', CAST(N'2004-06-15' AS Date), 2, N'ma@.com', 2, N'093127489', N'', N'C:\Users\AM\Desktop\Csharp\Tutorial4\Tutorial4\bin\Debug\net8.0-windows\images\mamalogo.png', N'mandalay', 1, CAST(N'2024-09-27T16:27:35.513' AS DateTime), 1, CAST(N'2024-09-27T16:27:35.513' AS DateTime), 0, 1, CAST(N'2024-09-27T16:27:35.513' AS DateTime), N'+rB+7ig3unHIBuUjoi71CA==')
INSERT [dbo].[CustomerTable] ([id], [customer_id], [customer_name], [nrc_number], [dob], [member_card], [email], [gender], [phone_no_1], [phone_no_2], [photo], [address], [created_user_id], [created_datetime], [updated_user_id], [updated_datetime], [is_deleted], [deleted_user_id], [deleted_datetime], [password]) VALUES (5, N'C-0005', N'Ke', N'14/KKSJKJ(N)098338', CAST(N'2004-06-15' AS Date), 1, N'la@.com', 2, N'093127489', N'0976343443', N'C:\Users\AM\Desktop\Csharp\Tutorial4\Tutorial4\bin\Debug\net8.0-windows\images\Keaung aungJ Fashion.png', N'mandalay', 1, CAST(N'2024-09-27T16:29:55.467' AS DateTime), 1, CAST(N'2024-09-30T15:16:25.553' AS DateTime), 0, 1, CAST(N'2024-09-27T16:29:55.467' AS DateTime), N'+rB+7ig3unHIBuUjoi71CA==')
SET IDENTITY_INSERT [dbo].[CustomerTable] OFF
GO
