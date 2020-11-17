using System;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// The difference between current statistics state and previous
    /// </summary>
    public class StatisticsDifference
    {
        ///<summary>
        /// Last battle time
        ///</summary>
        public DateTime LastBattleTime { get; set; }

        ///<summary>
        /// Difference in Battles count
        ///</summary>
        public StatisticsDifferenceItem<long> Battles { get; set; }

        /// <summary>
        /// Difference in Average tier
        /// </summary>
        public StatisticsDifferenceItem<double> AvgTier { get; set; }

        /// <summary>
        /// Difference in Wn7 coefficient
        /// </summary>
        public StatisticsDifferenceItem<double> Wn7 { get; set; }

        /// <summary>
        /// Difference in Player's win rate
        /// </summary>
        public StatisticsDifferenceItem<decimal> WinRate { get; set; }

        /// <summary>
        /// Difference in Player's average damage
        /// </summary>
        public StatisticsDifferenceItem<decimal> AvgDamage { get; set; }

        /// <summary>
        /// Difference in Player's average XP
        /// </summary>
        public StatisticsDifferenceItem<decimal> AvgXp { get; set; }

    }
}