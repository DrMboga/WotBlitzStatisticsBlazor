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
                var tankInfo = new TankInfo(tank.AccountId, tank.TankId);
                _mapper.Map(tank, tankInfo);
                context.Tanks.Add(tankInfo);
                var stat = new TankInfoHistory(tank.AccountId, tank.TankId, tank.LastBattleTime);
                _mapper.Map(tank.All, stat);
                context.TanksHistory[stat.TankId] = stat;
            });

            await next.Invoke(context);
        }
    }
}