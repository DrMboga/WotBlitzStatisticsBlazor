using System;
using System.Linq;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.Calculations;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class CalculateStatisticsOperation : IOperation<AccountInformationPipelineContext>
    {
        private readonly IDictionariesDataAccessor _dictionariesDataAccessor;

        public CalculateStatisticsOperation(IDictionariesDataAccessor dictionariesDataAccessor)
        {
            _dictionariesDataAccessor = dictionariesDataAccessor;
        }

        public async Task Invoke(AccountInformationPipelineContext context, Func<AccountInformationPipelineContext, Task> next)
        {
            var tankIds = context.Tanks.Select(t => t.TankId).ToArray();
            var tankTires = await _dictionariesDataAccessor.GetTankTires(tankIds);

            foreach (var tankInfoHistory in context.TanksHistory)
            {
                if (!tankTires.ContainsKey(tankInfoHistory.Key))
                {
                    continue;
                }
                tankInfoHistory.Value.CalculateWn7(tankTires[tankInfoHistory.Key]);
            }

            context.AccountInfoHistory.CalculateMiddleTier(context.TanksHistory.Values.ToList(), tankTires);
            context.AccountInfoHistory.CalculateWn7();

            await next.Invoke(context);
        }
    }
}