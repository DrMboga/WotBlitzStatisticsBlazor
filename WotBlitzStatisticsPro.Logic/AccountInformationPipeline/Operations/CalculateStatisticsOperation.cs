using System;
using System.Linq;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Calculations;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class CalculateStatisticsOperation : IOperation<IOperationContext>
    {
        private readonly IDictionariesDataAccessor _dictionariesDataAccessor;

        public CalculateStatisticsOperation(IDictionariesDataAccessor dictionariesDataAccessor)
        {
            _dictionariesDataAccessor = dictionariesDataAccessor;
        }

        public async Task Invoke(IOperationContext context, Func<IOperationContext, Task> next)
        {
            var contextData = context.Get<AccountInformationPipelineContextData>();

            var tankIds = contextData.Tanks.Select(t => t.TankId).ToArray();
            var tankTires = await _dictionariesDataAccessor.GetTankTires(tankIds);

            foreach (var tankInfoHistory in contextData.TanksHistory)
            {
                if (!tankTires.ContainsKey(tankInfoHistory.Key))
                {
                    continue;
                }
                tankInfoHistory.Value.CalculateWn7(tankTires[tankInfoHistory.Key]);
            }

            contextData.AccountInfoHistory.CalculateMiddleTier(contextData.TanksHistory.Values.ToList(), tankTires);
            contextData.AccountInfoHistory.CalculateWn7();

            await next.Invoke(context);
        }
    }
}