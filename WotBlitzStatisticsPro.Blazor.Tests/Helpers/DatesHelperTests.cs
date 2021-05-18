using System;
using FluentAssertions;
using NUnit.Framework;
using WotBlitzStatisticsPro.Blazor.Helpers;
using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor.Tests.Helpers
{
    public class DatesHelperTests
    {
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void ShouldCalculateYears()
        {
            var currentDate = new DateTime(2021, 5, 18);

            for (int i = 0; i < 10; i++)
            {
                var initialTime = currentDate.AddYears(-(1 + i * 3)).AddMonths(-i).AddDays(-i);
                var result = DateDifferenceHelper.ParseTheDifference(currentDate - initialTime);
                result.interval.Should().Be(TimeInterval.Year);
                result.value.Should().Be(1 + i * 3);
            }
        }

        [Test]
        public void ShouldCalculateMonths()
        {
            var currentDate = new DateTime(2021, 5, 18);

            for (int i = 0; i < 5; i++)
            {
                var initialTime = currentDate.AddMonths(-(1 + i * 2)).AddDays(-i);
                var result = DateDifferenceHelper.ParseTheDifference(currentDate - initialTime);
                result.interval.Should().Be(TimeInterval.Month, $"iterator {i}");
                result.value.Should().Be(1 + i * 2);
            }
        }

        [Test]
        public void ShouldCalculateDays()
        {
            var currentDate = new DateTime(2021, 5, 18);

            for (int i = 0; i < 5; i++)
            {
                var initialTime = currentDate.AddDays(-(1 + i * 2)).AddHours(-i);
                var result = DateDifferenceHelper.ParseTheDifference(currentDate - initialTime);
                result.interval.Should().Be(TimeInterval.Day, $"iterator {i}");
                result.value.Should().Be(1 + i * 2);
            }
        }

        [Test]
        public void ShouldCalculateHours()
        {
            var currentDate = new DateTime(2021, 5, 18);

            for (int i = 0; i < 5; i++)
            {
                var initialTime = currentDate.AddHours(-(1 + i * 2)).AddMinutes(-i);
                var result = DateDifferenceHelper.ParseTheDifference(currentDate - initialTime);
                result.interval.Should().Be(TimeInterval.Hour, $"iterator {i}");
                result.value.Should().Be(1 + i * 2);
            }
        }

        [Test]
        public void ShouldCalculateMinutes()
        {
            var currentDate = new DateTime(2021, 5, 18);

            for (int i = 0; i < 5; i++)
            {
                var initialTime = currentDate.AddMinutes(-(1 + i * 2)).AddSeconds(-i);
                var result = DateDifferenceHelper.ParseTheDifference(currentDate - initialTime);
                result.interval.Should().Be(TimeInterval.Minute, $"iterator {i}");
                result.value.Should().Be(1 + i * 2);
            }
        }
    }
}