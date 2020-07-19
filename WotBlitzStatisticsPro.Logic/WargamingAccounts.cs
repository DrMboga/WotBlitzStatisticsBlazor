using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic
{
    public class WargamingAccounts: IWargamingAccounts
    {
        private readonly IOperationFactory _operationFactory;

        public WargamingAccounts(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public async Task<bool> GatherAccountInformation(RealmType realm, long accountId, RequestLanguage requestLanguage)
        {
            var context = new AccountInformationPipelineContext(accountId, realm, requestLanguage);
            var pipeline = new Pipeline<AccountInformationPipelineContext>(_operationFactory);

            pipeline.AddOperation<GetAccountInfoOperation>()
                .AddOperation<GetTanksInfoOperation>()
                ;
            // ToDo: add other operations

            await pipeline.Build()
                .Invoke(context, null)
                .ConfigureAwait(false);

            // ToDo: return context response

            return true;
        }
    }
}