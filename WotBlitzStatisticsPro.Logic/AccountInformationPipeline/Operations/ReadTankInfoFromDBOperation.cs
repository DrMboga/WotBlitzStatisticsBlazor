using System;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class ReadTankInfoFromDbOperation : IOperation<IOperationContext>
    {
        private readonly IWargamingAccountDataAccessor _accountDataAccessor;

        public ReadTankInfoFromDbOperation(IWargamingAccountDataAccessor accountDataAccessor)
        {
            _accountDataAccessor = accountDataAccessor;
        }

        public async Task Invoke(IOperationContext context, Func<IOperationContext, Task>? next)
        {
            var contextData = context.Get<IDatabaseTankPipelineContextData>();

            contextData.DbTankInfo = await _accountDataAccessor.ReadTankInfo(context.Request.AccountId, contextData.TankId);
            if (next != null) await next.Invoke(context);
        }
    }
}