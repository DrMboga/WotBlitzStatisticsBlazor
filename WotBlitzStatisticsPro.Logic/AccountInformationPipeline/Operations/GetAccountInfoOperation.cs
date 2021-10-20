using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Model;
using WotBlitzStatisticsPro.Logic.Pipeline;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class GetAccountInfoOperation: IOperation<IOperationContext>
    {
        private readonly IWargamingApiClient _wargamingApi;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAccountInfoOperation> _logger;
        private readonly StatisticsCache _cache;

        public GetAccountInfoOperation(
            IWargamingApiClient wargamingApi,
            IMapper mapper,
            ILogger<GetAccountInfoOperation> logger,
            StatisticsCache cache)
        {
            _wargamingApi = wargamingApi;
            _mapper = mapper;
            _logger = logger;
            _cache = cache;
        }

        public async Task Invoke(IOperationContext context, Func<IOperationContext, Task>? next)
        {
            // Store info to AccountInfo and in AccountInfoHistory
            var contextData = context.Get<AccountInformationPipelineContextData>();

            var cache = _cache.GetAccountData(context.Request.AccountId);
            if (cache != null)
            {
                contextData.AccountInfo = cache.AccountInfo;
                contextData.AccountInfoHistory = cache.AccountInfoHistory;
                _logger.LogInformation($"Account data for account {context.Request.AccountId} got from cache");

                if (next != null) await next.Invoke(context);
                return;
            }

            var accountInfo = await 
                _wargamingApi.GetPlayerAccountInfo(context.Request.AccountId, context.Request.RealmType, context.Request.RequestLanguage, context.Request.AuthenticationToken);

            if (accountInfo == null)
            {
                _logger.LogInformation(
                    $"Account not found for AccountId {context.Request.AccountId} and {context.Request.RealmType} realm");
                return;
            }

            contextData.AccountInfo = _mapper.Map<WotAccountInfo, AccountInfo>(accountInfo);
            contextData.AccountInfo.Realm = context.Request.RealmType;

            contextData.AccountInfoHistory = new AccountInfoHistory(context.Request.AccountId, contextData.AccountInfo.LastBattleTime);
            _mapper.Map(accountInfo.Statistics?.All, contextData.AccountInfoHistory);

            _cache.SetAccountData(context.Request.AccountId, new AccountDataCache(contextData.AccountInfo, contextData.AccountInfoHistory));

            if (next != null) await next.Invoke(context);
        }
    }
}