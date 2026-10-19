using Serilog;

namespace NhaTroApp;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // 1. Cấu hình Serilog
        string logPath = Path.Combine(AppContext.BaseDirectory, "Logs", "log-.txt");
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(logPath, rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        Log.Information("Ứng dụng Quản lý nhà trọ bắt đầu.");

        // 2. Bắt lỗi toàn cục UI Thread
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (sender, e) =>
        {
            Log.Error(e.Exception, "Lỗi chưa xử lý trong UI Thread: {Message}", e.Exception.Message);
            MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.\nChi tiết: " + e.Exception.Message, 
                "Thông báo sự cố", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        };

        // 3. Bắt lỗi toàn cục Non-UI Thread
        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            if (e.ExceptionObject is Exception ex)
            {
                Log.Fatal(ex, "Lỗi nghiêm trọng không bắt được (AppDomain): {Message}", ex.Message);
                MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.\nChi tiết: " + ex.Message, 
                    "Sự cố hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        };

        try
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormKhachThue());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Ứng dụng gặp lỗi không thể phục hồi.");
            MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Log.Information("Ứng dụng Quản lý nhà trọ kết thúc.");
            Log.CloseAndFlush();
        }
    }
}