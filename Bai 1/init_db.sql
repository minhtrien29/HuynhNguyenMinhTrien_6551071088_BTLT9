USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QL_ChiTieu')
BEGIN
    CREATE DATABASE QL_ChiTieu;
END
GO

USE QL_ChiTieu;
GO

IF OBJECT_ID('dbo.ChiTieu', 'U') IS NOT NULL
    DROP TABLE dbo.ChiTieu;
GO

CREATE TABLE dbo.ChiTieu (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    NgayChi DATE NOT NULL,
    NoiDung NVARCHAR(100) NOT NULL,
    LoaiChi NVARCHAR(30) NOT NULL,
    SoTien DECIMAL(18,0) NOT NULL,
    GhiChu NVARCHAR(200) NULL
);
GO

INSERT INTO dbo.ChiTieu (NgayChi, NoiDung, LoaiChi, SoTien, GhiChu) VALUES
('2026-10-10', N'Ăn sáng phở bò', N'Ăn uống', 45000, N'Phở Thìn'),
('2026-10-10', N'Đổ xăng xe máy', N'Đi lại', 70000, N'Cây xăng Petrolimex'),
('2026-10-11', N'Mua giáo trình C#', N'Học tập', 120000, N'Nhà sách FAHASA'),
('2026-10-12', N'Xem phim rạp CGV', N'Giải trí', 110000, N'Phim cuối tuần với bạn'),
('2026-10-13', N'Cà phê sáng', N'Ăn uống', 35000, N'Highlands'),
('2026-10-14', N'Nạp thẻ điện thoại', N'Khác', 100000, N'Viettel'),
('2026-10-15', N'Mua khóa học online', N'Học tập', 250000, N'Khóa lập trình EF Core'),
('2026-10-16', N'Bảo dưỡng xe máy', N'Đi lại', 150000, N'Thay nhớt định kỳ'),
('2026-10-17', N'Ăn lẩu liên hoan', N'Ăn uống', 200000, N'Góp tiền nhóm'),
('2026-10-18', N'Mua đồ gia dụng', N'Khác', 85000, N'Bàn chải, xà phòng');
GO
