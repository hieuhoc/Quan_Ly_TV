USE [master]
GO
/****** Object:  Database [QL_ThuVien]    Script Date: 23/11/2016 11:07:07 CH ******/
CREATE DATABASE [QL_ThuVien]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_ThuVien', FILENAME = N'D:\CSDL\QL_ThuVien.mdf' , SIZE = 5248KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_ThuVien_log', FILENAME = N'D:\CSDL\QL_ThuVien_log.LDF' , SIZE = 5248KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_ThuVien] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_ThuVien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_ThuVien] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_ThuVien] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_ThuVien] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_ThuVien] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_ThuVien] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_ThuVien] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QL_ThuVien] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QL_ThuVien] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_ThuVien] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_ThuVien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_ThuVien] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_ThuVien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_ThuVien] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_ThuVien] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_ThuVien] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_ThuVien] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QL_ThuVien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_ThuVien] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_ThuVien] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_ThuVien] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_ThuVien] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_ThuVien] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_ThuVien] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_ThuVien] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_ThuVien] SET  MULTI_USER 
GO
ALTER DATABASE [QL_ThuVien] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_ThuVien] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_ThuVien] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_ThuVien] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QL_ThuVien]
GO
/****** Object:  StoredProcedure [dbo].[ADDBanDoc]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[ADDBanDoc] (@HoTen nvarchar(50), @GioiTinh nvarchar(5),@NgaySinh date, @CMND nvarchar(15), @lop nvarchar(50),@DiaChi nvarchar(50),@Email nvarchar(50),@DienThoai nvarchar(20))
AS 
BEGIN
	DECLARE @MaBD nchar(10)
	DECLARE @MaLop nvarchar(10)
	DECLARE @sott int
	DECLARE contro CURSOR FORWARD_ONLY FOR SELECT MaBD FROM BanDoc
	SET @sott = 0
	select @MaLop=Malop from Lop where TenLop=@lop
	OPEN contro
	FETCH NEXT FROM contro INTO @MaBD
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF((CAST(right(@MaBD, 8) AS int) - @sott) = 1)
		BEGIN
			SET @sott = CAST(right(@MaBD, 8) AS int)
		END
	ELSE BREAK
	FETCH NEXT FROM contro INTO @MaBD
END

DECLARE @cdai int
DECLARE @i int
SET @MaBD = CAST((@sott + 1) as nchar(8))
SET @cdai = LEN(@MaBD)
SET @i = 1
while ( @i <= 8 - @cdai)
BEGIN
	SET @MaBD = '0' + @MaBD
	SET @i = @i + 1
END
SET @MaBD = 'BD' + @MaBD

INSERT INTO BanDoc values ( @MaBD,@HoTen,@GioiTinh,@NgaySinh,@CMND,@MaLop,@DiaChi,@Email,@DienThoai)
SELECT @MaBD
CLOSE contro
DEALLOCATE contro
END

GO
/****** Object:  StoredProcedure [dbo].[AddCTPM]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[AddCTPM]
(
	@MaPM nvarchar(10),
	@GTCB nvarchar(10),
	@NgayMuon date ,
	@NgayTra date ,
	@NgayDangky date ,
	@NgayLay date ,
	@GhiChu nvarchar(max)
)
as
begin
	declare @i int
	select @i=a.SoLuong from TaiLieu a,GiaTriCaBiet b where a.MaTL=b.MaTL and b.GTCB=@GTCB
	if @i>0
	begin
		insert into ChitietPhieuMuon(MaPM,GTCB,NgayMuon,NgayTra,NgayDangky,NgayLay,GhiChu)
		values (@MaPM,@GTCB,@NgayMuon,@NgayTra,@NgayDangky,@NgayLay,@GhiChu)
		update GiaTriCaBiet set TrangThai=N'Đã mượn' where GTCB=@GTCB
		declare @MaTL nvarchar(10)
		select @MaTL=MaTL from GiaTriCaBiet where GTCB=@GTCB
		update TaiLieu set SoLuong=SoLuong-1 where MaTL=@MaTL
	end
	else raiserror('Hết sách',18,1)
end




GO
/****** Object:  StoredProcedure [dbo].[AddPM]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddPM]
(
	@MaBD nvarchar(10)
)
as
begin
	declare @MaPM nvarchar(10)
	set @MaPM= dbo.AutoMaPhieuMuon()
	insert into PhieuMuon(MaPM,MaBD,TrangThai)
	values (@MaPM,@MaBD,1)
end




GO
/****** Object:  StoredProcedure [dbo].[ADDTaiLieu]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ADDTaiLieu] (@TacGia nvarchar(50), @NhanDe nvarchar(50),@SoLuong int, @DoMat int, @NgonNgu nvarchar(20),@MaTheLoai nvarchar(10),@MaNXB nvarchar(10))
AS 
BEGIN
	DECLARE @MaTL nchar(10)
	DECLARE @sott int
	DECLARE contro CURSOR FORWARD_ONLY FOR SELECT MaTL FROM TaiLieu
	SET @sott = 0
	
	OPEN contro
	FETCH NEXT FROM contro INTO @MaTL
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF((CAST(right(@MaTL, 8) AS int) - @sott) = 1)
		BEGIN
			SET @sott = CAST(right(@MaTL, 8) AS int)
		END
	ELSE BREAK
	FETCH NEXT FROM contro INTO @MaTL
END

DECLARE @cdai int
DECLARE @i int
SET @MaTL = CAST((@sott + 1) as nchar(8))
SET @cdai = LEN(@MaTL)
SET @i = 1
while ( @i <= 8 - @cdai)
BEGIN
	SET @MaTL = '0' + @MaTL
	SET @i = @i + 1
END
SET @MaTL = 'TL' + @MaTL

INSERT INTO TaiLieu values ( @MaTL,@TacGia,@NhanDe,@SoLuong,@DoMat,@NgonNgu,@MaTheLoai,@MaNXB)
SELECT @MaTL
CLOSE contro
DEALLOCATE contro
END




GO
/****** Object:  StoredProcedure [dbo].[DeletePM]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[DeletePM]
(
	@MaBD nvarchar(10),
	@MaPM nvarchar(10)
)
as
begin
	update PhieuMuon set TrangThai=3 where MaBD=@MaBD and MaPM=@MaPM
end





GO
/****** Object:  StoredProcedure [dbo].[OutputTable]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[OutputTable]
(
	@code int 
)
as
begin
	if @code=1
		select * from TaiKhoan
	else select * from BanDoc
end




GO
/****** Object:  StoredProcedure [dbo].[Sua_sach]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sua_sach] (@matl nvarchar(10), @tacgia nvarchar(50), @nhande nvarchar(50), @soluong int, @domat int, @ngonngu nvarchar(20), @sotrang int, @taiban int, @trangthai nvarchar(50), @ngaynhap date, @maTloai nvarchar(10), @manxb nvarchar(10))
 as
 begin
	update Tailieu set TacGia = @tacgia, NhanDe = @nhande, SoLuong = @soluong, DoMat =@domat , NgonNgu = @ngonngu, MaTheLoai = @maTloai, MaNXB = @manxb, SoTrang = @sotrang,TaiBan =@taiban,Trangthai = @trangthai,NgayNhap = @ngaynhap where matl = @matl
 end

GO
/****** Object:  StoredProcedure [dbo].[Sua_TTMT]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sua_TTMT] (@mapm nvarchar(10), @bandoc nvarchar(50), @nhande nvarchar(50), @trangthai int, @ngaynhap date,@ngaytra date, @ghichu nvarchar(max))
 as
 begin
	if(@trangthai = 0) update ChitietPhieuMuon set MaTL = @nhande, NgayMuon = @ngaynhap, NgayTra = null, GhiChu = @ghichu where MaPM = @mapm
	else update ChitietPhieuMuon set MaTL = @nhande, NgayMuon = @ngaynhap, NgayTra = @ngaytra, GhiChu = @ghichu where MaPM = @mapm
	update PhieuMuon set MaBD = @bandoc, TrangThai = @trangthai where MaPM = @mapm
 end


GO
/****** Object:  StoredProcedure [dbo].[SuaBanDoc]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SuaBanDoc] (@MaBD nchar(10), @HoTen nvarchar(50), @GioiTinh nvarchar(5),
						 @NgaySinh date, @CMND nvarchar(15), @lop nvarchar(10), @DiaChi nvarchar(50),@Email nvarchar(50),@DienThoai nvarchar(20))
AS
BEGIN 
	declare @malop nvarchar(10)
	select @malop=malop from Lop where TenLop=@lop
	UPDATE BanDoc SET  HoTen = @HoTen, GioiTinh = @GioiTinh,
						NgaySinh = @NgaySinh, CMND=@CMND, MaLop = @malop, DiaChi = @DiaChi, Email=@Email, DienThoai=@DienThoai
						WHERE MaBD=@MaBD
END

GO
/****** Object:  StoredProcedure [dbo].[SuaTaiLieu]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SuaTaiLieu] (@MaTL nchar(10), @TacGia nvarchar(10), @NhanDe nvarchar(50),
						 @SoLuong int, @DoMat int, @NgonNgu nvarchar(20), @MaTheLoai nvarchar(10),@MaNXB nvarchar(10))
AS
BEGIN 
	UPDATE TaiLieu SET  TacGia = @TacGia, NhanDe = @NhanDe,
						SoLuong = @SoLuong, DoMat = @DoMat, NgonNgu = @NgonNgu, MaTheLoai=@MaTheLoai, MaNXB=@MaNXB
						WHERE MaTL=@MaTL
END




GO
/****** Object:  StoredProcedure [dbo].[Them_Sach]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Them_Sach] (@matl nvarchar(10), @tacgia nvarchar(50), @nhande nvarchar(50), @soluong int, @domat int, @ngonngu nvarchar(20), @sotrang int, @taiban int, @trangthai nvarchar(50), @ngaynhap date, @maTloai nvarchar(10), @manxb nvarchar(10))
as
begin
	insert into TaiLieu values(@matl, @tacgia, @nhande, @soluong, @domat, @ngonngu,@maTloai, @manxb, @sotrang, @taiban, @trangthai, @ngaynhap)
end

GO
/****** Object:  StoredProcedure [dbo].[Them_TTMT]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Them_TTMT] (@mapm nvarchar(10), @bandoc nvarchar(50), @nhande nvarchar(50), @trangthai int, @ngaynhap date,@ngaytra date, @ghichu nvarchar(max))
as
begin
	insert into PhieuMuon values(@mapm, @bandoc, @trangthai)
	if(@trangthai = 0) insert into ChitietPhieuMuon values(@mapm, @nhande, @ngaynhap, null, @ghichu)
	else insert into ChitietPhieuMuon values(@mapm, @nhande, @ngaynhap, @ngaytra, @ghichu)
end

GO
/****** Object:  StoredProcedure [dbo].[Xoa_BD]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Xoa_BD](@MaBD nvarchar(10))
AS
BEGIN 
	declare @mapm nchar(10)
	select @mapm=MaPM from PhieuMuon where MaBD=@maBD
	delete from ChitietPhieuMuon where MaPM=@mapm
	delete from PhieuMuon where MaBD=@MaBD
	DELETE FROM BanDoc WHERE MaBD=@MaBD
END



GO
/****** Object:  StoredProcedure [dbo].[Xoa_TL]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Xoa_TL](@MaTL nvarchar(10))
AS
BEGIN 
	DELETE FROM TaiLieu WHERE MaTL=@MaTL
END



GO
/****** Object:  UserDefinedFunction [dbo].[AutoMaPhieuMuon]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create function [dbo].[AutoMaPhieuMuon] ()
returns nvarchar(10)
as
begin
	declare @mapm nvarchar(10)
	declare @i int =(select count(MaPM) from PhieuMuon)+1
	set @mapm='PM'+CONVERT(nvarchar(10),@i)
	return (@mapm)
end




GO
/****** Object:  Table [dbo].[BanDoc]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanDoc](
	[MaBD] [nvarchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[NgaySinh] [date] NULL,
	[CMND] [nvarchar](15) NULL,
	[MaLop] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](20) NULL,
 CONSTRAINT [pk_bd_mabd] PRIMARY KEY CLUSTERED 
(
	[MaBD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChitietPhieuMuon]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChitietPhieuMuon](
	[MaPM] [nvarchar](10) NOT NULL,
	[MaTL] [nvarchar](10) NOT NULL,
	[NgayMuon] [date] NULL,
	[NgayTra] [date] NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [pk_ctpm_mapm_gtcb] PRIMARY KEY CLUSTERED 
(
	[MaPM] ASC,
	[MaTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lop]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[MaLop] [nvarchar](10) NOT NULL,
	[TenLop] [nvarchar](50) NULL,
	[Khoa] [nvarchar](50) NULL,
 CONSTRAINT [pk_lop_malop] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NXB]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NXB](
	[MaNXB] [nvarchar](10) NOT NULL,
	[TenNXB] [nvarchar](50) NULL,
	[QuocGia] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](20) NULL,
 CONSTRAINT [pk_nxb_manxb] PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuMuon]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuMuon](
	[MaPM] [nvarchar](10) NOT NULL,
	[MaBD] [nvarchar](10) NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [pk_pm_mapm] PRIMARY KEY CLUSTERED 
(
	[MaPM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[ID] [nvarchar](20) NOT NULL,
	[MatKhau] [nvarchar](20) NULL,
	[PhanQuyen] [int] NULL,
	[MaBD] [nvarchar](10) NULL,
 CONSTRAINT [pk_tk_username] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiLieu]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiLieu](
	[MaTL] [nvarchar](10) NOT NULL,
	[TacGia] [nvarchar](50) NULL,
	[NhanDe] [nvarchar](50) NULL,
	[SoLuong] [int] NULL,
	[DoMat] [int] NULL,
	[NgonNgu] [nvarchar](20) NULL,
	[MaTheLoai] [nvarchar](10) NULL,
	[MaNXB] [nvarchar](10) NULL,
	[SoTrang] [int] NULL,
	[TaiBan] [int] NULL,
	[TrangThai] [nvarchar](50) NULL,
	[NgayNhap] [date] NULL,
 CONSTRAINT [pk_tailieu_matl] PRIMARY KEY CLUSTERED 
(
	[MaTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 23/11/2016 11:07:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[MaTheLoai] [nvarchar](10) NOT NULL,
	[TenTheLoai] [nvarchar](50) NULL,
 CONSTRAINT [pk_theloai_matheloai] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD00000020', N'jhfgc', N'Nam', CAST(0x223C0B00 AS Date), N'675787', N'L001', N'vfhfhfkj', N'@gmail', N'786785685')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0001', N'Phạm Trọng Hiếu', N'Nam', CAST(0xE51C0B00 AS Date), N'201625579', N'L001', N'Nghệ An', N'gmail', N'1')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0002', N'Hà Đức Hiến', N'Nam', CAST(0xE51C0B00 AS Date), N'201433292', N'L001', N'Ninh Bình', N'gmail', N'2')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0003', N'Bạch Ngọc Hiệp', N'Nam', CAST(0xE51C0B00 AS Date), N'201687852', N'L001', N'Hà Nội', N'gmail', N'3')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0004', N'Phạm Ngọc Anh', N'Nam', CAST(0xE51C0B00 AS Date), N'159753258', N'L001', N'Hải Dương', N'gmail', N'4')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0005', N'Vũ Quốc Tuấn', N'Nam', CAST(0xE51C0B00 AS Date), N'456852159', N'L001', N'Thanh Hóa', N'gmail', N'5')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0006', N'Nguyễn Duy Tùng Khánh', N'Nam', CAST(0xE51C0B00 AS Date), N'753159852', N'L001', N'An Giang', N'gmail', N'6')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0007', N'Phan Trọng Duy', N'Nam', CAST(0xE51C0B00 AS Date), N'159357654', N'L001', N'Thái Nguyên', N'gmail', N'9')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0008', N'Nguyễn Duy Long', N'Nam', CAST(0xE51C0B00 AS Date), N'456951753', N'L001', N'Bắc Ninh', N'gmail', N'8')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0009', N'Nguyễn Hữu Huy', N'Nam', CAST(0xE51C0B00 AS Date), N'159753258', N'L001', N'Sơn Tây', N'gmail', N'10')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0010', N'Doãn Văn Thiều', N'Nam', CAST(0xE51C0B00 AS Date), N'951357624', N'L001', N'Phú Thọ', N'gmail', N'11')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0011', N'Nguyễn Thế Công', N'Nam', CAST(0xE51C0B00 AS Date), N'842675319', N'L001', N'Điện Biên', N'gmail', N'12')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0012', N'Nguyễn Văn Tuấn Anh', N'Nam', CAST(0xE51C0B00 AS Date), N'764123895', N'L001', N'Quảng Ninh', N'gmail', N'13')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0013', N'Lê Hải Sơn', N'Nam', CAST(0xE51C0B00 AS Date), N'627483915', N'L001', N'Ninh Bình', N'gmail', N'14')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0014', N'Nguyễn Thanh Tùng', N'Nam', CAST(0xE51C0B00 AS Date), N'741258963', N'L001', N'Hà Nội', N'gmail', N'15')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0015', N'Hồ Sỹ Việt', N'Nam', CAST(0xE51C0B00 AS Date), N'369852147', N'L001', N'Hải Phòng', N'gmail', N'16')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0016', N'Hà Vũ Thu Trang', N'Nữ', CAST(0xE51C0B00 AS Date), N'321654987', N'L001', N'Thanh Hóa', N'gmail', N'17')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0017', N'Phạm Bích Phương', N'Nữ', CAST(0xE51C0B00 AS Date), N'654321987', N'L001', N'Hà Tĩnh', N'gmail', N'18')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0018', N'Hà Xuân Tùng', N'Nam', CAST(0xE51C0B00 AS Date), N'751953258', N'L001', N'Hòa Bình', N'gmail', N'7')
INSERT [dbo].[BanDoc] ([MaBD], [HoTen], [GioiTinh], [NgaySinh], [CMND], [MaLop], [DiaChi], [Email], [DienThoai]) VALUES (N'BD0019', N'abc', N'Nam', CAST(0xE51C0B00 AS Date), N'214231515', N'L001', N'Thanh Hoá', N'gmail', N'13')
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0001', N'MTL00001', CAST(0x7C390B00 AS Date), CAST(0x1F3C0B00 AS Date), N'gfgfhf')
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0002', N'MTL00002', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0003', N'MTL00003', CAST(0x7C390B00 AS Date), CAST(0x203C0B00 AS Date), N'')
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0004', N'MTL00004', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0005', N'MTL00005', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), N'')
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0006', N'MTL00006', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0007', N'MTL00007', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0008', N'MTL00008', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0009', N'MTL00009', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0010', N'MTL00010', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0011', N'MTL00011', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0012', N'MTL00012', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0013', N'MTL00013', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0014', N'MTL00014', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0015', N'MTL00015', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0016', N'MTL00016', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0017', N'MTL00017', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0018', N'MTL00018', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), NULL)
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0019', N'MTL00019', CAST(0x7C390B00 AS Date), CAST(0x183A0B00 AS Date), N'')
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0020', N'MTL00006', CAST(0xB13A0B00 AS Date), NULL, N'k co gi')
INSERT [dbo].[ChitietPhieuMuon] ([MaPM], [MaTL], [NgayMuon], [NgayTra], [GhiChu]) VALUES (N'PM0021', N'MTL00001', CAST(0x223C0B00 AS Date), CAST(0x223C0B00 AS Date), N'fyjf')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [Khoa]) VALUES (N'L001', N'Tin học ', N'49')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [Khoa]) VALUES (N'L002', N'Thông Tin', N'49')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [Khoa]) VALUES (N'L003', N'Địa Tin Học', N'48')
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [QuocGia], [Email], [DiaChi], [DienThoai]) VALUES (N'NXB001', N'Giáo dục & Đào tạo', N'Việt Nam', N'nxbgddt@gmail.com', N'Hà Nội', N'04111111')
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [QuocGia], [Email], [DiaChi], [DienThoai]) VALUES (N'NXB002', N'Chính trị quốc gia', N'Việt Nam', N'nxbctqg@gmail.com', N'Hà Nội', N'04222222')
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [QuocGia], [Email], [DiaChi], [DienThoai]) VALUES (N'NXB003', N'Khoa học & kỹ thuật', N'Việt Nam', N'nxbkhkt@gmail.com', N'Hà Nội', N'04333333')
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [QuocGia], [Email], [DiaChi], [DienThoai]) VALUES (N'NXB004', N'Sự thật', N'Việt Nam', N'nxbsuthat@gmail.com', N'Hà Nội', N'04444444')
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [QuocGia], [Email], [DiaChi], [DienThoai]) VALUES (N'NXB005', N'Kim Đồng', N'Việt Nam', N'nxbkimdong@gmail.com', N'TP.Hồ Chí Minh', N'04555555')
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [QuocGia], [Email], [DiaChi], [DienThoai]) VALUES (N'NXB006', N'NXB Trẻ', N'Việt Nam', N'nxbtre@gmail.com', N'Hà Nội', N'04666666')
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [QuocGia], [Email], [DiaChi], [DienThoai]) VALUES (N'NXB007', N'First News', N'Anh', N'firstnews@gmail.com', N'Luân Đôn', N'02777777')
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [QuocGia], [Email], [DiaChi], [DienThoai]) VALUES (N'NXB008', N'Văn hóa - Thông tin', N'Việt Nam', N'nxbvhtt@gmail.com', N'Hà Nội', N'04888888')
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [QuocGia], [Email], [DiaChi], [DienThoai]) VALUES (N'NXB009', N'Quân đội nhân dân', N'Việt Nam', N'nxbqdnd@gmail.com', N'Hà Nội', N'04999999')
INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [QuocGia], [Email], [DiaChi], [DienThoai]) VALUES (N'NXB010', N'Văn học', N'Việt Nam', N'nxbvanhoc@gmail.com', N'Hà Nội', N'04101010')
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0001', N'BD0001', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0002', N'BD0002', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0003', N'BD0003', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0004', N'BD0004', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0005', N'BD0005', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0006', N'BD0006', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0007', N'BD0007', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0008', N'BD0008', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0009', N'BD0009', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0010', N'BD0010', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0011', N'BD0011', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0012', N'BD0012', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0013', N'BD0013', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0014', N'BD0014', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0015', N'BD0015', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0016', N'BD0016', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0017', N'BD0017', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0018', N'BD0018', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0019', N'BD0002', 1)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0020', N'BD0001', 0)
INSERT [dbo].[PhieuMuon] ([MaPM], [MaBD], [TrangThai]) VALUES (N'PM0021', N'BD00000020', 1)
INSERT [dbo].[TaiKhoan] ([ID], [MatKhau], [PhanQuyen], [MaBD]) VALUES (N'admin1', N'1234', 4, N'BD0001')
INSERT [dbo].[TaiKhoan] ([ID], [MatKhau], [PhanQuyen], [MaBD]) VALUES (N'admin3', N'1234', 4, N'BD0003')
INSERT [dbo].[TaiKhoan] ([ID], [MatKhau], [PhanQuyen], [MaBD]) VALUES (N'admin4', N'1234', 4, N'BD0004')
INSERT [dbo].[TaiKhoan] ([ID], [MatKhau], [PhanQuyen], [MaBD]) VALUES (N'admin5', N'1234', 4, N'BD0005')
INSERT [dbo].[TaiKhoan] ([ID], [MatKhau], [PhanQuyen], [MaBD]) VALUES (N'user1', N'1234', 3, N'BD0006')
INSERT [dbo].[TaiKhoan] ([ID], [MatKhau], [PhanQuyen], [MaBD]) VALUES (N'user3', N'1234', 2, N'BD0008')
INSERT [dbo].[TaiKhoan] ([ID], [MatKhau], [PhanQuyen], [MaBD]) VALUES (N'user4', N'1234', 1, N'BD0009')
INSERT [dbo].[TaiKhoan] ([ID], [MatKhau], [PhanQuyen], [MaBD]) VALUES (N'user5', N'1234', 4, N'BD0010')
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00001', N'Nguyễn Tăng Cương', N'Cấu trúc máy tính', 500, 2, N'Tiếng Việt', N'TL014', N'NXB003', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00002', N'Đỗ Xuân Tiến', N'Kỹ thuật vi xử lý', 500, 2, N'Tiếng Việt', N'TL014', N'NXB003', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00003', N'Tô Hoài', N'Dế mèn phiêu lưu ký', 20, 1, N'Tiếng Việt', N'TL006', N'NXB005', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00004', N'Tổng cục chính trị', N'Dân tộc học', 500, 4, N'Tiếng Việt', N'TL014', N'NXB009', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00005', N'Conan Doyle', N'Sherlock Homes', 500, 1, N'Tiếng Việt', N'TL012', N'NXB007', 100, 3, N'Còn', CAST(0x1B3C0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00006', N'Đinh Mặc', N'Hãy nhắm mắt khi anh đến', 500, 1, N'Tiếng Việt', N'TL012', N'NXB010', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00007', N'Phong Lộng', N'Đồng Đồng và Kỳ Kỳ', 5, 1, N'Tiếng Việt', N'TL013', N'NXB008', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00008', N'Trần Trường Minh', N'Tôn Tử - Binh pháp & 36 kế', 10, 1, N'Tiếng Việt', N'TL005', N'NXB004', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00009', N'Trịnh Quang Từ', N'PP Nghiên cứu khoa học', 500, 2, N'Tiếng Việt', N'TL014', N'NXB009', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00010', N'La Quán Trung', N'Tam quốc diễn nghĩa', 10, 1, N'Tiếng Việt', N'TL013', N'NXB006', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00011', N'Phạm Văn Ất', N'C++', 100, 1, N'Tiếng Việt', N'TL004', N'NXB003', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00012', N'Y Ban', N'Trò chơi hủy diệt cảm xúc', 10, 1, N'Tiếng Việt', N'TL012', N'NXB006', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00013', N'Nam Moon Won', N'Thần thoại Ai Cập', 10, 1, N'Tiếng Việt', N'TL013', N'NXB005', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00014', N'Michael Scott', N'Magician', 10, 1, N'Tiếng Anh', N'TL013', N'NXB007', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00015', N'Thi Nại Am', N'Thủy Hử', 10, 1, N'Tiếng Việt', N'TL013', N'NXB005', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00016', N'Tổng cục chính trị', N'Tư tưởng HCM', 10, 3, N'Tiếng Việt', N'TL011', N'NXB009', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00017', N'Ngô Tất Tố', N'Tắt đèn', 10, 1, N'Tiếng Việt', N'TL013', N'NXB010', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00018', N'Vũ Trọng Phụng', N'Số đỏ', 10, 1, N'Tiếng Việt', N'TL012', N'NXB008', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00019', N'Tô Văn Ban', N'LT Xác suất thống kê', 500, 1, N'Tiếng Việt', N'TL014', N'NXB001', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TaiLieu] ([MaTL], [TacGia], [NhanDe], [SoLuong], [DoMat], [NgonNgu], [MaTheLoai], [MaNXB], [SoTrang], [TaiBan], [TrangThai], [NgayNhap]) VALUES (N'MTL00020', N'Anh Tuấn', N'Kỹ năng cần có trong cuộc sống', 10, 3, N'Tiếng Việt', N'TL007', N'NXB004', 100, 3, N'Còn', CAST(0xE93A0B00 AS Date))
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL001', N'Sách giáo khoa')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL002', N'Sách tham khảo')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL003', N'Tạp chí')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL004', N'Sách khoa học')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL005', N'Sách lịch sử')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL006', N'Sách thiếu nhi')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL007', N'Sách thiếu niên')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL008', N'Sách kinh doanh')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL009', N'Sách bình luận văn học')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL010', N'Sách địa lý')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL011', N'Sách chính trị')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL012', N'Tiểu thuyết')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL013', N'Sách văn học')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL014', N'Giáo trình')
ALTER TABLE [dbo].[BanDoc]  WITH CHECK ADD  CONSTRAINT [fk_bd_lop] FOREIGN KEY([MaLop])
REFERENCES [dbo].[Lop] ([MaLop])
GO
ALTER TABLE [dbo].[BanDoc] CHECK CONSTRAINT [fk_bd_lop]
GO
ALTER TABLE [dbo].[ChitietPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK__ChitietPhi__MaTL] FOREIGN KEY([MaTL])
REFERENCES [dbo].[TaiLieu] ([MaTL])
GO
ALTER TABLE [dbo].[ChitietPhieuMuon] CHECK CONSTRAINT [FK__ChitietPhi__MaTL]
GO
ALTER TABLE [dbo].[ChitietPhieuMuon]  WITH CHECK ADD  CONSTRAINT [fk_ctpm_pm] FOREIGN KEY([MaPM])
REFERENCES [dbo].[PhieuMuon] ([MaPM])
GO
ALTER TABLE [dbo].[ChitietPhieuMuon] CHECK CONSTRAINT [fk_ctpm_pm]
GO
ALTER TABLE [dbo].[PhieuMuon]  WITH CHECK ADD  CONSTRAINT [fk_pm_bd] FOREIGN KEY([MaBD])
REFERENCES [dbo].[BanDoc] ([MaBD])
GO
ALTER TABLE [dbo].[PhieuMuon] CHECK CONSTRAINT [fk_pm_bd]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [fk_tk_bd] FOREIGN KEY([MaBD])
REFERENCES [dbo].[BanDoc] ([MaBD])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [fk_tk_bd]
GO
ALTER TABLE [dbo].[TaiLieu]  WITH CHECK ADD  CONSTRAINT [fk_tl_nxb] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NXB] ([MaNXB])
GO
ALTER TABLE [dbo].[TaiLieu] CHECK CONSTRAINT [fk_tl_nxb]
GO
ALTER TABLE [dbo].[TaiLieu]  WITH CHECK ADD  CONSTRAINT [fk_tl_theloai] FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[TheLoai] ([MaTheLoai])
GO
ALTER TABLE [dbo].[TaiLieu] CHECK CONSTRAINT [fk_tl_theloai]
GO
USE [master]
GO
ALTER DATABASE [QL_ThuVien] SET  READ_WRITE 
GO
