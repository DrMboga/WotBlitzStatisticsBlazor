using System;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Calculations;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class FillPeriodDifferenceOperation : IOperation<IOperationContext>
    {
        public Task Invoke(IOperationContext context, Func<IOperationContext, Task> next)
        {
            var contextData = context.Get<IStatisticsPipelineData>();

            if (contextData.History.Length > 1)
            {
                contextData.PeriodDifference = new StatisticsDifference();
                var historyLastIndex = contextData.History.Length - 1;

                contextData.PeriodDifference.FillDifference(contextData.History[0], contextData.History[historyLastIndex]);
            }

            return next.Invoke(context);
        }
    }
}