using System;
using System.Linq;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Calculations;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class ReadAccountInfoHistoryFromDbOperation : IOperation<IOperationContext>
    {
        private readonly IWargamingAccountDataAccessor _accountDataAccessor;

        public ReadAccountInfoHistoryFromDbOperation(IWargamingAccountDataAccessor accountDataAccessor)
        {
            _accountDataAccessor = accountDataAccessor;
        }

        public async Task Invoke(IOperationContext context, Func<IOperationContext, Task> next)
        {
            var contextData = context.Get<AccountHistoryInformationPipelineContextData>();

            contextData.History = (await _accountDataAccessor.GetAccountHistory(context.Request.AccountId, contextData.LastBattleSince.ToUnixTimestamp())).ToArray();
            await next.Invoke(context);
        }
    }
}