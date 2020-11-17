using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Pipeline;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class GetTanksInfoOperation: IOperation<IOperationContext>
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

        public async Task Invoke(IOperationContext context, Func<IOperationContext, Task> next)
        {
            var contextData = context.Get<AccountInformationPipelineContextData>();

            var tanksInfo = await
                _wargamingApi.GetPlayerAccountTanksInfo(context.Request.AccountId, context.Request.RealmType, context.Request.RequestLanguage);

            contextData.Tanks = new List<TankInfo>();
            contextData.TanksHistory = new Dictionary<long, TankInfoHistory>();

            tanksInfo.ForEach(tank =>
            {
                var tankInfo = new TankInfo(tank.AccountId, tank.TankId);
                _mapper.Map(tank, tankInfo);
                contextData.Tanks.Add(tankInfo);
                var stat = new TankInfoHistory(tank.AccountId, tank.TankId, tank.LastBattleTime);
                _mapper.Map(tank.All, stat);
                contextData.TanksHistory[stat.TankId] = stat;
            });

            await next.Invoke(context);
        }
    }
}