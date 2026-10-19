using Microsoft.Extensions.Configuration;

namespace DaNgoaiApp;

public static class ConfigurationHelper
{
    private static IConfiguration? _configuration;

    public static IConfiguration Configuration
    {
        get
        {
            if (_configuration == null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                _configuration = builder.Build();
            }
            return _configuration;
        }
    }

    public static string GetConnectionString()
    {
        return Configuration.GetConnectionString("DefaultConnection") 
            ?? "Server=(localdb)\\MSSQLLocalDB;Database=QL_DaNgoai;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}
