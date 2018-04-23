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
 