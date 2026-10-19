USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QL_DaNgoai')
BEGIN
    CREATE DATABASE QL_DaNgoai;
END
GO

USE QL_DaNgoai;
GO

IF OBJECT_ID('dbo.ChuyenDi', 'U') IS NOT NULL DROP TABLE dbo.ChuyenDi;
GO

CREATE TABLE dbo.ChuyenDi (
    MaChuyen INT IDENTITY(1,1) PRIMARY KEY,
    TenChuyen NVARCHAR(100) NOT NULL,
    DiaDiem NVARCHAR(100) NOT NULL,
    NgayDi DATE NOT NULL,
    SoNguoi INT NOT NULL,
    NganSach DECIMAL(18,0) NOT NULL,
    PhuongTien NVARCHAR(30) NOT NULL,
    DaHoanThanh BIT NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(200) NULL
);
GO

-- Chèn sẵn 8 chuyến đi mẫu với các ngày trải dài
INSERT INTO dbo.ChuyenDi (TenChuyen, DiaDiem, NgayDi, SoNguoi, NganSach, PhuongTien, DaHoanThanh, GhiChu) VALUES
(N'Khám phá Đà Lạt mộng mơ', N'Đà Lạt', DATEADD(day, 3, GETDATE()), 4, 8000000, N'Xe khách', 0, N'Mang theo áo ấm'),
(N'Săn mây Sa Pa', N'Sa Pa', DATEADD(day, 7, GETDATE()), 2, 6500000, N'Tàu hỏa', 0, N'Đặt homestay Bản Cát Cát'),
(N'Nghỉ dưỡng Vũng Tàu', N'Vũng Tàu', DATEADD(day, 2, GETDATE()), 6, 5000000, N'Ô tô', 0, N'Tắm biển bãi Sau'),
(N'Phố cổ Hội An về đêm', N'Hội An', DATEADD(day, 10, GETDATE()), 3, 9000000, N'Xe máy', 0, N'Thả hoa đăng sông Hoài'),
(N'Du lịch Nha Trang', N'Nha Trang', DATEADD(day, 5, GETDATE()), 5, 12000000, N'Tàu hỏa', 0, N'Lặn ngắm san hô'),
(N'Cắm trại Ba Vì', N'Ba Vì', DATEADD(day, 4, GETDATE()), 8, 3000000, N'Xe máy', 0, N'Nướng BBQ ngoài trời'),
(N'Hạ Long vịnh di sản', N'Hạ Long', DATEADD(day, 12, GETDATE()), 4, 11000000, N'Ô tô', 0, N'Đi tour du thuyền 2 ngày 1 đêm'),
(N'Tam Đảo mù sương', N'Tam Đảo', DATEADD(day, -5, GETDATE()), 2, 2500000, N'Xe máy', 1, N'Chuyến đi đã xong');
GO
