USE [master]
GO
/****** Object:  Database [ProjectC#]    Script Date: 11/11/2020 10:38:03 PM ******/
CREATE DATABASE [ProjectC#]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectC#', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProjectC#.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectC#_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProjectC#_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjectC#] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectC#].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectC#] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectC#] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectC#] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectC#] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectC#] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectC#] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectC#] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectC#] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectC#] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectC#] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectC#] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectC#] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectC#] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectC#] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectC#] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectC#] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectC#] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectC#] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectC#] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectC#] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectC#] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectC#] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectC#] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectC#] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectC#] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectC#] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectC#] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectC#] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProjectC#] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectC#', N'ON'
GO
USE [ProjectC#]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/11/2020 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[PhoneNumber] [varchar](11) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Status] [varchar](15) NOT NULL,
	[RoleID] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 11/11/2020 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Brand](
	[BrandID] [varchar](5) NOT NULL,
	[BrandName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 11/11/2020 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cart](
	[CartID] [varchar](5) NOT NULL,
	[CartName] [nvarchar](50) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[Status] [nvarchar](20) NOT NULL,
	[Payment] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](200) NOT NULL DEFAULT ('H? Chí Minh'),
	[Total] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CartDetail]    Script Date: 11/11/2020 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CartDetail](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[IDProduct] [varchar](5) NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[CartID] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/11/2020 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [varchar](5) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/11/2020 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[IDProduct] [varchar](5) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Status] [nvarchar](15) NOT NULL,
	[BrandID] [varchar](5) NOT NULL,
	[CategoryID] [varchar](5) NOT NULL,
	[Image] [varchar](500) NOT NULL DEFAULT ('https://previews.123rf.com/images/doomko/doomko1508/doomko150800003/43683599-fun-mobile-phone-cartoon-with-thumbs-up.jpg'),
