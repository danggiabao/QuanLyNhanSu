create database QuanLyNhanSu
GO
USE QuanLyNhanSu
GO
CREATE TABLE CHUCVU(
	MaCV VARCHAR(10) primary key,
	TenCV nvarchar(50)
)
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

	MaTDHV VARCHAR(10) REFERENCES TrinhDoHocVan(MaTDHV)
	ON DELETE CASCADE
	ON UPDATE CASCADE,

	MaPB VARCHAR(10) references PhongBan(MaPB)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

GO
CREATE TABLE NHANVIEN_CHUCVU(
	MaNV VARCHAR(10) REFERENCES NHANVIEN(MaNV)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	MaCV VARCHAR(10) REFERENCES CHUCVU(MaCV)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	PRIMARY KEY (MaNV,MaCV)
)
Go

CREATE TABLE HOPDONGLAODONG(
	MaHD VARCHAR(10) PRIMARY KEY,
	LoaiHD NVARCHAR(30),
	LuongThoaThuan BIGINT,
	MaNV VARCHAR(10) UNIQUE REFERENCES NHANVIEN(MaNV)
	 ON DELETE CASCADE
	ON UPDATE CASCADE,
)
GO


CREATE TABLE DANGNHAP
(
	TaiKhoan NVARCHAR(30),
	MatKhau VARCHAR(30)
)
GO
 
INSERT dbo.DANGNHAP( TaiKhoan, MatKhau )
VALUES  ( N'admin','123456'),
		( N'user1','123456')
GO
INSERT INTO dbo.PhongBan( MaPB, TenPB, DiaChi, SDT, MaTP )
VALUES  ('PB01', N'Hành Chính',N'Hà Nội', '09032289456', 'NV01'),
		('PB02', N'Tài Chính',N'Hà Nội', '016458956', 'NV02'),
		('PB03', N'Quản lý', N'Hà Nội', '0163228946', 'NV03')
GO
INSERT INTO dbo.TRINHDOHOCVAN ( MaTDHV, TenTrinhDo, ChuyenNganh )
VALUES  ('TD01',N'Cử nhân đại học',N'CNTT'),
		('TD02',N'Kỹ sư đại học',N'CNTT'),
		('TD03',N'Cử nhân đại học',N'Kinh Tế')
GO
insert into NhanVien(MaNV,HoTen,GioiTinh,SDT,QueQuan,NgaySinh,MaTDHV,MaPB)
values	('NV01',N'Lê Vân Anh',N'Nữ','0916564789',N'Hà Nội','01-08-1984','TD01','PB01')
insert into NhanVien(MaNV,HoTen,GioiTinh,SDT,QueQuan,NgaySinh,MaTDHV,MaPB)
Values		('NV02',N'Trịnh Quang Vinh',N'Nam','0916564719',N'Nam Định','10-12-1982','TD03','PB02')
insert into NhanVien(MaNV,HoTen,GioiTinh,SDT,QueQuan,NgaySinh,MaTDHV,MaPB)
Values		('NV03',N'Đỗ Văn Nam',N'Nam','0916564889',N'Hà Tây','06-05-1990','TD02','PB03')
insert into NhanVien(MaNV,HoTen,GioiTinh,SDT,QueQuan,NgaySinh,MaTDHV,MaPB)
Values		('NV04',N'Nguyễn Trung Kiên',N'Nam','0916560389',N'Hà Nội','11-08-1992','TD02','PB01')
insert into NhanVien(MaNV,HoTen,GioiTinh,SDT,QueQuan,NgaySinh,MaTDHV,MaPB)
Values		('NV05',N'Nguyễn Thị Ngọc Ánh',N'Nữ','01647386289',N'Phú Thọ','02-09-1989','TD01','PB01')
insert into NhanVien(MaNV,HoTen,GioiTinh,SDT,QueQuan,NgaySinh,MaTDHV,MaPB)
Values		('NV06',N'Trần Lâm',N'Nam','0912564781',N'Hà Nội','11-08-1995','TD03','PB02')
GO

INSERT INTO dbo.CHUCVU( MaCV, TenCV )
VALUES  ('CV01',N'Giám Đốc'),
		('CV02',N'Trường Phòng'),
		('CV03',N'Phó Giám Đốc'),
		('CV04',N'Phó Phòng'),
		('CV05',N'Trường Nhóm'),
		('CV06',N'Phó Nhóm'),
		('CV07',N'Nhân Viên'),
		('CV08',N'Thư Ký')
GO
INSERT dbo.NHANVIEN_CHUCVU(MaNV, MaCV)
VALUES  ('NV01','CV01'),
		('NV02','CV02'),
		('NV03','CV03'),
		('NV04','CV04'),
		('NV05','CV05'),
		('NV06','CV06')
GO

INSERT INTO dbo.HOPDONGLAODONG(MaHD,LoaiHD,LuongThoaThuan,MaNV)
VALUES	('HD01',N'Chính Thức',20000000,'NV01'),
		('HD02',N'Chính Thức',15000000,'NV02'),
		('HD03',N'Chính Thức',13000000,'NV03'),
		('HD04',N'Chính Thức',10000000,'NV04'),
		('HD05',N'Chính Thức',10000000,'NV05'),
		('HD06',N'Chính Thức',10000000,'NV06')
