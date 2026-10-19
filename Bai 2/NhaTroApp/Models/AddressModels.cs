using System.Text.Json.Serialization;

namespace NhaTroApp.Models;

public class ProvinceItem
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    public override string ToString() => Name;
}

public class ProvinceDetail
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("wards")]
    public List<WardItem> Wards { get; set; } = new();
}

public class WardItem
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    public override string ToString() => Name;
}
