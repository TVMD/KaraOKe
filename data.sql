USE [master]
GO
/****** Object:  Database [QLPhongKaraoke]    Script Date: 01/06/2017 00:10:33 ******/
CREATE DATABASE [QLPhongKaraoke] ON  PRIMARY 
( NAME = N'QLPhongKaraoke', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\QLPhongKaraoke.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLPhongKaraoke_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\QLPhongKaraoke_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLPhongKaraoke] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLPhongKaraoke].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLPhongKaraoke] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET ANSI_NULLS OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET ANSI_PADDING OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET ARITHABORT OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [QLPhongKaraoke] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [QLPhongKaraoke] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [QLPhongKaraoke] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET  DISABLE_BROKER
GO
ALTER DATABASE [QLPhongKaraoke] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [QLPhongKaraoke] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [QLPhongKaraoke] SET  READ_WRITE
GO
ALTER DATABASE [QLPhongKaraoke] SET RECOVERY FULL
GO
ALTER DATABASE [QLPhongKaraoke] SET  MULTI_USER
GO
ALTER DATABASE [QLPhongKaraoke] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [QLPhongKaraoke] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLPhongKaraoke', N'ON'
GO
USE [QLPhongKaraoke]
GO
/****** Object:  Table [dbo].[DATPHONG]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DATPHONG](
	[ID] [int] NOT NULL,
	[NgayGioDat] [datetime] NOT NULL,
	[SDT] [nvarchar](15) NOT NULL,
	[Note] [nvarchar](500) NULL,
	[Deleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_DATPHONG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_HOADONDV]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_HOADONDV](
	[ID_HoaDonDV] [int] NOT NULL,
	[ID_Hang] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [money] NOT NULL,
	[ThanhTien] [money] NOT NULL,
	[Deleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_CT_HOADONDV] PRIMARY KEY CLUSTERED 
(
	[ID_HoaDonDV] ASC,
	[ID_Hang] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CT_HOADONDV] ([ID_HoaDonDV], [ID_Hang], [SoLuong], [DonGia], [ThanhTien], [Deleted]) VALUES (67, 13, 4, 10.0000, 40.0000, 0)
INSERT [dbo].[CT_HOADONDV] ([ID_HoaDonDV], [ID_Hang], [SoLuong], [DonGia], [ThanhTien], [Deleted]) VALUES (68, 2, 2, 12.0000, 24.0000, 0)
INSERT [dbo].[CT_HOADONDV] ([ID_HoaDonDV], [ID_Hang], [SoLuong], [DonGia], [ThanhTien], [Deleted]) VALUES (68, 12, 3, 15.0000, 45.0000, 0)
INSERT [dbo].[CT_HOADONDV] ([ID_HoaDonDV], [ID_Hang], [SoLuong], [DonGia], [ThanhTien], [Deleted]) VALUES (69, 10, 3, 20.0000, 60.0000, 0)
INSERT [dbo].[CT_HOADONDV] ([ID_HoaDonDV], [ID_Hang], [SoLuong], [DonGia], [ThanhTien], [Deleted]) VALUES (69, 14, 2, 15.0000, 30.0000, 0)
INSERT [dbo].[CT_HOADONDV] ([ID_HoaDonDV], [ID_Hang], [SoLuong], [DonGia], [ThanhTien], [Deleted]) VALUES (70, 15, 6, 15.0000, 90.0000, 0)
INSERT [dbo].[CT_HOADONDV] ([ID_HoaDonDV], [ID_Hang], [SoLuong], [DonGia], [ThanhTien], [Deleted]) VALUES (71, 13, 4, 10.0000, 40.0000, 0)
INSERT [dbo].[CT_HOADONDV] ([ID_HoaDonDV], [ID_Hang], [SoLuong], [DonGia], [ThanhTien], [Deleted]) VALUES (72, 13, 4, 10.0000, 40.0000, 0)
INSERT [dbo].[CT_HOADONDV] ([ID_HoaDonDV], [ID_Hang], [SoLuong], [DonGia], [ThanhTien], [Deleted]) VALUES (73, 13, 4, 10.0000, 40.0000, 0)
INSERT [dbo].[CT_HOADONDV] ([ID_HoaDonDV], [ID_Hang], [SoLuong], [DonGia], [ThanhTien], [Deleted]) VALUES (74, 8, 2, 10.0000, 20.0000, 0)
INSERT [dbo].[CT_HOADONDV] ([ID_HoaDonDV], [ID_Hang], [SoLuong], [DonGia], [ThanhTien], [Deleted]) VALUES (75, 16, 5, 15.0000, 75.0000, 0)
/****** Object:  Table [dbo].[CT_HDNHAP]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_HDNHAP](
	[IDHang] [int] NOT NULL,
	[IDHoaDon] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGiaNhap] [money] NOT NULL,
	[ThanhTien] [money] NOT NULL,
	[Deleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_CTHD] PRIMARY KEY CLUSTERED 
(
	[IDHang] ASC,
	[IDHoaDon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (1, 1, 2, 10.0000, 20.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (1, 2, 100, 10.0000, 1000.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (1, 3, 10, 10.0000, 100.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (1, 5, 100, 10.0000, 1000.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (1, 8, 50, 10.0000, 500.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (2, 2, 14, 5.0000, 70.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (2, 3, 1, 5.0000, 5.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (2, 5, 100, 5.0000, 500.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (7, 2, 4, 100.0000, 400.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (7, 3, 100, 10.0000, 1000.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (7, 5, 100, 3.0000, 300.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (7, 9, 14, 10.0000, 140.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (8, 2, 100, 2.0000, 200.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (8, 3, 3, 2.0000, 6.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (8, 5, 100, 4.0000, 400.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (8, 9, 13, 12.0000, 156.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (10, 2, 100, 10.0000, 1000.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (10, 3, 6, 10.0000, 60.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (10, 6, 50, 20.0000, 1000.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (11, 6, 50, 8.0000, 400.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (11, 13, 100, 12.0000, 1200.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (12, 6, 20, 15.0000, 300.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (12, 9, 17, 18.0000, 306.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (13, 11, 100, 5.0000, 500.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (14, 6, 50, 10.0000, 500.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (14, 8, 20, 15.0000, 300.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (15, 7, 30, 16.0000, 480.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (15, 9, 16, 13.0000, 208.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (15, 10, 14, 10.0000, 140.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (16, 7, 20, 12.0000, 240.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (16, 8, 10, 8.0000, 80.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (16, 12, 20, 12.0000, 240.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (17, 7, 20, 20.0000, 400.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (17, 9, 20, 18.0000, 360.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (18, 7, 30, 16.0000, 480.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (19, 8, 20, 3.0000, 60.0000, 0)
INSERT [dbo].[CT_HDNHAP] ([IDHang], [IDHoaDon], [SoLuong], [DonGiaNhap], [ThanhTien], [Deleted]) VALUES (19, 10, 15, 8.0000, 120.0000, 0)
/****** Object:  Table [dbo].[CT_BCTONKHO]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_BCTONKHO](
	[ID_BCTonKho] [int] NOT NULL,
	[ID_Hang] [int] NOT NULL,
	[TonDau] [int] NOT NULL,
	[SuDung] [int] NOT NULL,
	[TonCuoi] [int] NOT NULL,
	[SoLuongNhap] [int] NOT NULL,
 CONSTRAINT [PK_CT_BCTONKHO] PRIMARY KEY CLUSTERED 
(
	[ID_BCTonKho] ASC,
	[ID_Hang] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 1, 0, 0, 0, 150)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 2, 0, 2, 0, 14)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 7, 0, 0, 0, 18)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 8, 0, 2, 0, 113)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 10, 0, 3, 0, 150)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 11, 0, 0, 0, 50)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 12, 0, 3, 0, 37)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 13, 0, 16, 0, 0)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 14, 0, 2, 0, 70)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 15, 0, 6, 0, 60)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 16, 0, 5, 0, 30)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 17, 0, 0, 0, 40)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 18, 0, 0, 0, 30)
INSERT [dbo].[CT_BCTONKHO] ([ID_BCTonKho], [ID_Hang], [TonDau], [SuDung], [TonCuoi], [SoLuongNhap]) VALUES (5, 19, 0, 0, 0, 35)
/****** Object:  Table [dbo].[BCTONKHO]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BCTONKHO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Thang] [datetime] NOT NULL,
 CONSTRAINT [PK_BCTONKHO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BCTONKHO] ON
INSERT [dbo].[BCTONKHO] ([ID], [Thang]) VALUES (5, CAST(0x0000A6EE00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[BCTONKHO] OFF
/****** Object:  Table [dbo].[BCDOANHTHU]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BCDOANHTHU](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [datetime] NOT NULL,
	[DoanhThu] [money] NOT NULL,
	[ChiPhi] [money] NOT NULL,
	[Thang] [datetime] NOT NULL,
 CONSTRAINT [PK_BCDOANHTHU] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THAMSO]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THAMSO](
	[Name] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](500) NULL,
	[Deleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_THAMSO] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[THAMSO] ([Name], [Value], [Deleted]) VALUES (N'ChuKy', N'7', 1)
INSERT [dbo].[THAMSO] ([Name], [Value], [Deleted]) VALUES (N'GioiHanDatHang', N'3', 1)
INSERT [dbo].[THAMSO] ([Name], [Value], [Deleted]) VALUES (N'GioNgayDem', N'18:00:00', 0)
INSERT [dbo].[THAMSO] ([Name], [Value], [Deleted]) VALUES (N'TienPhat', N'100', 1)
INSERT [dbo].[THAMSO] ([Name], [Value], [Deleted]) VALUES (N'WarningNum', N'3', 0)
/****** Object:  Table [dbo].[PHONG]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nchar](10) NULL,
	[StatusID] [int] NULL,
	[TGStart] [datetime] NULL,
	[IdLoaiPhong] [int] NOT NULL,
	[Deleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_PHONG_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PHONG] ON
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (1, N'C1        ', 1, NULL, 1, 0)
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (4, N'C2        ', 1, NULL, 1, 1)
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (5, N'C3        ', 1, NULL, 1, 0)
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (6, N'C4        ', 1, NULL, 1, 0)
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (7, N'C5        ', 1, NULL, 1, 0)
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (8, N'C6        ', 1, NULL, 2, 0)
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (9, N'C7        ', 1, NULL, 2, 0)
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (10, N'C8        ', 1, NULL, 1, 0)
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (11, N'C9        ', 1, NULL, 1, 0)
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (12, N'C10       ', 1, NULL, 2, 0)
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (13, N'P1        ', 1, NULL, 2, 0)
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (14, N'P2        ', 1, NULL, 2, 0)
INSERT [dbo].[PHONG] ([ID], [Ten], [StatusID], [TGStart], [IdLoaiPhong], [Deleted]) VALUES (15, N'x         ', 1, NULL, 2, 0)
SET IDENTITY_INSERT [dbo].[PHONG] OFF
/****** Object:  Table [dbo].[PHIEUCHI]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUCHI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [datetime] NOT NULL,
	[NoiDung] [nvarchar](500) NOT NULL,
	[TongTien] [money] NOT NULL,
	[GhiChu] [nvarchar](500) NULL,
	[Deleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_PHIEUCHI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PHIEUCHI] ON
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (1, CAST(0x0000A6CF00000000 AS DateTime), N'Tiền điện', 300.0000, N'none', 0)
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (2, CAST(0x0000A6D300000000 AS DateTime), N'Tiền nước ', 200.0000, N'none', 0)
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (3, CAST(0x0000A6E800000000 AS DateTime), N'Tiền sửa mic', 20.0000, N'none', 0)
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (4, CAST(0x0000A70700000000 AS DateTime), N'Bể ly', 15.0000, N'jh', 0)
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (5, CAST(0x0000A67800000000 AS DateTime), N'Ma', 1000000.0000, N'none', 1)
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (6, CAST(0x0000A43900000000 AS DateTime), N'Sửa mái hiên', 100.0000, N'', 0)
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (7, CAST(0x0000A5BF00000000 AS DateTime), N'Mua cửa mới', 200.0000, NULL, 0)
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (8, CAST(0x0000A6EE00000000 AS DateTime), N'Thưởng tết', 500000.0000, NULL, 0)
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (10, CAST(0x0000A5A200000000 AS DateTime), N'Lương nhân viên', 10000.0000, NULL, 0)
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (11, CAST(0x0000A2CD00000000 AS DateTime), N'Xây thêm phòng', 10000.0000, NULL, 0)
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (12, CAST(0x0000A47800000000 AS DateTime), N'Quảng cáo', 2000.0000, NULL, 0)
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (13, CAST(0x0000A2C700000000 AS DateTime), N'Thưởng', 3000.0000, NULL, 0)
INSERT [dbo].[PHIEUCHI] ([ID], [NgayLap], [NoiDung], [TongTien], [GhiChu], [Deleted]) VALUES (14, CAST(0x0000A6F100000000 AS DateTime), N'sdf', 100.0000, N'0', 1)
SET IDENTITY_INSERT [dbo].[PHIEUCHI] OFF
/****** Object:  Table [dbo].[NHOMQUYEN]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOMQUYEN](
	[MaNhomQuyen] [int] IDENTITY(1,1) NOT NULL,
	[TenNhomQuyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_NHOMQUYEN] PRIMARY KEY CLUSTERED 
(
	[MaNhomQuyen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[NHOMQUYEN] ON
INSERT [dbo].[NHOMQUYEN] ([MaNhomQuyen], [TenNhomQuyen]) VALUES (1, N'admin')
INSERT [dbo].[NHOMQUYEN] ([MaNhomQuyen], [TenNhomQuyen]) VALUES (2, N'user')
SET IDENTITY_INSERT [dbo].[NHOMQUYEN] OFF
/****** Object:  Table [dbo].[NGUOIDUNG]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUOIDUNG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[SoDT] [nvarchar](50) NULL,
	[MaNhomQuyen] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[NGUOIDUNG] ON
INSERT [dbo].[NGUOIDUNG] ([ID], [MaDangNhap], [MatKhau], [HoTen], [Email], [SoDT], [MaNhomQuyen]) VALUES (1, N'3tm', N'3tm', NULL, NULL, NULL, 1)
INSERT [dbo].[NGUOIDUNG] ([ID], [MaDangNhap], [MatKhau], [HoTen], [Email], [SoDT], [MaNhomQuyen]) VALUES (2, N'toan', N'3tm', N'', N'', N'', 2)
INSERT [dbo].[NGUOIDUNG] ([ID], [MaDangNhap], [MatKhau], [HoTen], [Email], [SoDT], [MaNhomQuyen]) VALUES (3, N'minh', N'3tm', N'minh', NULL, NULL, 2)
INSERT [dbo].[NGUOIDUNG] ([ID], [MaDangNhap], [MatKhau], [HoTen], [Email], [SoDT], [MaNhomQuyen]) VALUES (4, N'tien', N'3tm', NULL, NULL, NULL, 2)
INSERT [dbo].[NGUOIDUNG] ([ID], [MaDangNhap], [MatKhau], [HoTen], [Email], [SoDT], [MaNhomQuyen]) VALUES (5, N'thao', N'3tm', NULL, NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[NGUOIDUNG] OFF
/****** Object:  Table [dbo].[LOAIPHONG]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIPHONG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[GiaNgay] [money] NULL,
	[GiaDem] [money] NULL,
	[SoLuong] [int] NULL,
	[Deleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_LOAIPHONG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LOAIPHONG] ON
INSERT [dbo].[LOAIPHONG] ([ID], [Ten], [GiaNgay], [GiaDem], [SoLuong], [Deleted]) VALUES (1, N'Tiêu chuẩn', 150.0000, 200.0000, NULL, 0)
INSERT [dbo].[LOAIPHONG] ([ID], [Ten], [GiaNgay], [GiaDem], [SoLuong], [Deleted]) VALUES (2, N'VIP', 200.0000, 300.0000, NULL, 0)
SET IDENTITY_INSERT [dbo].[LOAIPHONG] OFF
/****** Object:  Table [dbo].[HOADONNHAP]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADONNHAP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[TongTien] [money] NOT NULL,
	[Deleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_HOADONNHAP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[HOADONNHAP] ON
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (1, CAST(0x0000A6E900000000 AS DateTime), 20.0000, 0)
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (2, CAST(0x0000A6F000000000 AS DateTime), 0.0000, 0)
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (3, CAST(0x0000A6F200000000 AS DateTime), 1171.0000, 1)
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (4, CAST(0x0000A6F100000000 AS DateTime), 0.0000, 1)
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (5, CAST(0x0000A6ED00000000 AS DateTime), 2380.0000, 0)
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (6, CAST(0x0000A6EE00000000 AS DateTime), 2200.0000, 0)
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (7, CAST(0x0000A6EF00000000 AS DateTime), 1600.0000, 0)
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (8, CAST(0x0000A6F000000000 AS DateTime), 940.0000, 0)
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (9, CAST(0x0000A6F100000000 AS DateTime), 1170.0000, 0)
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (10, CAST(0x0000A6F200000000 AS DateTime), 260.0000, 0)
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (11, CAST(0x0000A6EA00000000 AS DateTime), 500.0000, 0)
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (12, CAST(0x0000A6E700000000 AS DateTime), 240.0000, 0)
INSERT [dbo].[HOADONNHAP] ([ID], [NgayNhap], [TongTien], [Deleted]) VALUES (13, CAST(0x0000A6DA00000000 AS DateTime), 1200.0000, 0)
SET IDENTITY_INSERT [dbo].[HOADONNHAP] OFF
/****** Object:  Table [dbo].[HOADONDV]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADONDV](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Phong] [int] NOT NULL,
	[NgayGioLap] [datetime] NOT NULL,
	[SoGio] [float] NULL,
	[TenKH] [nchar](50) NULL,
	[TongTien] [money] NOT NULL,
	[TienPhong] [money] NULL,
	[Deleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_HOADONDV_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[HOADONDV] ON
INSERT [dbo].[HOADONDV] ([ID], [ID_Phong], [NgayGioLap], [SoGio], [TenKH], [TongTien], [TienPhong], [Deleted]) VALUES (67, 1, CAST(0x0000A6EE016D76FC AS DateTime), 1.0486531835555555, N'                                                  ', 250.0000, 210.0000, 0)
INSERT [dbo].[HOADONDV] ([ID], [ID_Phong], [NgayGioLap], [SoGio], [TenKH], [TongTien], [TienPhong], [Deleted]) VALUES (68, 5, CAST(0x0000A6EF016D9C7C AS DateTime), 2.0413569224444443, N'                                                  ', 477.0000, 408.0000, 0)
INSERT [dbo].[HOADONDV] ([ID], [ID_Phong], [NgayGioLap], [SoGio], [TenKH], [TongTien], [TienPhong], [Deleted]) VALUES (69, 14, CAST(0x0000A6F0016DBD4C AS DateTime), 3.0372397640833331, N'                                                  ', 1001.0000, 911.0000, 0)
INSERT [dbo].[HOADONDV] ([ID], [ID_Phong], [NgayGioLap], [SoGio], [TenKH], [TongTien], [TienPhong], [Deleted]) VALUES (70, 8, CAST(0x0000A6F1016DF58C AS DateTime), 2.0222209572222223, N'                                                  ', 697.0000, 607.0000, 0)
INSERT [dbo].[HOADONDV] ([ID], [ID_Phong], [NgayGioLap], [SoGio], [TenKH], [TongTien], [TienPhong], [Deleted]) VALUES (71, 1, CAST(0x0000A6EE016D76FC AS DateTime), 1.0486531835555555, N'                                                  ', 250.0000, 210.0000, 0)
INSERT [dbo].[HOADONDV] ([ID], [ID_Phong], [NgayGioLap], [SoGio], [TenKH], [TongTien], [TienPhong], [Deleted]) VALUES (72, 1, CAST(0x0000A6EE016D76FC AS DateTime), 1.0486531835555555, N'                                                  ', 250.0000, 210.0000, 0)
INSERT [dbo].[HOADONDV] ([ID], [ID_Phong], [NgayGioLap], [SoGio], [TenKH], [TongTien], [TienPhong], [Deleted]) VALUES (73, 1, CAST(0x0000A6EE016D76FC AS DateTime), 1.0486531835555555, N'                                                  ', 250.0000, 210.0000, 0)
INSERT [dbo].[HOADONDV] ([ID], [ID_Phong], [NgayGioLap], [SoGio], [TenKH], [TongTien], [TienPhong], [Deleted]) VALUES (74, 1, CAST(0x0000A6F2017305A4 AS DateTime), 0.0027887588055555555, N'                                                  ', 21.0000, 1.0000, 0)
INSERT [dbo].[HOADONDV] ([ID], [ID_Phong], [NgayGioLap], [SoGio], [TenKH], [TongTien], [TienPhong], [Deleted]) VALUES (75, 1, CAST(0x0000A6F20176AA74 AS DateTime), 0.013773580444444444, N'                                                  ', 78.0000, 3.0000, 0)
SET IDENTITY_INSERT [dbo].[HOADONDV] OFF
/****** Object:  Table [dbo].[HANG]    Script Date: 01/06/2017 00:10:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HANG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](200) NOT NULL,
	[DonGiaNhap] [money] NOT NULL,
	[DonGiaBan] [money] NOT NULL,
	[SLTon] [int] NOT NULL,
	[DonVi] [nvarchar](50) NULL,
	[Requested] [int] NOT NULL,
	[Deleted] [tinyint] NOT NULL,
 CONSTRAINT [PK_HANG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[HANG] ON
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (1, N'Bia', 10.0000, 12.0000, 100, N'lonf', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (2, N'Tra Dao', 9.0000, 12.0000, 0, N'ly', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (7, N'Nước suối', 4.0000, 10.0000, 100, N'chai', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (8, N'Bánh Snack', 5.0000, 10.0000, 98, N'bịch', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (10, N'Trái cây', 10.0000, 20.0000, 97, N'đĩa', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (11, N'Pepsi', 5.0000, 13.0000, 100, N'chai', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (12, N'Nước cam', 8.0000, 15.0000, 97, N'ly', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (13, N'Trà đá', 3.0000, 10.0000, 96, N'ly', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (14, N'Sữa', 5.0000, 15.0000, 98, N'ly', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (15, N'Sinh tố', 5.0000, 15.0000, 94, N'ly', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (16, N'Bánh bông lan', 5.0000, 15.0000, 95, N'cái', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (17, N'Nước ép nho', 10.0000, 20.0000, 100, N'ly', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (18, N'Nước ép cam', 10.0000, 20.0000, 100, N'ly', 0, 0)
INSERT [dbo].[HANG] ([ID], [Ten], [DonGiaNhap], [DonGiaBan], [SLTon], [DonVi], [Requested], [Deleted]) VALUES (19, N'Mì gói', 5.0000, 15.0000, 1, N'tô', 0, 0)
SET IDENTITY_INSERT [dbo].[HANG] OFF
/****** Object:  StoredProcedure [dbo].[getRP]    Script Date: 01/06/2017 00:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getRP]
(
	@dateFrom datetime,
	@dateTo datetime
)
AS
	SET NOCOUNT ON;
SELECT hd.ID, ph.Ten, hd.NgayGioLap, hd.SoGio, hd.TenKH, hd.TienPhong, hd.TongTien 
	from HOADONDV as hd join PHONG as ph on hd.ID_Phong = ph.ID
	where hd.NgayGioLap>= @dateFrom and hd.NgayGioLap<= @dateTo
GO
/****** Object:  StoredProcedure [dbo].[GetListNguoiDung]    Script Date: 01/06/2017 00:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetListNguoiDung] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT nd.ID, nd.MaDangNhap, nd.MatKhau, nd.HoTen, nd.Email, nd.SoDT, nd.MaNhomQuyen, nq.TenNhomQuyen from NGUOIDUNG nd join NHOMQUYEN nq on nd.MaNhomQuyen = nq.MaNhomQuyen
END
GO
/****** Object:  StoredProcedure [dbo].[GetListHangHoaChart]    Script Date: 01/06/2017 00:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetListHangHoaChart]
	-- Add the parameters for the stored procedure here
	@dateFrom datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT h.Ten, count(h.Ten) as soluong
	from HANG as h join (select cthd.ID_Hang, cthd.Deleted
						from CT_HOADONDV as cthd join HOADONDV as hd on cthd.ID_HoaDonDV = hd.ID
						where CONVERT(date, hd.NgayGioLap)= CONVERT(date, @dateFrom)) as  ctx on h.ID= ctx.ID_Hang
	where h.Deleted=0 and ctx.Deleted=0
	group by h.Ten

END
GO
/****** Object:  StoredProcedure [dbo].[GetListBCTonKho]    Script Date: 01/06/2017 00:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetListBCTonKho]
	-- Add the parameters for the stored procedure here
	@month datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @dayStart datetime, @dayEnd datetime
	set @dayStart = (DATEADD(MONTH, DATEDIFF(MONTH, 0, @month), 0))
	set @dayEnd = (DATEADD(MONTH, DATEDIFF(MONTH, -1, @month), -1))

    -- Insert statements for procedure here
	select h.ID, h.Ten, toncuoi.TonCuoi as tondau, nhap.slnhap as soluongnhap, ban.slban as soluongban, (toncuoi.TonCuoi+nhap.slnhap-ban.slban) as toncuoi
	from HANG h left join (select cttk.ID_Hang, cttk.TonCuoi 
						from CT_BCTONKHO cttk join BCTONKHO bc on cttk.ID_BCTonKho = bc.ID
						where bc.Thang = (select max(Thang) from BCTONKHO)) toncuoi
				on h.ID = toncuoi.ID_Hang
				left join (select cthdn.IDHang, sum(cthdn.SoLuong) as slnhap
						from CT_HDNHAP cthdn join HOADONNHAP hdn on cthdn.IDHoaDon = hdn.ID
						where hdn.NgayNhap>=@dayStart and hdn.NgayNhap<= @dayEnd and hdn.Deleted = 0
						group by cthdn.IDHang) nhap
				on h.ID = nhap.IDHang
				left join (select cthddv.ID_Hang, sum(cthddv.SoLuong) as slban
						from CT_HOADONDV cthddv join HOADONDV hddv on cthddv.ID_HoaDonDV = hddv.ID
						where hddv.NgayGioLap>=@dayStart and hddv.NgayGioLap<= @dayEnd and hddv.Deleted = 0
						group by cthddv.ID_Hang) ban
				on h.ID = ban.ID_Hang
	where h.Deleted = 0

END
GO
/****** Object:  StoredProcedure [dbo].[GetListBCDoanhThu]    Script Date: 01/06/2017 00:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GetListBCDoanhThu]
	-- Add the parameters for the stored procedure here
	@dateFrom datetime,
	@dateTo datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT hd.ID, ph.Ten, hd.NgayGioLap, hd.SoGio, hd.TenKH, hd.TienPhong, hd.TongTien 
	from HOADONDV as hd join PHONG as ph on hd.ID_Phong = ph.ID
	where hd.NgayGioLap>= @dateFrom and hd.NgayGioLap<= @dateTo
END
GO
/****** Object:  Default [DF_DATPHONG_Deleted]    Script Date: 01/06/2017 00:10:33 ******/
ALTER TABLE [dbo].[DATPHONG] ADD  CONSTRAINT [DF_DATPHONG_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_CT_HOADONDV_Deleted]    Script Date: 01/06/2017 00:10:33 ******/
ALTER TABLE [dbo].[CT_HOADONDV] ADD  CONSTRAINT [DF_CT_HOADONDV_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_CT_HDNHAP_Deleted]    Script Date: 01/06/2017 00:10:33 ******/
ALTER TABLE [dbo].[CT_HDNHAP] ADD  CONSTRAINT [DF_CT_HDNHAP_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_THAMSO_Deleted]    Script Date: 01/06/2017 00:10:33 ******/
ALTER TABLE [dbo].[THAMSO] ADD  CONSTRAINT [DF_THAMSO_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_PHONG_Deleted]    Script Date: 01/06/2017 00:10:33 ******/
ALTER TABLE [dbo].[PHONG] ADD  CONSTRAINT [DF_PHONG_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_PHIEUCHI_Deleted]    Script Date: 01/06/2017 00:10:33 ******/
ALTER TABLE [dbo].[PHIEUCHI] ADD  CONSTRAINT [DF_PHIEUCHI_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_LOAIPHONG_Deleted]    Script Date: 01/06/2017 00:10:33 ******/
ALTER TABLE [dbo].[LOAIPHONG] ADD  CONSTRAINT [DF_LOAIPHONG_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_HOADONNHAP_Deleted]    Script Date: 01/06/2017 00:10:33 ******/
ALTER TABLE [dbo].[HOADONNHAP] ADD  CONSTRAINT [DF_HOADONNHAP_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_HOADONDV_Deleted]    Script Date: 01/06/2017 00:10:33 ******/
ALTER TABLE [dbo].[HOADONDV] ADD  CONSTRAINT [DF_HOADONDV_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_HANG_Requested]    Script Date: 01/06/2017 00:10:33 ******/
ALTER TABLE [dbo].[HANG] ADD  CONSTRAINT [DF_HANG_Requested]  DEFAULT ((0)) FOR [Requested]
GO
/****** Object:  Default [DF_HANG_Deleted]    Script Date: 01/06/2017 00:10:33 ******/
ALTER TABLE [dbo].[HANG] ADD  CONSTRAINT [DF_HANG_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
