create database QuanLyNhanSu
GO
USE QuanLyNhanSu

GO
CREATE TABLE CHUCVU(
	MaCV VARCHAR(10) primary key,
	TenCV nvarchar(50)
)
GO

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
CREATE PROC DangKy(@Taikhoan NVARCHAR(30),@Matkhau NVARCHAR(30))
AS
	BEGIN
	INSERT dbo.DANGNHAP( TaiKhoan, MatKhau )
	VALUES  ( @Taikhoan, @Matkhau )
END
GO
