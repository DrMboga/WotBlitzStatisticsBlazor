using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.Pipeline;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

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

            context.Tanks = new List<TankInfo>();
            context.TanksHistory = new Dictionary<long, TankInfoHistory>();

            tanksInfo.ForEach(tank =>
            {
                context.Tanks.Add(_mapper.Map<WotAccountTanksStatistics, TankInfo>(tank));
                var stat = _mapper.Map<WotAccountTanksFullStatistics, TankInfoHistory>(tank.All);
                stat.AccountId = tank.AccountId;
                stat.TankId = tank.TankId;
                stat.LastBattleTime = tank.LastBattleTime;
                context.TanksHistory[stat.TankId] = stat;
            });

            await next.Invoke(context);
        }
    }
}