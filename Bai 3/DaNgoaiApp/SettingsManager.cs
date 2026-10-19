using System.Text.Json;

namespace DaNgoaiApp;

public class UserSettings
{
    public string Language { get; set; } = "vi"; // "vi" hoặc "en"
}

public static class SettingsManager
{
    private static readonly string SettingsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DaNgoaiApp");
    private static readonly string SettingsFile = Path.Combine(SettingsDir, "usersettings.json");

    public static UserSettings Current { get; private set; } = new();

    static SettingsManager()
    {
        LoadSettings();
    }

    public static void LoadSettings()
    {
        try
        {
            if (File.Exists(SettingsFile))
            {
                string json = File.ReadAllText(SettingsFile);
                Current = JsonSerializer.Deserialize<UserSettings>(json) ?? new UserSettings();
            }
        }
        catch
        {
            Current = new UserSettings();
        }
    }

    public static void SaveSettings(string lang)
    {
        try
        {
            Current.Language = lang;
            if (!Directory.Exists(SettingsDir))
            {
                Directory.CreateDirectory(SettingsDir);
            }
            string json = JsonSerializer.Serialize(Current, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SettingsFile, json);
        }
        catch
        {
        }
    }
}
