using System.Text.Json.Serialization;

namespace DaNgoaiApp.Models;

public class GeocodingResponse
{
    [JsonPropertyName("results")]
    public List<GeocodingResult>? Results { get; set; }
}

public class GeocodingResult
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}

public class WeatherApiResponse
{
    [JsonPropertyName("daily")]
    public DailyForecast? Daily { get; set; }
}

public class DailyForecast
{
    [JsonPropertyName("time")]
    public List<string>? Time { get; set; }

    [JsonPropertyName("weather_code")]
    public List<int>? WeatherCode { get; set; }

    [JsonPropertyName("temperature_2m_max")]
    public List<double>? Temperature2mMax { get; set; }

    [JsonPropertyName("temperature_2m_min")]
    public List<double>? Temperature2mMin { get; set; }

    [JsonPropertyName("precipitation_probability_max")]
    public List<int>? PrecipitationProbabilityMax { get; set; }
}

public class WeatherForecastResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public int WeatherCode { get; set; }
    public string WeatherDescVi { get; set; } = string.Empty;
    public string WeatherDescEn { get; set; } = string.Empty;
    public double TempMin { get; set; }
    public double TempMax { get; set; }
    public int RainProb { get; set; }
    public string WarningVi { get; set; } = string.Empty;
    public string WarningEn { get; set; } = string.Empty;
}
