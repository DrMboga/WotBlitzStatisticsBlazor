using System;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Pipeline;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class GetAccountInfoOperation: IOperation<IOperationContext>
    {
        private readonly IWargamingApiClient _wargamingApi;
        private readonly IMapper _mapper;

        public GetAccountInfoOperation(
            IWargamingApiClient wargamingApi,
            IMapper mapper)
        {
            _wargamingApi = wargamingApi;
            _mapper = mapper;
        }

        public async Task Invoke(IOperationContext context, Func<IOperationContext, Task> next)
        {
            var accountInfo = await 
                _wargamingApi.GetPlayerAccountInfo(context.Request.AccountId, context.Request.RealmType, context.Request.RequestLanguage);

            // Store info to AccountInfo and in AccountInfoHistory
            var contextData = context.Get<AccountInformationPipelineContextData>();
            contextData.AccountInfo = _mapper.Map<WotAccountInfo, AccountInfo>(accountInfo);
            contextData.AccountInfo.Realm = context.Request.RealmType;

            contextData.AccountInfoHistory = new AccountInfoHistory(context.Request.AccountId, contextData.AccountInfo.LastBattleTime);
            _mapper.Map(accountInfo.Statistics.All, contextData.AccountInfoHistory);

            await next.Invoke(context);
        }
    }
}