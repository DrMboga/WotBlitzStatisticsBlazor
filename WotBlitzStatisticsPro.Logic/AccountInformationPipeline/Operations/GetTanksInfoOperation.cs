using System;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.Logic.Pipeline;
using WotBlitzStatisticsPro.WgApiClient;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class GetTanksInfoOperation: IOperation<AccountInformationPipelineContext>
    {
        private readonly IWargamingTanksApiClient _wargamingApi;
        private readonly IMapper _mapper;

        public GetTanksInfoOperation(
            IWargamingTanksApiClient wargamingApi,
            IMapper mapper)
        {
            _wargamingApi = wargamingApi;
            _mapper = mapper;
        }

        public async Task Invoke(AccountInformationPipelineContext context, Func<AccountInformationPipelineContext, Task> next)
        {
            var tanksInfo = await
                _wargamingApi.GetPlayerAccountTanksInfo(context.AccountId, context.RealmType, context.RequestLanguage);

            await next.Invoke(context);
        }
    }
}