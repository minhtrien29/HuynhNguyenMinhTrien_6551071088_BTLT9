# Hướng dẫn chạy Bài 2: Quản lý nhà trọ

## 1. Cơ sở dữ liệu (SQL Server)
- File script tạo cơ sở dữ liệu: `init_db.sql`
- Chạy script:
  ```bash
  sqlcmd -S "(localdb)\MSSQLLocalDB" -E -i init_db.sql
  ```
  *(Tự động tạo CSDL `QL_NhaTro`, bảng `PhongTro`, `KhachThue` với khóa ngoại và dữ liệu mẫu).*

## 2. Tính năng nổi bật
- **Tích hợp API Tỉnh / Phường-Xã**: Tự động gọi API `https://provinces.open-api.vn/api/v2/` và nạp động phường/xã theo tỉnh.
- **Chịu lỗi mạng & nhập tay**: Khi mất mạng, chương trình không bị gián đoạn hay crash, vẫn cho phép nhập tay phường xã để lưu khách.
- **Xử lý ngoại lệ toàn cục (Global Exception Handler)**: Bắt toàn bộ lỗi giao diện và lỗi ngầm thông qua `Application.ThreadException` và `AppDomain.CurrentDomain.UnhandledException`, ghi nhật ký Serilog và hiện thông báo thân thiện.
- **Nút "Gây lỗi thử"**: Có sẵn nút trên form để thử nghiệm cơ chế bắt lỗi toàn cục an toàn.
- **Tự động cập nhật trạng thái phòng**: Tự chuyển sang "Đang thuê" khi có khách và trả về "Trống" khi hết khách.

## 3. Khởi chạy
```bash
cd NhaTroApp
dotnet run
```
