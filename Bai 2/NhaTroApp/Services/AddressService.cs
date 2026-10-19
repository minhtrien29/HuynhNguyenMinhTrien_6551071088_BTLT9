using System.Text.Json;
using NhaTroApp.Models;
using Serilog;

namespace NhaTroApp.Services;

public static class AddressService
{
    private static readonly HttpClient _httpClient = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(10)
    };

    public static async Task<List<ProvinceItem>> GetProvincesAsync()
    {
        try
        {
            string url = "https://provinces.open-api.vn/api/v2/";
            var response = await _httpClient.GetStringAsync(url);
            var list = JsonSerializer.Deserialize<List<ProvinceItem>>(response);
            return list ?? new List<ProvinceItem>();
        }
        catch (HttpRequestException ex)
        {
            Log.Warning(ex, "Lỗi mạng khi tải danh sách tỉnh/thành từ API.");
            throw;
        }
        catch (TaskCanceledException ex)
        {
            Log.Warning(ex, "Timeout khi tải danh sách tỉnh/thành từ API.");
            throw;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi không xác định khi gọi API tỉnh/thành.");
            throw;
        }
    }

    public static async Task<List<WardItem>> GetWardsAsync(int provinceCode)
    {
        try
        {
            string url = $"https://provinces.open-api.vn/api/v2/p/{provinceCode}?depth=2";
            var response = await _httpClient.GetStringAsync(url);
            var detail = JsonSerializer.Deserialize<ProvinceDetail>(response);
            return detail?.Wards ?? new List<WardItem>();
        }
        catch (HttpRequestException ex)
        {
            Log.Warning(ex, "Lỗi mạng khi tải phường/xã cho tỉnh mã {ProvinceCode}.", provinceCode);
            throw;
        }
        catch (TaskCanceledException ex)
        {
            Log.Warning(ex, "Timeout khi tải phường/xã cho tỉnh mã {ProvinceCode}.", provinceCode);
            throw;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi không xác định khi gọi API phường/xã.");
            throw;
        }
    }
}
