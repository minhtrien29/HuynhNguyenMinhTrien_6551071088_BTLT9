using Serilog;

namespace ChiTieuApp;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // Setup Serilog
        string logPath = Path.Combine(AppContext.BaseDirectory, "Logs", "log-.txt");
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(logPath, rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        Log.Information("Ứng dụng Sổ chi tiêu cá nhân khởi động.");

        try
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormChiTieu());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Ứng dụng gặp lỗi nghiêm trọng.");
            MessageBox.Show("Đã xảy ra lỗi không mong muốn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Log.Information("Ứng dụng kết thúc.");
            Log.CloseAndFlush();
        }
    }
}