using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace WotBlitzStatisticsPro.Blazor.Helpers
{
    public static class Formatter
    {
        public static string Json<T>(this T data)
        {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic) });
        }
    }
}