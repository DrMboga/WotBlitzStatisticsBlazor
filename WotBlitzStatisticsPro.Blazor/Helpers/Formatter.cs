using System.Text.Json;

namespace WotBlitzStatisticsPro.Blazor.Helpers
{
    public static class Formatter
    {
        public static string Json<T>(this T data)
        {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}