using System;
using Microsoft.Extensions.Localization;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Helpers
{
    public static class DateDifferenceHelper
    {
        public static DateTime ConvertToLocalTime(this DateTimeOffset dateToConvert)
        {
            var specifiedTimeConvert = DateTime.SpecifyKind(dateToConvert.DateTime, DateTimeKind.Utc);
            return specifiedTimeConvert.ToLocalTime();
        }

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

        public static string SinceTime(this DateTimeOffset time, IStringLocalizer<App> localizer)
        {
            return time.DateTime.SinceTime(localizer);
        }

        public static string SinceTime(this DateTime time, IStringLocalizer<App> localizer)
        {
            var currentDate = DateTime.Now;

            var difference = ParseTheDifference(currentDate - time);
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
            if (difference.TotalHours < 1)
            {
                return (Convert.ToInt32(difference.TotalMinutes), TimeInterval.Minute);
            }

            if (difference.TotalDays < 1)
            {
                return (Convert.ToInt32(difference.TotalHours), TimeInterval.Hour);
            }

            return difference.TotalDays switch
            {
                >= 365 => (CalculateYears(difference.TotalDays), TimeInterval.Year),
                (>= 30) and (< 365) => (CalculateMonths(difference.TotalDays), TimeInterval.Month),
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