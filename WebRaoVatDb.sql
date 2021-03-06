USE [master]
GO
/****** Object:  Database [RaoVat247]    Script Date: 5/19/2022 2:08:56 AM ******/
CREATE DATABASE [RaoVat247]
GO
ALTER DATABASE [RaoVat247] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RaoVat247].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RaoVat247] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RaoVat247] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RaoVat247] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RaoVat247] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RaoVat247] SET ARITHABORT OFF 
GO
ALTER DATABASE [RaoVat247] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [RaoVat247] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RaoVat247] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RaoVat247] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RaoVat247] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RaoVat247] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RaoVat247] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RaoVat247] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RaoVat247] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RaoVat247] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RaoVat247] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RaoVat247] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RaoVat247] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RaoVat247] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RaoVat247] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RaoVat247] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RaoVat247] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RaoVat247] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RaoVat247] SET  MULTI_USER 
GO
ALTER DATABASE [RaoVat247] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RaoVat247] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RaoVat247] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RaoVat247] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RaoVat247] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RaoVat247] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RaoVat247] SET QUERY_STORE = OFF
GO
USE [RaoVat247]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/19/2022 2:08:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] NOT NULL,
	[CategoryName] [nvarchar](20) NULL,
	[Image] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Follow]    Script Date: 5/19/2022 2:08:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Follow](
	[UserId] [int] NOT NULL,
	[FollowerId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[FollowerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Like]    Script Date: 5/19/2022 2:08:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Like](
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/19/2022 2:08:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(100000,1) NOT NULL,
	[ProductName] [nvarchar](100) NULL,
	[Price] [money] NULL,
	[CreateDate] [datetime] NULL,
	[Status] [char](2) NULL,
	[Description] [nvarchar](999) NULL,
	[UserId] [int] NULL,
	[Address] [nvarchar](100) NULL,
	[ImagePath] [nvarchar](100) NULL,
	[SubCategoryId] [int] NULL,
	[Province] [nvarchar](50) NULL,
	[District] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 5/19/2022 2:08:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[SubCategoryId] [int] NOT NULL,
	[SubCategoryName] [nvarchar](30) NULL,
	[CategoryId] [int] NULL,
	[Image] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/19/2022 2:08:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Password] [char](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](10) NULL,
	[Address] [nvarchar](50) NULL,
	[Avatar] [nchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Image]) VALUES (1, N'Đồ điên tử', N'thiet-bi-dien-tu-la-gi-0.jpg                      ')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Image]) VALUES (2, N'Đồ gia dụng', N'OIP.jpg                                           ')
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [Image]) VALUES (5, N'Thú cưng', N'tc.jpg                                            ')
GO
INSERT [dbo].[Follow] ([UserId], [FollowerId]) VALUES (1, 4)
GO
INSERT [dbo].[Like] ([UserId], [ProductId]) VALUES (4, 100020)
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductName], [Price], [CreateDate], [Status], [Description], [UserId], [Address], [ImagePath], [SubCategoryId], [Province], [District]) VALUES (100009, N'Bàn văn phòng , ghế văn phòng', 1200000.0000, CAST(N'2022-05-16T01:21:54.333' AS DateTime), NULL, N'Ghế sofa bed đặt làm mới về thêm 2 màu xám nhung, xám simili.
Kích thước thành giường 168x96cm.
4 chân inox chắc chắn.
Hỗ trợ giao hàng và lắp đặt Hồ Chí Minh và các tỉnh lận cận', 1, N'12 Tam Trinh', N'ca3e814a206f96b8451a10bb5e651158-2772646641546171212.jpg', 21, N'24', N'Quận Hoàng Mai')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Price], [CreateDate], [Status], [Description], [UserId], [Address], [ImagePath], [SubCategoryId], [Province], [District]) VALUES (100010, N'Bàn học gỗ nhựa Đài loan', 1000000.0000, CAST(N'2022-05-16T01:22:59.857' AS DateTime), NULL, N'Ghế sofa bed đặt làm mới về thêm 2 màu xám nhung, xám simili.
Kích thước thành giường 168x96cm.
4 chân inox chắc chắn.
Hỗ trợ giao hàng và lắp đặt Hồ Chí Minh và các tỉnh lận cận', 1, N'12 Tam Trinh', N'11f7f87764f0661c2ba4d1281f60c630-2772645645029532861.jpg', 21, N'24', N'Quận Hoàng Mai')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Price], [CreateDate], [Status], [Description], [UserId], [Address], [ImagePath], [SubCategoryId], [Province], [District]) VALUES (100011, N'Ghế gỗ Xoan điêu khắc nghệ thuật', 3000000.0000, CAST(N'2022-05-16T01:24:13.827' AS DateTime), NULL, N'Ghế sofa bed đặt làm mới về thêm 2 màu xám nhung, xám simili.
Kích thước thành giường 168x96cm.
4 chân inox chắc chắn.
Hỗ trợ giao hàng và lắp đặt Hồ Chí Minh và các tỉnh lận cận', 1, N'33 Lĩnh Nam', N'a97d3ef7683bbce1ef465a684cbfcb09-2772655567963743449.jpg', 21, N'24', N'Quận Hoàng Mai')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Price], [CreateDate], [Status], [Description], [UserId], [Address], [ImagePath], [SubCategoryId], [Province], [District]) VALUES (100012, N'Chó nhà Pug cực đẹp', 2500000.0000, CAST(N'2022-05-16T01:29:04.837' AS DateTime), NULL, N'e cần bán đàn phốc sóc f1 cho anh chị nào yêu cún ạ phốc sóc nhà nuôi khoẻ đẹp ăn uống khoẻ đáng yêu nhanh nhẹn
các bé được 75 ngay
đã sổ giun tiêm phòng
ưu tiên các anh chị qua nhà đón bé
e nhận ship các tỉnh', 1, N'122/23 Cầu Giấy', N'608ffd06f7d7d57b2a078fca9b3316cc-2768398548440240612.jpg', 51, N'24', N'Quận Cầu Giấy')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Price], [CreateDate], [Status], [Description], [UserId], [Address], [ImagePath], [SubCategoryId], [Province], [District]) VALUES (100014, N'Husky thông minh 15kg 9 tháng', 4000000.0000, CAST(N'2022-05-16T01:39:46.083' AS DateTime), NULL, N'e cần bán đàn phốc sóc f1 cho anh chị nào yêu cún ạ phốc sóc nhà nuôi khoẻ đẹp ăn uống khoẻ đáng yêu nhanh nhẹn
các bé được 75 ngay
đã sổ giun tiêm phòng
ưu tiên các anh chị qua nhà đón bé
e nhận ship các tỉnh', 1, N'12/43 Cầu Giấy', N'b5d7c6cc7381db0d9e97d0c5bc23e267-2771642054457159447.jpg', 51, N'24', N'Quận Cầu Giấy')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Price], [CreateDate], [Status], [Description], [UserId], [Address], [ImagePath], [SubCategoryId], [Province], [District]) VALUES (100015, N'Chó Fox cực dễ thương 3 tháng tuổi', 2000000.0000, CAST(N'2022-05-16T01:40:43.993' AS DateTime), NULL, N'e cần bán đàn phốc sóc f1 cho anh chị nào yêu cún ạ phốc sóc nhà nuôi khoẻ đẹp ăn uống khoẻ đáng yêu nhanh nhẹn
các bé được 75 ngay
đã sổ giun tiêm phòng
ưu tiên các anh chị qua nhà đón bé
e nhận ship các tỉnh', 1, N'Cầu Diễn', N'ffb02299d86379670a99bc70c0911a89-2770831563653972038.jpg', 21, N'24', N'Quận Bắc Từ Liêm')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Price], [CreateDate], [Status], [Description], [UserId], [Address], [ImagePath], [SubCategoryId], [Province], [District]) VALUES (100016, N'Ba em mèo 4 tháng cực xinh xắn', 800000.0000, CAST(N'2022-05-16T01:42:13.797' AS DateTime), NULL, N'e cần bán đàn phốc sóc f1 cho anh chị nào yêu cún ạ phốc sóc nhà nuôi khoẻ đẹp ăn uống khoẻ đáng yêu nhanh nhẹn
các bé được 75 ngay
đã sổ giun tiêm phòng
ưu tiên các anh chị qua nhà đón bé
e nhận ship các tỉnh', 1, N'Cầu Diễn', N'24d5d0df28ee18d549f3fcf1b48b6c11-2772356929149001814.jpg', 52, N'24', N'Quận Bắc Từ Liêm')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Price], [CreateDate], [Status], [Description], [UserId], [Address], [ImagePath], [SubCategoryId], [Province], [District]) VALUES (100017, N'Sofa chữ L xám sang trọng', 30000000.0000, CAST(N'2022-05-16T01:44:38.267' AS DateTime), NULL, N'Ghế sofa bed đặt làm mới về thêm 2 màu xám nhung, xám simili.
Kích thước thành giường 168x96cm.
4 chân inox chắc chắn.
Hỗ trợ giao hàng và lắp đặt Hồ Chí Minh và các tỉnh lận cận', 1, N'Cầu Diễn', N'e7558c2d697df742d62644dee425ded6-2772453968236248972.jpg', 11, N'24', N'Quận Bắc Từ Liêm')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Price], [CreateDate], [Status], [Description], [UserId], [Address], [ImagePath], [SubCategoryId], [Province], [District]) VALUES (100018, N'Puldoll 1 tháng tuổi', 2000000.0000, CAST(N'2022-05-16T01:45:35.973' AS DateTime), NULL, N'e cần bán đàn phốc sóc f1 cho anh chị nào yêu cún ạ phốc sóc nhà nuôi khoẻ đẹp ăn uống khoẻ đáng yêu nhanh nhẹn
các bé được 75 ngay
đã sổ giun tiêm phòng
ưu tiên các anh chị qua nhà đón bé
e nhận ship các tỉnh', 1, N'Cầu Diễn', N'54bf79b52900fd83ab323559ce00a13c-2772594322664078654.jpg', 51, N'24', N'Quận Bắc Từ Liêm')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Price], [CreateDate], [Status], [Description], [UserId], [Address], [ImagePath], [SubCategoryId], [Province], [District]) VALUES (100020, N'Pass lại PC cũ giá rẻ', 5000000.0000, CAST(N'2022-05-16T01:56:47.380' AS DateTime), NULL, N'Main h68mk đẹp keng
Nguồn 700w
Ram 8gb ssd 128gb
Chíp amd a8 7600 4nhân 4 luồng xung 3.8 =i5 gen 4. Card rời 2gb bao mượt thùng vps mới keng chuột phím lót đầy đủ bảo hành 3 tháng lỗi 1 đổi 1 có fix chút cho ae thiện lành nt chợ tốt giúp em cảm ơn ạ', 1, N'23 Trần Hưng Đạo', N'78fb49262ed349478c71.jpg', 11, N'1', N'Thành phố Long Xuyên')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Price], [CreateDate], [Status], [Description], [UserId], [Address], [ImagePath], [SubCategoryId], [Province], [District]) VALUES (100021, N'3 chiếc IP X cũ ', 9000000.0000, CAST(N'2022-05-16T02:01:17.710' AS DateTime), NULL, N'Oppo Reno 5 máy vừa hết bào hành được vài ngày.
Tình trạng : sử dụng tốt.
Đánh giá tổng thể : 98%
( Mặt lưng có 1 vệt xước sâu - còn lại đẹp )
Giao dịch nhanh gọn, uy tín tại địa chỉ đường Cao Bá Quát nối dài ( Khu vườn xoài )', 1, N'42/32 Trần Hưng Đạo', N'83feedeb56866eaaff80e290f0ad86f6-2728161972374331753.jpg', 12, N'1', N'Thành phố Long Xuyên')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
INSERT [dbo].[SubCategory] ([SubCategoryId], [SubCategoryName], [CategoryId], [Image]) VALUES (11, N'Máy tính bàn', 1, N'cau-tao-pc-laptop-3_450x357.png')
INSERT [dbo].[SubCategory] ([SubCategoryId], [SubCategoryName], [CategoryId], [Image]) VALUES (12, N'Điện thoại', 1, N'ip7.jpg')
INSERT [dbo].[SubCategory] ([SubCategoryId], [SubCategoryName], [CategoryId], [Image]) VALUES (21, N'Bàn ghế', 2, N'e7558c2d697df742d62644dee425ded6-2772453968236248972.jpg')
INSERT [dbo].[SubCategory] ([SubCategoryId], [SubCategoryName], [CategoryId], [Image]) VALUES (51, N'Chó', 5, N'dogg.jpg')
INSERT [dbo].[SubCategory] ([SubCategoryId], [SubCategoryName], [CategoryId], [Image]) VALUES (52, N'Mèo', 5, N'mao.jpg')
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Password], [LastName], [FirstName], [UserName], [PhoneNumber], [Address], [Avatar], [Status]) VALUES (1, N'123                                               ', N'Nguyễn', N'Khánh', N'khanhnd                                           ', N'090000', N'hd', N'lambof.jpeg                                       ', 1)
INSERT [dbo].[User] ([UserId], [Password], [LastName], [FirstName], [UserName], [PhoneNumber], [Address], [Avatar], [Status]) VALUES (4, N'111                                               ', N'Trần ', N'Lan', N'lan                                               ', N'0909999999', N'Cầu Diễn', N'ronaldo and his car.jpg                           ', 1)
INSERT [dbo].[User] ([UserId], [Password], [LastName], [FirstName], [UserName], [PhoneNumber], [Address], [Avatar], [Status]) VALUES (7, N'123                                               ', N'Nguyễn', N'Khánh', N'admin', NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Follow]  WITH CHECK ADD FOREIGN KEY([FollowerId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Follow]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[SubCategory] ([SubCategoryId])
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
USE [master]
GO
ALTER DATABASE [RaoVat247] SET  READ_WRITE 
GO
