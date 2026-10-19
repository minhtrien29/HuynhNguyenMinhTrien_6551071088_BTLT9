USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QL_NhaTro')
BEGIN
    CREATE DATABASE QL_NhaTro;
END
GO

USE QL_NhaTro;
GO

IF OBJECT_ID('dbo.KhachThue', 'U') IS NOT NULL DROP TABLE dbo.KhachThue;
IF OBJECT_ID('dbo.PhongTro', 'U') IS NOT NULL DROP TABLE dbo.PhongTro;
GO

CREATE TABLE dbo.PhongTro (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(20) NOT NULL,
    GiaThue DECIMAL(18,0) NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL DEFAULT N'Trống'
);
GO

CREATE TABLE dbo.KhachThue (
    MaKhach INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(5) NOT NULL,
    NgaySinh DATE NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    MaTinh INT NULL,
    TenTinh NVARCHAR(100) NULL,
    MaPhuongXa INT NULL,
    TenPhuongXa NVARCHAR(100) NULL,
    DaDangKyTamTru BIT NOT NULL DEFAULT 0,
    MaPhong INT NOT NULL FOREIGN KEY REFERENCES dbo.PhongTro(MaPhong)
);
GO

-- Chèn 6 phòng trọ ban đầu
INSERT INTO dbo.PhongTro (TenPhong, GiaThue, TinhTrang) VALUES
(N'Phòng 101', 2500000, N'Đang thuê'),
(N'Phòng 102', 2500000, N'Trống'),
(N'Phòng 201', 3000000, N'Đang thuê'),
(N'Phòng 202', 3000000, N'Trống'),
(N'Phòng 301', 3500000, N'Trống'),
(N'Phòng 302', 3500000, N'Trống');
GO

-- Chèn khách thuê mẫu
INSERT INTO dbo.KhachThue (HoTen, GioiTinh, NgaySinh, SoDienThoai, MaTinh, TenTinh, MaPhuongXa, TenPhuongXa, DaDangKyTamTru, MaPhong) VALUES
(N'Nguyễn Văn An', N'Nam', '2001-05-15', '0901234567', 1, N'Thành phố Hà Nội', 1, N'Phường Phúc Xá', 1, 1),
(N'Trần Thị Bích', N'Nữ', '2002-08-20', '0912345678', 79, N'Thành phố Hồ Chí Minh', 26734, N'Phường Bến Nghé', 0, 3);
GO
