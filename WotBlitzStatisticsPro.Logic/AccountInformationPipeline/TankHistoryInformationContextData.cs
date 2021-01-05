using System;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline
{
    public class TankHistoryInformationContextData: IDatabaseTankPipelineContextData, IStatisticsPipelineData
    {
        public TankHistoryInformationContextData(DateTime lastBattleSince, long tankId)
        {
            LastBattleSince = lastBattleSince;
            TankId = tankId;
        }

        public DateTime LastBattleSince { get; }

        public long TankId { get; }

        public TankInfo? DbTankInfo { get; set; }

        public IStatistics[]? History { get; set; }
        public ShortStatistics? OverallStatistics { get; set; }
        public ShortStatistics? PeriodAccountStatistics { get; set; }
        public StatisticsDifference? PeriodDifference { get; set; }
        public StatisticsDifference[]? StatisticsHistory { get; set; }

        public TankInfoHistoryResponse? Response { get; set; }
    }
}