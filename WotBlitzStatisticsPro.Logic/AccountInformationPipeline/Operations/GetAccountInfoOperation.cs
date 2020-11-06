using System;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.Pipeline;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class GetAccountInfoOperation: IOperation<AccountInformationPipelineContext>
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

        public async Task Invoke(AccountInformationPipelineContext context, Func<AccountInformationPipelineContext, Task> next)
        {
            var accountInfo = await 
                _wargamingApi.GetPlayerAccountInfo(context.AccountId, context.RealmType, context.RequestLanguage);

            // Store info to AccountInfo and in AccountInfoHistory
            context.AccountInfo = _mapper.Map<WotAccountInfo, AccountInfo>(accountInfo);
            context.AccountInfo.Realm = context.RealmType;

            context.AccountInfoHistory = new AccountInfoHistory(context.AccountId, context.AccountInfo.LastBattleTime);
            _mapper.Map(accountInfo.Statistics.All, context.AccountInfoHistory);

            await next.Invoke(context);
        }
    }
}