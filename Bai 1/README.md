# Hướng dẫn chạy Bài 1: Sổ chi tiêu cá nhân (WinForms + EF Core)

## 1. Cấu hình Cơ sở dữ liệu (SQL Server)
- File script tạo cơ sở dữ liệu: `init_db.sql`
- Thực thi script bằng SQL Server Management Studio (SSMS) hoặc lệnh sau:
  ```bash
  sqlcmd -S "(localdb)\MSSQLLocalDB" -E -i init_db.sql
  ```
  *(Hoặc đổi `(localdb)\MSSQLLocalDB` thành tên SQL Server của bạn ví dụ `.\SQLEXPRESS` hoặc `localhost`)*

## 2. Cấu hình ứng dụng
- Chuỗi kết nối được quản lý độc lập tại file `appsettings.json` (và `appsettings.Development.json`):
  ```json
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=QL_ChiTieu;Trusted_Connection=True;TrustServerCertificate=True;"
    }
  }
  ```
- File mẫu cấu hình: `appsettings.example.json`

## 3. Khởi chạy từ mã nguồn
```bash
cd ChiTieuApp
dotnet run
```

## 4. Bản đóng gói (Publish)
- Thư mục đóng gói sẵn: `ChiTieuApp/publish/`
- Chạy trực tiếp: `ChiTieuApp/publish/ChiTieuApp.exe` (Chỉ cần máy cài .NET Desktop Runtime 8.0).
- Khi đổi máy hoặc SQL Server khác, chỉ cần chỉnh sửa `appsettings.json` trong thư mục `publish` mà không cần build lại code!
- Nhật ký hoạt động (Logs) được ghi theo ngày tự động tại thư mục `Logs/log-yyyyMMdd.txt`.
