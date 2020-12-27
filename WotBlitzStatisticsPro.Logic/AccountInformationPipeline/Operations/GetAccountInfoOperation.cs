using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GetAccountInfoOperation> _logger;

        public GetAccountInfoOperation(
            IWargamingApiClient wargamingApi,
            IMapper mapper,
            ILogger<GetAccountInfoOperation> logger)
        {
            _wargamingApi = wargamingApi;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Invoke(IOperationContext context, Func<IOperationContext, Task>? next)
        {
            var accountInfo = await 
                _wargamingApi.GetPlayerAccountInfo(context.Request.AccountId, context.Request.RealmType, context.Request.RequestLanguage);

            if (accountInfo == null)
            {
                _logger.LogInformation(
                    $"Account not found for AccountId {context.Request.AccountId} and {context.Request.RealmType} realm");
                return;
            }

            // Store info to AccountInfo and in AccountInfoHistory
            var contextData = context.Get<AccountInformationPipelineContextData>();
            contextData.AccountInfo = _mapper.Map<WotAccountInfo, AccountInfo>(accountInfo);
            contextData.AccountInfo.Realm = context.Request.RealmType;

            contextData.AccountInfoHistory = new AccountInfoHistory(context.Request.AccountId, contextData.AccountInfo.LastBattleTime);
            _mapper.Map(accountInfo.Statistics?.All, contextData.AccountInfoHistory);

            if (next != null) await next.Invoke(context);
        }
    }
}