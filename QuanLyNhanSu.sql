create database QuanLyNhanSu
GO
USE QuanLyNhanSu
GO
CREATE TABLE CHUCVU(
	MaCV VARCHAR(10) primary key,
	TenCV nvarchar(50)
)
GO
SELECT * FROM PHONGBAN
GO
CREATE TABLE PHONGBAN(
	MaPB VARCHAR(10) primary key,
	TenPB nvarchar(50),
	MaTP VARCHAR(10),
	DiaChi nvarchar(50),
	SDT char(15)
)

GO
create table TRINHDOHOCVAN(
	MaTDHV VARCHAR(10) primary key,
	TenTrinhDo nvarchar(50),
	ChuyenNganh nvarchar(50)
)

go
CREATE TABLE NHANVIEN(
	MaNV varchar(10) primary key,
	HoTen nvarchar(50),
	GioiTinh NVARCHAR(3),
	SDT CHAR(15),
	QueQuan nvarchar(50),
	NgaySinh date,
	MaTDHV VARCHAR(10) REFERENCES TrinhDoHocVan(MaTDHV),
	MaPB VARCHAR(10) references PhongBan(MaPB),
)

GO
CREATE TABLE NHANVIEN_CHUCVU(
	MaNV VARCHAR(10) REFERENCES NHANVIEN(MaNV),
	MaCV VARCHAR(10) REFERENCES CHUCVU(MaCV),
	PRIMARY KEY (MaNV,MaCV)
)
GO
CREATE TABLE HOPDONGLAODONG(
	MaHD VARCHAR(10) PRIMARY KEY,
	LoaiHD NVARCHAR(30),
	LuongThoaThuan BIGINT,
	MaNV VARCHAR(10) UNIQUE REFERENCES NHANVIEN(MaNV)
)
GO
CREATE TABLE DANGNHAP
(
	TaiKhoan NVARCHAR(30),
	MatKhau VARCHAR(30)
)

GO
CREATE PROC ThemNV ( @MaNV varchar(10),@HoTen nvarchar(50),@GioiTinh nvarchar(3),@SDT char(15),@QueQuan nvarchar(50),@NgaySinh date,@MaTDHV varchar(10),@MaPB varchar(10))AS
BEGIN
	INSERT INTO dbo.NHANVIEN
	        ( MaNV ,HoTen ,GioiTinh ,SDT ,QueQuan , NgaySinh ,MaTDHV ,MaPB)
	VALUES  ( @MaNV ,@HoTen ,@GioiTinh ,@SDT ,@QueQuan,@NgaySinh ,@MaTDHV ,@MaPB )
END
CREATE PROC SuaNV ( @MaNV varchar(10),@HoTen nvarchar(50),@GioiTinh nvarchar(3),@SDT char(15),@QueQuan nvarchar(50),@NgaySinh date,@MaTDHV varchar(10),@MaPB varchar(10))AS
BEGIN
	UPDATE dbo.NHANVIEN
	SET HoTen  = @HoTen,GioiTinh=@GioiTinh,SDT=@SDT,QueQuan=@QueQuan,NgaySinh=@NgaySinh,MaTDHV=@MaTDHV,MaPB=@MaPB WHERE MaNV =@MaNV
END

CREATE PROC XoaNV( @MaNV varchar(10)) AS 
BEGIN
	DELETE FROM dbo.NHANVIEN WHERE MaNV = @MaNV 
END

-- Trình Độ học vấn 
CREATE PROC ThemTD( @MaTDHV varchar(10), @TenTrinhDo nvarchar(50), @ChuyenNganh nvarchar(50))AS 
BEGIN
	INSERT INTO dbo.TRINHDOHOCVAN
	        ( MaTDHV, TenTrinhDo, ChuyenNganh )
	VALUES  (@MaTDHV,@TenTrinhDo,@ChuyenNganh)
END

CREATE PROC SuaTD( @MaTDHV varchar(10), @TenTrinhDo nvarchar(50), @ChuyenNganh nvarchar(50))AS 
BEGIN
	UPDATE dbo.TRINHDOHOCVAN
	SET TenTrinhDo = @TenTrinhDo,ChuyenNganh = @ChuyenNganh WHERE MaTDHV =@MaTDHV
END

CREATE PROC XoaTD(@MaTDHV varchar(10)) AS 
BEGIN 
	DELETE FROM dbo.TRINHDOHOCVAN WHERE MaTDHV = @MaTDHV
END 