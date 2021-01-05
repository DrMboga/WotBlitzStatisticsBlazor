using System;
using System.Linq;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Calculations;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class FillTankHistoryResponseOperation : IOperation<IOperationContext>
    {
        private readonly IDictionariesDataAccessor _wargamingDictionaries;

        public FillTankHistoryResponseOperation(IDictionariesDataAccessor wargamingDictionaries)
        {
            _wargamingDictionaries = wargamingDictionaries;
        }

        public async Task Invoke(IOperationContext context, Func<IOperationContext, Task>? next)
        {
            var contextData = context.Get<TankHistoryInformationContextData>();

            if (contextData?.DbTankInfo == null)
            {
                if (next != null) await next.Invoke(context);
                return;
            }

            var nations = await _wargamingDictionaries.GetNations(context.Request.RequestLanguage);
            var tankTypes = await _wargamingDictionaries.GetTankTypes(context.Request.RequestLanguage);

            var vehicleInfos = await _wargamingDictionaries.GetVehicles(new[] {contextData.TankId});
            var vehicleInfo = vehicleInfos[contextData.TankId];

            contextData.Response = new TankInfoHistoryResponse
            {
                TankId = contextData.TankId,
                LastBattleTime = contextData.DbTankInfo.LastBattleTime.ToDateTime(),
                BattleLifeTimeInSeconds = contextData.DbTankInfo.BattleLifeTimeInSeconds,
                MarkOfMastery = contextData.DbTankInfo.MarkOfMastery,
                Name = vehicleInfo.Name.FirstOrDefault(n => n.Language == context.Request.RequestLanguage)?.Value,
                IsPremium = vehicleInfo.IsPremium,
                Tier = vehicleInfo.Tier,
                NormalImage = vehicleInfo.NormalImage,
                PreviewImage = vehicleInfo.PreviewImage,
                Nation = nations[vehicleInfo.NationId],
                Type = tankTypes[vehicleInfo.TypeId],

                AccountId = context.Request.AccountId,
                PeriodDifference = contextData.PeriodDifference,
                StatisticsHistory = contextData.StatisticsHistory,
                TankPeriodStatistics = contextData.PeriodAccountStatistics,
                OverallTankStatistics = contextData.OverallStatistics
            };

            if (next != null) await next.Invoke(context);
        }
    }
}