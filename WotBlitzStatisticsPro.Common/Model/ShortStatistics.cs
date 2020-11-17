using System;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Short statistics info
    /// </summary>
    public class ShortStatistics
    {
        ///<summary>
        /// Last battle time
        ///</summary>
        public DateTime LastBattleTime { get; set; }

        ///<summary>
        /// Battles count
        ///</summary>
        public long Battles { get; set; }

        /// <summary>
        /// Average tier
        /// </summary>
        public double AvgTier { get; set; }

        /// <summary>
        /// Wn7 coefficient
        /// </summary>
        public double Wn7 { get; set; }

        /// <summary>
        /// Player's win rate
        /// </summary>
        public decimal WinRate { get; set; }

        /// <summary>
        /// Player's average damage
        /// </summary>
        public decimal AvgDamage { get; set; }

        /// <summary>
        /// Player's average XP
        /// </summary>
        public decimal AvgXp { get; set; }

    }
}