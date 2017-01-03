USE [QLPhongKaraoke]
GO
/****** Object:  Table [dbo].[THAMSO]    Script Date: 12/26/2016 21:48:10 ******/
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
/****** Object:  Table [dbo].[PHONG]    Script Date: 12/26/2016 21:48:10 ******/
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
/****** Object:  Table [dbo].[PHIEUCHI]    Script Date: 12/26/2016 21:48:10 ******/
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
/****** Object:  Table [dbo].[LOAIPHONG]    Script Date: 12/26/2016 21:48:10 ******/
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
/****** Object:  Table [dbo].[HOADONNHAP]    Script Date: 12/26/2016 21:48:10 ******/
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
/****** Object:  Table [dbo].[HOADONDV]    Script Date: 12/26/2016 21:48:10 ******/
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
/****** Object:  Table [dbo].[HANG]    Script Date: 12/26/2016 21:48:10 ******/
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
/****** Object:  Table [dbo].[DATPHONG]    Script Date: 12/26/2016 21:48:10 ******/
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
/****** Object:  Table [dbo].[CT_HOADONDV]    Script Date: 12/26/2016 21:48:10 ******/
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
/****** Object:  Table [dbo].[CT_HDNHAP]    Script Date: 12/26/2016 21:48:10 ******/
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
/****** Object:  Table [dbo].[CT_BCTONKHO]    Script Date: 12/26/2016 21:48:10 ******/
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
 CONSTRAINT [PK_CT_BCTONKHO] PRIMARY KEY CLUSTERED 
(
	[ID_BCTonKho] ASC,
	[ID_Hang] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BCTONKHO]    Script Date: 12/26/2016 21:48:10 ******/
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
/****** Object:  Table [dbo].[BCDOANHTHU]    Script Date: 12/26/2016 21:48:10 ******/
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
/****** Object:  Default [DF_CT_HDNHAP_Deleted]    Script Date: 12/26/2016 21:48:10 ******/
ALTER TABLE [dbo].[CT_HDNHAP] ADD  CONSTRAINT [DF_CT_HDNHAP_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_CT_HOADONDV_Deleted]    Script Date: 12/26/2016 21:48:10 ******/
ALTER TABLE [dbo].[CT_HOADONDV] ADD  CONSTRAINT [DF_CT_HOADONDV_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_DATPHONG_Deleted]    Script Date: 12/26/2016 21:48:10 ******/
ALTER TABLE [dbo].[DATPHONG] ADD  CONSTRAINT [DF_DATPHONG_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_HANG_Requested]    Script Date: 12/26/2016 21:48:10 ******/
ALTER TABLE [dbo].[HANG] ADD  CONSTRAINT [DF_HANG_Requested]  DEFAULT ((0)) FOR [Requested]
GO
/****** Object:  Default [DF_HANG_Deleted]    Script Date: 12/26/2016 21:48:10 ******/
ALTER TABLE [dbo].[HANG] ADD  CONSTRAINT [DF_HANG_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_HOADONDV_Deleted]    Script Date: 12/26/2016 21:48:10 ******/
ALTER TABLE [dbo].[HOADONDV] ADD  CONSTRAINT [DF_HOADONDV_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_HOADONNHAP_Deleted]    Script Date: 12/26/2016 21:48:10 ******/
ALTER TABLE [dbo].[HOADONNHAP] ADD  CONSTRAINT [DF_HOADONNHAP_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_LOAIPHONG_Deleted]    Script Date: 12/26/2016 21:48:10 ******/
ALTER TABLE [dbo].[LOAIPHONG] ADD  CONSTRAINT [DF_LOAIPHONG_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_PHIEUCHI_Deleted]    Script Date: 12/26/2016 21:48:10 ******/
ALTER TABLE [dbo].[PHIEUCHI] ADD  CONSTRAINT [DF_PHIEUCHI_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_PHONG_Deleted]    Script Date: 12/26/2016 21:48:10 ******/
ALTER TABLE [dbo].[PHONG] ADD  CONSTRAINT [DF_PHONG_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  Default [DF_THAMSO_Deleted]    Script Date: 12/26/2016 21:48:10 ******/
ALTER TABLE [dbo].[THAMSO] ADD  CONSTRAINT [DF_THAMSO_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
