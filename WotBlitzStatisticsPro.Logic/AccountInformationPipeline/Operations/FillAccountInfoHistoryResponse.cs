using System;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Calculations;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class FillAccountInfoHistoryResponse : IOperation<IOperationContext>
    {
        public Task Invoke(IOperationContext context, Func<IOperationContext, Task>? next)
        {
            var contextData = context.Get<AccountHistoryInformationPipelineContextData>();

            if (contextData?.DbAccountInfo == null)
            {
                return next != null ? next.Invoke(context) : Task.CompletedTask;
            }

            contextData.Response = new AccountInfoHistoryResponse
            {
                AccountId = context.Request.AccountId,
                CreatedAt = contextData.DbAccountInfo.CreatedAt.ToDateTime(),
                Nickname = contextData.DbAccountInfo.Nickname,
                PeriodDifference = contextData.PeriodDifference,
                StatisticsHistory = contextData.StatisticsHistory,
                PeriodAccountStatistics = contextData.PeriodAccountStatistics,
                OverallAccountStatistics = contextData.OverallStatistics
            };

            return next != null ? next.Invoke(context) : Task.CompletedTask;
        }
    }
}