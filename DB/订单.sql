USE [Cinema]
GO
/****** Object:  Table [dbo].[OrderInfo]    Script Date: 2019/12/23 12:45:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderInfo](
	[OrderID] [int] IDENTITY(10000,1) NOT NULL,
	[OrderSumMoney] [decimal](18, 2) NOT NULL,
	[UsersID] [int] NOT NULL,
	[OrderTime] [datetime] NOT NULL,
	[MovieName] [nvarchar](50) NOT NULL,
	[CinemaAddress] [nvarchar](50) NOT NULL,
	[OfficeID] [int] NOT NULL,
	[ChipInfoID] [int] NOT NULL,
	[IsPay] [int] NOT NULL,
	[PayTime] [int] NULL,
 CONSTRAINT [PK__OrderInf__C3905BAF9A9C3BD4] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OrderInfo] ON 

INSERT [dbo].[OrderInfo] ([OrderID], [OrderSumMoney], [UsersID], [OrderTime], [MovieName], [CinemaAddress], [OfficeID], [ChipInfoID], [IsPay], [PayTime]) VALUES (10000, CAST(80.00 AS Decimal(18, 2)), 2, CAST(N'2019-12-23T10:00:00.000' AS DateTime), N'冰雪奇缘2', N'开福区湘江中路589号万达广场5层', 1, 1, 0, 900)
SET IDENTITY_INSERT [dbo].[OrderInfo] OFF
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK__OrderInfo__Cinem__571DF1D5] FOREIGN KEY([CinemaAddress])
REFERENCES [dbo].[CinemaInfo] ([CinemaAddress])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK__OrderInfo__Cinem__571DF1D5]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK__OrderInfo__Movie__00200768] FOREIGN KEY([MovieName])
REFERENCES [dbo].[MovieInfo] ([MovieName])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK__OrderInfo__Movie__00200768]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK__OrderInfo__Offic__59063A47] FOREIGN KEY([OfficeID])
REFERENCES [dbo].[OfficeInfo] ([OfficeID])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK__OrderInfo__Offic__59063A47]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK__OrderInfo__Users__7F2BE32F] FOREIGN KEY([UsersID])
REFERENCES [dbo].[UsersInfo] ([UsersID])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK__OrderInfo__Users__7F2BE32F]
GO
ALTER TABLE [dbo].[OrderInfo]  WITH CHECK ADD  CONSTRAINT [FK_OrderInfo_ChipInfo] FOREIGN KEY([ChipInfoID])
REFERENCES [dbo].[ChipInfo] ([ChipInfoID])
GO
ALTER TABLE [dbo].[OrderInfo] CHECK CONSTRAINT [FK_OrderInfo_ChipInfo]
GO
