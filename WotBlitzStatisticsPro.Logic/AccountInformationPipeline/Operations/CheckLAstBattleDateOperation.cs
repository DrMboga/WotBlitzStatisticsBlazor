using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class CheckLastBattleDateOperation : IOperation<IOperationContext>
    {
        private readonly ILogger<CheckLastBattleDateOperation> _logger;

        public CheckLastBattleDateOperation(ILogger<CheckLastBattleDateOperation> logger)
        {
            _logger = logger;
        }

        public Task Invoke(IOperationContext context, Func<IOperationContext, Task> next)
        {
            var contextData = context.Get<AccountInformationPipelineContextData>();

            if (contextData.DbAccountInfo == null ||
                contextData.DbAccountInfo.LastBattleTime < contextData.AccountInfo.LastBattleTime)
            {
                return next.Invoke(context);
            }
            _logger.LogInformation($"Exiting without saving. Db LastBattleTime: {contextData.DbAccountInfo.LastBattleTime}, WG LastBattleTime: {contextData.AccountInfo.LastBattleTime}");
            return Task.CompletedTask;
        }
    }
}