GO
--Proc Dang Nhap
CREATE PROC DangKy(@Taikhoan NVARCHAR(30),@Matkhau NVARCHAR(30))
AS
	BEGIN
	INSERT dbo.DANGNHAP( TaiKhoan, MatKhau )
	VALUES  ( @Taikhoan, @Matkhau )
END
GO

CREATE PROC dbo.KiemTraDN(@Username VARCHAR(50),@Pass varchar(50)) AS 
BEGIN
	SELECT * FROM dbo.DANGNHAP WHERE TaiKhoan = @Username AND MatKhau = @Pass
END
GO

--Proc Chuc Vu
CREATE PROC THEMCV (@machucvu VARCHAR(10),@tenchucvu NVARCHAR(50))
AS
BEGIN
	INSERT dbo.CHUCVU( MaCV, TenCV)
	VALUES  ( @machucvu,@tenchucvu)
	
END

GO
CREATE PROC SUACV (@machucvu VARCHAR(10),@tenchucvu NVARCHAR(50))
AS
BEGIN
	UPDATE dbo.CHUCVU
	SET TenCV=@tenchucvu
	WHERE MaCV=@machucvu
END

GO 
CREATE PROC XOACV (@machucvu varchar(10))
AS
BEGIN
		DELETE dbo.CHUCVU WHERE MaCV=@machucvu
END
GO
--ProcNhan Vien
CREATE PROC ThemNV (@MaNV varchar(10),@HoTen nvarchar(50), @GioiTinh varchar(3),@SDT char(15), @QueQuan nvarchar(50), @NgaySinh date,@MaTDHV varchar(10),@MaPB varchar(10)) AS
BEGIN
	INSERT INTO dbo.NHANVIEN
	        ( MaNV ,HoTen , GioiTinh ,SDT , QueQuan , NgaySinh ,MaTDHV ,MaPB)
	VALUES   ( @MaNV ,@HoTen , @GioiTinh ,@SDT , @QueQuan , @NgaySinh ,@MaTDHV ,@MaPB)
END

CREATE PROC SuaNV (@MaNV varchar(10),@HoTen nvarchar(50), @GioiTinh varchar(3),@SDT char(15), @QueQuan nvarchar(50), @NgaySinh date,@MaTDHV varchar(10),@MaPB varchar(10)) AS
BEGIN
UPDATE dbo.NHANVIEN SET 
HoTen =@HoTen , GioiTinh =  @GioiTinh,SDT= @SDT, QueQuan= @QueQuan , NgaySinh = @NgaySinh,MaTDHV= @MaTDHV,MaPB= @MaPB
 WHERE 	  MaNV =@MaNV
END

CREATE PROC XoaNV (@MaNV varchar(10))AS
BEGIN
	DELETE dbo.NHANVIEN WHERE MaNV =  @MaNV
END


--Proc Phong Ban
CREATE PROC ThemPB(@MaPB VARCHAR(10),@TenPB NVARCHAR(50),@MaTP VARCHAR(10),@DiaChi NVARCHAR(50),@SDT CHAR(15)) AS
BEGIN
	 INSERT INTO PHONGBAN
	 VALUES  (@MaPB,@TenPB,@MaTP,@DiaChi,@SDT) 
END
go

CREATE PROC SuaPB (@MaPB VARCHAR(10),@TenPB NVARCHAR(50),@MaTP VARCHAR(10),@DiaChi NVARCHAR(50),@SDT CHAR(15)) AS
BEGIN
	UPDATE PHONGBAN SET 
	TenPB=@TenPB,MaTP=@MaTP,DiaChi=@DiaChi,SDT=@SDT	 
	WHERE MaPB=@MaPB
END
GO
CREATE PROC XoaPB(@MaPB VARCHAR(10)) AS
 BEGIN
		DELETE FROM PHONGBAN WHERE MaPB=@MaPB
 END
go
--
--Proc Hop Dong
CREATE PROC ThemHD(@MaHD VARCHAR(10),@LoaiHD NVARCHAR(30),@Luongthoathuan BIGINT,@MaNV VARCHAR(10)) AS
BEGIN
	 INSERT INTO HOPDONGLAODONG
	 VALUES  (@MaHD,@LoaiHD,@Luongthoathuan,@MaNV) 
END
go

CREATE PROC SuaHD(@MaHD VARCHAR(10),@LoaiHD NVARCHAR(30),@Luongthoathuan BIGINT,@MaNV VARCHAR(10)) AS
BEGIN
	UPDATE HOPDONGLAODONG SET 
	LoaiHD=@LoaiHD,LuongThoaThuan=@Luongthoathuan,MaNV=@MaNV	 
	WHERE MaHD=@MaHD
END
GO
CREATE PROC XoaHD(@MaHD VARCHAR(10)) AS
 BEGIN
		DELETE FROM HOPDONGLAODONG WHERE MaHD=@MaHD
 END
 ---
 
 --Tạo 1 view chứa các thông tin nhân viên và hợp đồng lao động
 CREATE VIEW HopDongNhanVien AS
 SELECT nv.*,hd.LoaiHD,hd.MaHD,hd.LuongThoaThuan FROM dbo.NHANVIEN nv ,dbo.HOPDONGLAODONG hd 
 WHERE nv.MaNV = hd.MaNV

 ALTER PROC XoaHDLD (@MaNV varchar(10))AS
 BEGIN
 	DELETE FROM HopDongNhanVien WHERE MaNV = @MaNV
 END
 
 