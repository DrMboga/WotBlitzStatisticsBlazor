using System;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Information about player statistics history
    /// </summary>
    public class AccountInfoHistoryResponse
    {
        ///<summary>
        /// Player account identifier
        ///</summary>
        public long AccountId { get; set; }

        ///<summary>
        /// Account creation date
        ///</summary>
        public DateTime CreatedAt { get; set; }

        ///<summary>
        /// Player's nick
        ///</summary>
        public string? Nickname { get; set; }

        /// <summary>
        /// Overall statistics since account creation
        /// </summary>
        public ShortStatistics? OverallAccountStatistics { get; set; }

        /// <summary>
        /// Statistics for period
        /// </summary>
        public ShortStatistics? PeriodAccountStatistics { get; set; }

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