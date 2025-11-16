```sql
CREATE DATABASE QuanLyKiTucXa
USE QuanLyKiTucXa

CREATE TABLE TienPhong (
    Masv BIGINT NOT NULL,
    HoTen NVARCHAR(MAX) NULL,
    SDT VARCHAR(15) NULL,
    Gmail VARCHAR(50) NULL,
    DiaChi NVARCHAR(50) NULL,
    CCCD CHAR(12) NULL,
    MaPhong CHAR(4) NULL,
    Ngay DATE NULL,
    TienThanhToan MONEY NOT NULL,
    CONSTRAINT PK_TienPhong PRIMARY KEY (Masv)
);

CREATE TABLE HoaDonDienNuoc (
    MaHoaDon VARCHAR(20) NOT NULL,
    TenHoaDon VARCHAR(50) NULL,
    TienDien MONEY NULL,
    TienNuoc MONEY NULL,
    NgayTaoHoaDon DATE NULL,
    MaPhong CHAR(4) NULL,
    TinhTrangHoaDon NVARCHAR(30) NULL,
    CONSTRAINT PK_HoaDonDienNuoc PRIMARY KEY (MaHoaDon)
);

CREATE TABLE PHONG (
    MaPhong CHAR(4) PRIMARY KEY,
    TenPhong NVARCHAR(50) NOT NULL,
    SLSVToiDa INT NOT NULL,
    SLSVHienTai INT DEFAULT 0,
    GiaPhong BIGINT NOT NULL,
    TinhTrang BIT
);

CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    Gmail VARCHAR(100) NOT NULL,
    NgaySinh DATETIME NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    DiaChi NVARCHAR(200) NOT NULL,
    CCCD VARCHAR(20) NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    NgayNhanLam DATETIME NOT NULL,
    HinhAnh VARBINARY(MAX) NULL,
    MaCV INT
);

CREATE TABLE QuanLyThietBiPhong (
    MaThietBi VARCHAR(10) PRIMARY KEY,
    TenThietBi NVARCHAR(100),
    MaPhong CHAR(4),
    SoLuongHong INT,
    SoLuongToiDa INT,
    SoLuongThietBi INT
);

CREATE TABLE Quanlysinhvien (
    Masv BIGINT,
    Hovaten NVARCHAR(50),
    SDT VARCHAR(10),
    Gmail VARCHAR(50),
    Gioitinh NVARCHAR(3),
    Ngaysinh DATE,
    Diachi NVARCHAR(50),
    CCCD VARCHAR(12) PRIMARY KEY,
    Ngaylamhopdong DATE,
    Ngayketthuchopdong DATE,
    MaPhong CHAR(4),
    Anh VARBINARY(MAX)
);

CREATE TABLE ChucVu (
    MaCV INT IDENTITY(1,1) PRIMARY KEY,
    TenChucVu NVARCHAR(50) NOT NULL,
    Luong BIGINT NOT NULL
);

CREATE TABLE Users (
    UserName NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);
