using System;
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

        public static string RomanNumber(this int number)
        {
            var romanNumerals = new[] {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
            var numerals = new[] {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};

            if (number <= 0)
            {
                return number.ToString();
            }

            string result  = "";

            while (number > 0)
            {
                // find biggest numeral that is less than equal to number
                var index = Array.FindIndex(numerals, n => n <= number);

                // subtract it's value from your number
                number -= numerals[index];

                // tack it onto the end of your roman numeral
                result = string.Concat(result, romanNumerals[index]);
            }

            return result;
        }
    }
}