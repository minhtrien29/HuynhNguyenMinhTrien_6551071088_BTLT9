# Hướng dẫn chạy Bài 3: Kế hoạch dã ngoại & Dự báo thời tiết

## 1. Cơ sở dữ liệu (SQL Server)
- File script tạo cơ sở dữ liệu: `init_db.sql`
- Chạy script:
  ```bash
  sqlcmd -S "(localdb)\MSSQLLocalDB" -E -i init_db.sql
  ```
  *(Tự động tạo CSDL `QL_DaNgoai`, bảng `ChuyenDi` với 8 chuyến đi mẫu).*

## 2. Tính năng nổi bật
- **Tích hợp API thời tiết Open-Meteo**: 
  - Bước 1: Geocoding tự động tìm tọa độ (kinh độ, vĩ độ) theo tên địa điểm (có xử lý tiếng Việt có dấu và không dấu).
  - Bước 2: Lấy dự báo 16 ngày theo ngày đi, bóc tách `weather_code`, nhiệt độ cao nhất / thấp nhất, xác suất mưa.
  - Tự động hiển thị cảnh báo nền cam khi xác suất mưa $\ge 60\%$.
- **Đa ngôn ngữ (Tiếng Việt / English)**:
  - Cho phép chuyển đổi tức thì giữa Tiếng Việt và English ngay trên giao diện mà không cần khởi động lại ứng dụng.
  - Tự động lưu thiết lập ngôn ngữ vào `%LocalAppData%\DaNgoaiApp\usersettings.json` để ghi nhớ cho các lần chạy sau.
  - Định dạng tiền tệ và ngày tháng thay đổi linh hoạt theo `CultureInfo` tương ứng.
- **Tìm kiếm & Lọc**: Tìm kiếm theo tên chuyến, địa điểm, lọc chuyến chưa hoàn thành, lọc theo khoảng thời gian khởi hành.

## 3. Khởi chạy
```bash
cd DaNgoaiApp
dotnet run
```
