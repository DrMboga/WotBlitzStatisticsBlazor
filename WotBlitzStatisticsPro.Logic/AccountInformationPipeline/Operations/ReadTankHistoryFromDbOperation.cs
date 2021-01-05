using System;
using System.Linq;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Calculations;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class ReadTankHistoryFromDbOperation : IOperation<IOperationContext>
    {
        private readonly IWargamingAccountDataAccessor _accountDataAccessor;

        public ReadTankHistoryFromDbOperation(IWargamingAccountDataAccessor accountDataAccessor)
        {
            _accountDataAccessor = accountDataAccessor;
        }

        public async Task Invoke(IOperationContext context, Func<IOperationContext, Task>? next)
        {
            var contextData = context.Get<TankHistoryInformationContextData>();

            contextData.History = (await _accountDataAccessor.GetTankHistory(context.Request.AccountId, contextData.TankId, contextData.LastBattleSince.ToUnixTimestamp())).ToArray();
            if (next != null) await next.Invoke(context);

        }
    }
}