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

        // ToDo: Write months, days, hours and minutes scenarios
    }
}