PRIMARY KEY CLUSTERED 
(
	[IDProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/11/2020 10:38:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [varchar](5) NOT NULL,
	[RoleName] [nvarchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Account] ([Username], [Password], [FullName], [PhoneNumber], [Address], [DateOfBirth], [Status], [RoleID]) VALUES (N'buivinhkhoi', N'123456789', N'Bùi Vĩnh Khôi', N'0312546212', N'Quận 8', CAST(N'2000-11-05' AS Date), N'Available', N'2')
INSERT [dbo].[Account] ([Username], [Password], [FullName], [PhoneNumber], [Address], [DateOfBirth], [Status], [RoleID]) VALUES (N'huavinhkhang', N'123456789', N'Hứa Vĩnh Khang', N'0961101399', N'QUận 2', CAST(N'2000-06-03' AS Date), N'Available', N'1')
INSERT [dbo].[Brand] ([BrandID], [BrandName]) VALUES (N'1', N'Samsung')
INSERT [dbo].[Brand] ([BrandID], [BrandName]) VALUES (N'2', N'Apple')
INSERT [dbo].[Cart] ([CartID], [CartName], [Username], [CreatedDate], [Status], [Payment], [Address], [Total]) VALUES (N'1', N'Cart of Bùi Vĩnh Khôi', N'buivinhkhoi', CAST(N'2020-10-31' AS Date), N'Waiting', N'COD', N'HoChiMinh City', 64000000)
INSERT [dbo].[Cart] ([CartID], [CartName], [Username], [CreatedDate], [Status], [Payment], [Address], [Total]) VALUES (N'2', N'Cart of Bùi Vĩnh Khôi', N'buivinhkhoi', CAST(N'2020-10-31' AS Date), N'Waiting', N'COD', N'HoChiMinh City', 80000000)
INSERT [dbo].[Cart] ([CartID], [CartName], [Username], [CreatedDate], [Status], [Payment], [Address], [Total]) VALUES (N'3', N'Cart of Bùi Vĩnh Khôi', N'buivinhkhoi', CAST(N'2020-10-31' AS Date), N'Waiting', N'COD', N'HoChiMinh City', 77000000)
INSERT [dbo].[Cart] ([CartID], [CartName], [Username], [CreatedDate], [Status], [Payment], [Address], [Total]) VALUES (N'4', N'Cart of Bùi Vĩnh Khôi', N'buivinhkhoi', CAST(N'2020-11-11' AS Date), N'Waiting', N'COD', N'2695/14/2 Phạm Thế Hiển phường 7 quận 8', 16000000)
SET IDENTITY_INSERT [dbo].[CartDetail] ON 

INSERT [dbo].[CartDetail] ([DetailID], [IDProduct], [Quantity], [Price], [CartID]) VALUES (1, N'1', 2, 16000000, N'1')
INSERT [dbo].[CartDetail] ([DetailID], [IDProduct], [Quantity], [Price], [CartID]) VALUES (2, N'4', 1, 32000000, N'1')
INSERT [dbo].[CartDetail] ([DetailID], [IDProduct], [Quantity], [Price], [CartID]) VALUES (3, N'1', 3, 16000000, N'2')
INSERT [dbo].[CartDetail] ([DetailID], [IDProduct], [Quantity], [Price], [CartID]) VALUES (4, N'4', 1, 32000000, N'2')
INSERT [dbo].[CartDetail] ([DetailID], [IDProduct], [Quantity], [Price], [CartID]) VALUES (5, N'3', 3, 20000000, N'3')
INSERT [dbo].[CartDetail] ([DetailID], [IDProduct], [Quantity], [Price], [CartID]) VALUES (6, N'5', 1, 17000000, N'3')
INSERT [dbo].[CartDetail] ([DetailID], [IDProduct], [Quantity], [Price], [CartID]) VALUES (7, N'1', 1, 16000000, N'4')
SET IDENTITY_INSERT [dbo].[CartDetail] OFF
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (N'1', N'Phone')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (N'2', N'Tablet')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (N'3', N'Accessory')
INSERT [dbo].[Product] ([IDProduct], [ProductName], [Quantity], [Price], [Status], [BrandID], [CategoryID], [Image]) VALUES (N'1', N'Samsung Galaxy S9', 101, 16000000, N'Available', N'1', N'1', N'https://viostore.vn/wp-content/uploads/2018/05/samsung-galaxy-s9-plus-g965fd-dual-sim-4g-vvw8fd.jpg')
INSERT [dbo].[Product] ([IDProduct], [ProductName], [Quantity], [Price], [Status], [BrandID], [CategoryID], [Image]) VALUES (N'2', N'Iphone 11', 100, 33000000, N'Available', N'1', N'1', N'https://didongviet.vn/pub/media/catalog/product//9/9/99-min.jpg')
INSERT [dbo].[Product] ([IDProduct], [ProductName], [Quantity], [Price], [Status], [BrandID], [CategoryID], [Image]) VALUES (N'3', N'Samsung Galaxy S10', 97, 20000000, N'Available', N'1', N'1', N'https://fptshop.com.vn/Uploads/Originals/2019/2/21/636863621214675213_ss-galaxy-s10-den-1.png')
INSERT [dbo].[Product] ([IDProduct], [ProductName], [Quantity], [Price], [Status], [BrandID], [CategoryID], [Image]) VALUES (N'4', N'Iphone 12', 99, 32000000, N'Available', N'1', N'1', N'https://www.bachlong.vn/vnt_upload/product/10_2020/iphone-12-pro-max-blue-hero.png')
INSERT [dbo].[Product] ([IDProduct], [ProductName], [Quantity], [Price], [Status], [BrandID], [CategoryID], [Image]) VALUES (N'5', N'Iphone XR', 149, 17000000, N'Available', N'1', N'1', N'https://didongviet.vn/pub/media/catalog/product//i/p/iphone-xr-mau-vang-didongviet_1_1_2.jpg')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (N'1', N'Admin')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (N'2', N'Member')
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([Username])
REFERENCES [dbo].[Account] ([Username])
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([Username])
REFERENCES [dbo].[Account] ([Username])
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([Username])
REFERENCES [dbo].[Account] ([Username])
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD FOREIGN KEY([CartID])
REFERENCES [dbo].[Cart] ([CartID])
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD FOREIGN KEY([CartID])
REFERENCES [dbo].[Cart] ([CartID])
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD FOREIGN KEY([CartID])
REFERENCES [dbo].[Cart] ([CartID])
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD FOREIGN KEY([IDProduct])
REFERENCES [dbo].[Product] ([IDProduct])
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD FOREIGN KEY([IDProduct])
REFERENCES [dbo].[Product] ([IDProduct])
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD FOREIGN KEY([IDProduct])
REFERENCES [dbo].[Product] ([IDProduct])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
USE [master]
GO
ALTER DATABASE [ProjectC#] SET  READ_WRITE 
GO
