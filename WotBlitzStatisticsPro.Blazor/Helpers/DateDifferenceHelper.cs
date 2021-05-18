using System;
using Microsoft.Extensions.Localization;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Helpers
{
    public static class DateDifferenceHelper
    {
        public static string SinceTime(this int timeInLinuxTimeStamp, IStringLocalizer<App> localizer)
        {
            var currentDate = DateTime.Now;
            var timeToCalculate = new DateTime(1970, 1, 1) + TimeSpan.FromSeconds(timeInLinuxTimeStamp);

            var difference = ParseTheDifference(currentDate - timeToCalculate);
            string ago = difference.interval switch
            {
                TimeInterval.Year => localizer.GetString("years ago"),
                TimeInterval.Month => localizer.GetString("months ago"),
                TimeInterval.Day => localizer.GetString("days ago"),
                TimeInterval.Hour => localizer.GetString("hours ago"),
                TimeInterval.Minute => localizer.GetString("minutes ago")
            };

            return $"{difference.value} {ago}";
        }

        public static (int value, TimeInterval interval) ParseTheDifference(TimeSpan difference)
        {
            // ToDo: Check hours and mins if Days is 0
            return difference.TotalDays switch
            {
                >= 365 => (CalculateYears(difference.TotalDays), TimeInterval.Year),
                (> 30) and (< 365) => (CalculateMonths(difference.TotalDays), TimeInterval.Month),
                _ => (Convert.ToInt32(difference.TotalDays), TimeInterval.Day)
            };
        }

        private static int CalculateYears(double days)
        {
            return Convert.ToInt32(days) / 365;
        }

        private static int CalculateMonths(double days)
        {
            return Convert.ToInt32(days) / 30;
        }
    }
}