using System;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class ReadAccountInfoFromDbOperation : IOperation<IOperationContext>
    {
        private readonly IWargamingAccountDataAccessor _accountDataAccessor;

        public ReadAccountInfoFromDbOperation(IWargamingAccountDataAccessor accountDataAccessor)
        {
            _accountDataAccessor = accountDataAccessor;
        }

        public async Task Invoke(IOperationContext context, Func<IOperationContext, Task>? next)
        {
            var contextData = context.Get<IDatabasePipelineContextData>();

            contextData.DbAccountInfo = await _accountDataAccessor.ReadAccountInfo(context.Request.AccountId);
            if (next != null) await next.Invoke(context);
        }
    }
}