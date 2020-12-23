using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic.Calculations
{
    public static class StatisticsHelper
    {
        public static void FillDifference(
            this StatisticsDifference difference, 
            IStatistics firstItem,
            IStatistics lastItem)
        {
            difference.LastBattleTime = firstItem.LastBattleTime.ToDateTime();
            difference.Battles = new StatisticsDifferenceItem<long>
            {
                CurrentValue = firstItem.Battles ?? 0,
                Difference = firstItem.Battles - lastItem.Battles
            };
            difference.AvgTier = new StatisticsDifferenceItem<double>
            {
                CurrentValue = firstItem.AvgTier,
                Difference = firstItem.AvgTier - lastItem.AvgTier
            };
            difference.Wn7 = new StatisticsDifferenceItem<double>
            {
                CurrentValue = firstItem.Wn7,
                Difference = firstItem.Wn7 - lastItem.Wn7
            };

            decimal firstWinRate = lastItem.Battles.HasValue
                ? 100 * (decimal)(lastItem.Wins ?? 0) /
                  lastItem.Battles.Value
                : 0m;

            decimal lastWinRate = firstItem.Battles.HasValue
                ? 100 * (decimal)(firstItem.Wins ?? 0) /
                  firstItem.Battles.Value
                : 0m;
            difference.WinRate = new StatisticsDifferenceItem<decimal>
            {
                CurrentValue = lastWinRate,
                Difference = lastWinRate - firstWinRate
            };


            decimal firsAvgDmg = lastItem.Battles.HasValue
                ? (decimal)(lastItem.DamageDealt ?? 0) /
                  lastItem.Battles.Value
                : 0m;

            decimal lastAvgDmg = firstItem.Battles.HasValue
                ? (decimal)(firstItem.DamageDealt ?? 0) /
                  firstItem.Battles.Value
                : 0m;
            difference.AvgDamage = new StatisticsDifferenceItem<decimal>
            {
                CurrentValue = lastAvgDmg,
                Difference = lastAvgDmg - firsAvgDmg
            };

            decimal firsAvgXp = lastItem.Battles.HasValue
                ? (decimal)(lastItem.Xp ?? 0) /
                  lastItem.Battles.Value
                : 0m;

            decimal lastAvgXp = firstItem.Battles.HasValue
                ? (decimal)(firstItem.Xp ?? 0) /
                  firstItem.Battles.Value
                : 0m;
            difference.AvgXp = new StatisticsDifferenceItem<decimal>
            {
                CurrentValue = lastAvgXp,
                Difference = lastAvgXp - firsAvgXp
            };

        }
    }
}