using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline
{
    public interface IStatisticsPipelineData
    {
        IStatistics[] History { get; set; }

        ShortStatistics OverallStatistics { get; set; }

        public ShortStatistics PeriodAccountStatistics { get; set; }

        public StatisticsDifference PeriodDifference { get; set; }

        public StatisticsDifference[] StatisticsHistory { get; set; }

    }
}