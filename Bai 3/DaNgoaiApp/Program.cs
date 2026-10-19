using Serilog;

namespace DaNgoaiApp;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        string logPath = Path.Combine(AppContext.BaseDirectory, "Logs", "log-.txt");
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(logPath, rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        Log.Information("Ứng dụng Kế hoạch dã ngoại khởi động.");

        try
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormChuyenDi());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Lỗi nghiêm trọng trong ứng dụng Kế hoạch dã ngoại.");
            MessageBox.Show("Đã xảy ra sự cố: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Log.Information("Ứng dụng Kế hoạch dã ngoại dừng.");
            Log.CloseAndFlush();
        }
    }
}