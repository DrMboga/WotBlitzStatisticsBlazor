using System;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Information about tank statistics history
    /// </summary>
    public class TankInfoHistoryResponse
    {
        ///<summary>
        /// Player account identifier
        ///</summary>
        public long AccountId { get; set; }

        ///<summary>
        /// Tank identifier
        ///</summary>
        public long TankId { get; set; }

        /// <summary>
        /// Total time in battle until tank killed
        /// </summary>
        public int BattleLifeTimeInSeconds { get; set; }

        ///<summary>
        /// Last battle
        ///</summary>
        public DateTime LastBattleTime { get; set; } = new DateTime(1970, 1, 1);

        ///<summary>
        /// Mark of Mastery
        ///</summary>
        public MarkOfMastery MarkOfMastery { get; set; }


        /// <summary>
        /// Tank name
        /// </summary>
        public string? Name { get; set; }

        ///<summary>
        /// Is vehicle premium
        ///</summary>
        public bool IsPremium { get; set; }

        ///<summary>
        /// Vehicle type id
        ///</summary>
        public string? Type { get; set; }

        ///<summary>
        /// Vehicle nationId
        ///</summary>
        public string? Nation{ get; set; }

        ///<summary>
        /// Vehicle tier
        ///</summary>
        public int Tier { get; set; }

        /// <summary>
        /// Vehicle preview image
        /// </summary>
        public string? PreviewImage { get; set; }

        /// <summary>
        /// Vehicle normal image
        /// </summary>
        public string? NormalImage { get; set; }


        /// <summary>
        /// Overall statistics since tank was bought
        /// </summary>
        public ShortStatistics? OverallTankStatistics { get; set; }

        /// <summary>
        /// Statistics for period
        /// </summary>
        public ShortStatistics? TankPeriodStatistics { get; set; }

        /// <summary>
        /// Difference between start and end of the period
        /// </summary>
        public StatisticsDifference? PeriodDifference { get; set; }

        /// <summary>
        /// The detailed history
        /// </summary>
        public StatisticsDifference[]? StatisticsHistory { get; set; }
    }
}