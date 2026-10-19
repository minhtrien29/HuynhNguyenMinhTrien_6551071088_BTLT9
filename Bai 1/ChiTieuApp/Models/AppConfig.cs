namespace ChiTieuApp.Models;

public class ConnectionStringsOptions
{
    public string DefaultConnection { get; set; } = string.Empty;
}

public class AppConfig
{
    public ConnectionStringsOptions ConnectionStrings { get; set; } = new();
}
