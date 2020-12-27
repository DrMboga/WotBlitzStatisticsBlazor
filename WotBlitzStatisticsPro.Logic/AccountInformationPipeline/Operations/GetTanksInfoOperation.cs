using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Pipeline;
using WotBlitzStatisticsPro.WgApiClient;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class GetTanksInfoOperation: IOperation<IOperationContext>
    {
        private readonly IWargamingTanksApiClient _wargamingApi;
        private readonly IMapper _mapper;
        private readonly ILogger<GetTanksInfoOperation> _logger;

        public GetTanksInfoOperation(
            IWargamingTanksApiClient wargamingApi,
            IMapper mapper,
            ILogger<GetTanksInfoOperation> logger)
        {
            _wargamingApi = wargamingApi;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Invoke(IOperationContext context, Func<IOperationContext, Task>? next)
        {
            var contextData = context.Get<AccountInformationPipelineContextData>();

            var tanksInfo = await
                _wargamingApi.GetPlayerAccountTanksInfo(context.Request.AccountId, context.Request.RealmType, context.Request.RequestLanguage);

            if (tanksInfo == null)
            {
                _logger.LogInformation(
                    $"Tanks not found for AccountId {context.Request.AccountId} and {context.Request.RealmType} realm");
                return;
            }

            contextData.Tanks = new List<TankInfo>();
            contextData.TanksHistory = new Dictionary<long, TankInfoHistory>();

            tanksInfo.OrderByDescending(t => t.LastBattleTime).ToList().ForEach(tank =>
            {
                var tankInfo = new TankInfo(tank.AccountId, tank.TankId);
                _mapper.Map(tank, tankInfo);
                contextData.Tanks.Add(tankInfo);
                var stat = new TankInfoHistory(tank.AccountId, tank.TankId, tank.LastBattleTime);
                _mapper.Map(tank.All, stat);
                contextData.TanksHistory[stat.TankId] = stat;
            });

            if (next != null) await next.Invoke(context);
        }
    }
}