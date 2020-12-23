using System;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class FillPeriodStatisticsOperation : IOperation<IOperationContext>
    {
        private readonly IMapper _mapper;

        public FillPeriodStatisticsOperation(IMapper mapper)
        {
            _mapper = mapper;
        }


        public Task Invoke(IOperationContext context, Func<IOperationContext, Task> next)
        {
            var contextData = context.Get<IStatisticsPipelineData>();

            if (contextData.History.Length > 1)
            {
                var diff = new AccountInfoHistory(context.Request.AccountId, contextData.History[0].LastBattleTime);

                var historyLastIndex = contextData.History.Length - 1;

                diff.Battles = contextData.History[0].Battles - contextData.History[historyLastIndex].Battles;
                diff.Wins = contextData.History[0].Wins - contextData.History[historyLastIndex].Wins;
                diff.DamageDealt = contextData.History[0].DamageDealt - contextData.History[historyLastIndex].DamageDealt;
                diff.Xp = contextData.History[0].Xp - contextData.History[historyLastIndex].Xp;

                contextData.PeriodAccountStatistics = _mapper.Map<IStatistics, ShortStatistics>(diff);
            }

            return next.Invoke(context);
        }
    }
}