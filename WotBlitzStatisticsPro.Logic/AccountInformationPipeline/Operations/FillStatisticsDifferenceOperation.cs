using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Calculations;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class FillStatisticsDifferenceOperation : IOperation<IOperationContext>
    {
        public Task Invoke(IOperationContext context, Func<IOperationContext, Task> next)
        {
            var contextData = context.Get<IStatisticsPipelineData>();

            if (contextData.History.Length > 1)
            {
                contextData.StatisticsHistory = new StatisticsDifference[contextData.History.Length - 1];
                for (int i = 1; i < contextData.History.Length; i++)
                {
                    contextData.StatisticsHistory[i - 1] = new StatisticsDifference();
                    contextData.StatisticsHistory[i - 1].FillDifference(contextData.History[i - 1], contextData.History[i]);
                }
            }

            return next.Invoke(context);
        }
    }
}