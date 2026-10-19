using System.Text.Json;
using DaNgoaiApp.Models;
using Serilog;

namespace DaNgoaiApp.Services;

public static class WeatherService
{
    private static readonly HttpClient _httpClient = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(8)
    };

    public static async Task<WeatherForecastResult> GetForecastAsync(string diaDiem, DateOnly ngayDi)
    {
        var result = new WeatherForecastResult();

        try
        {
            // 1. Geocoding
            string geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(diaDiem)}&count=1&language=vi";
            string geoJson;
            try
            {
                geoJson = await _httpClient.GetStringAsync(geoUrl);
            }
            catch (Exception)
            {
                // Thử tìm kiếm không dấu nếu thất bại
                string unaccented = RemoveDiacritics(diaDiem);
                string fallbackGeoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(unaccented)}&count=1&language=vi";
                geoJson = await _httpClient.GetStringAsync(fallbackGeoUrl);
            }

            var geoData = JsonSerializer.Deserialize<GeocodingResponse>(geoJson);
            if (geoData?.Results == null || geoData.Results.Count == 0)
            {
                result.Success = false;
                result.Message = $"Không tìm thấy địa danh '{diaDiem}'. Hãy thử nhập tên không dấu (ví dụ: Da Lat).";
                return result;
            }

            double lat = geoData.Results[0].Latitude;
            double lon = geoData.Results[0].Longitude;

            // 2. Weather forecast (16 ngày)
            string forecastUrl = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max&timezone=auto&forecast_days=16";
            var forecastJson = await _httpClient.GetStringAsync(forecastUrl);
            var forecastData = JsonSerializer.Deserialize<WeatherApiResponse>(forecastJson);

            if (forecastData?.Daily?.Time == null || forecastData.Daily.Time.Count == 0)
            {
                result.Success = false;
                result.Message = "Không thể lấy dữ liệu thời tiết.";
                return result;
            }

            string targetDateStr = ngayDi.ToString("yyyy-MM-dd");
            int dateIndex = forecastData.Daily.Time.IndexOf(targetDateStr);

            if (dateIndex < 0)
            {
                result.Success = false;
                result.Message = "Ngày đi vượt quá phạm vi dự báo (chỉ hỗ trợ tối đa 16 ngày tới).";
                return result;
            }

            int code = forecastData.Daily.WeatherCode?[dateIndex] ?? 0;
            double tMin = forecastData.Daily.Temperature2mMin?[dateIndex] ?? 0;
            double tMax = forecastData.Daily.Temperature2mMax?[dateIndex] ?? 0;
            int rainProb = forecastData.Daily.PrecipitationProbabilityMax?[dateIndex] ?? 0;

            result.Success = true;
            result.WeatherCode = code;
            result.TempMin = tMin;
            result.TempMax = tMax;
            result.RainProb = rainProb;

            // Diễn giải thời tiết theo weather_code
            InterpretWeatherCode(code, result);

            if (rainProb >= 60)
            {
                result.WarningVi = "⚠️ Xác suất mưa cao (≥60%)! Nên mang theo áo mưa hoặc cân nhắc dời lịch.";
                result.WarningEn = "⚠️ High precipitation probability (≥60%)! Bring a raincoat or consider rescheduling.";
            }

            return result;
        }
        catch (HttpRequestException ex)
        {
            Log.Warning(ex, "Lỗi mạng khi gọi API thời tiết cho {DiaDiem}", diaDiem);
            result.Success = false;
            result.Message = "Lỗi kết nối mạng khi tải dữ liệu thời tiết. Vui lòng kiểm tra internet.";
            return result;
        }
        catch (TaskCanceledException)
        {
            Log.Warning("Timeout khi gọi API thời tiết cho {DiaDiem}", diaDiem);
            result.Success = false;
            result.Message = "Hết thời gian chờ phản hồi từ máy chủ thời tiết (Timeout).";
            return result;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi xử lý API thời tiết cho {DiaDiem}", diaDiem);
            result.Success = false;
            result.Message = "Đã xảy ra lỗi không xác định: " + ex.Message;
            return result;
        }
    }

    private static void InterpretWeatherCode(int code, WeatherForecastResult res)
    {
        if (code == 0)
        {
            res.WeatherDescVi = "☀️ Trời quang đãng";
            res.WeatherDescEn = "☀️ Clear sky";
        }
        else if (code >= 1 && code <= 3)
        {
            res.WeatherDescVi = "⛅ Có mây / Ít mây";
            res.WeatherDescEn = "⛅ Partly cloudy";
        }
        else if (code == 45 || code == 48)
        {
            res.WeatherDescVi = "🌫️ Sương mù";
            res.WeatherDescEn = "🌫️ Foggy";
        }
        else if ((code >= 51 && code <= 67) || (code >= 80 && code <= 82))
        {
            res.WeatherDescVi = "🌧️ Mưa";
            res.WeatherDescEn = "🌧️ Rainy";
        }
        else if (code >= 95 && code <= 99)
        {
            res.WeatherDescVi = "⛈️ Có dông bão";
            res.WeatherDescEn = "⛈️ Thunderstorm";
        }
        else
        {
            res.WeatherDescVi = "🌤️ Thời tiết hỗn hợp";
            res.WeatherDescEn = "🌤️ Moderate conditions";
        }
    }

    private static string RemoveDiacritics(string text)
    {
        string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
            "đ",
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
            "í","ì","ỉ","ĩ","ị",
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
            "ý","ỳ","ỷ","ỹ","ỵ"};
        string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "d",
            "e","e","e","e","e","e","e","e","e","e","e",
            "i","i","i","i","i",
            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
            "u","u","u","u","u","u","u","u","u","u","u",
            "y","y","y","y","y"};
        for (int i = 0; i < arr1.Length; i++)
        {
            text = text.Replace(arr1[i], arr2[i]);
            text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
        }
        return text;
    }
}
