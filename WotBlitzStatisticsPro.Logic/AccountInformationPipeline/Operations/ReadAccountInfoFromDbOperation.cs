using System;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class ReadAccountInfoFromDbOperation : IOperation<AccountInformationPipelineContext>
    {
        private readonly IWargamingAccountDataAccessor _accountDataAccessor;

        public ReadAccountInfoFromDbOperation(IWargamingAccountDataAccessor accountDataAccessor)
        {
            _accountDataAccessor = accountDataAccessor;
        }

        public async Task Invoke(AccountInformationPipelineContext context, Func<AccountInformationPipelineContext, Task> next)
        {
            context.DbAccountInfo = await _accountDataAccessor.ReadAccountInfo(context.AccountId);
            await next.Invoke(context);
        }
    }
}