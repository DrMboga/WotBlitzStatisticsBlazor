using System;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline
{
    public class AccountHistoryInformationPipelineContextData: IDatabasePipelineContextData, IStatisticsPipelineData
    {
        public AccountHistoryInformationPipelineContextData(DateTime lastBattleSince)
        {
            LastBattleSince = lastBattleSince;
        }

        public DateTime LastBattleSince { get; }

        public AccountInfo? DbAccountInfo { get; set; }

        public IStatistics[]? History { get; set; }
        public ShortStatistics? OverallStatistics { get; set; }
        public ShortStatistics? PeriodAccountStatistics { get; set; }
        public StatisticsDifference? PeriodDifference { get; set; }
        public StatisticsDifference[]? StatisticsHistory { get; set; }

        public AccountInfoHistoryResponse? Response { get; set; }
    }
}