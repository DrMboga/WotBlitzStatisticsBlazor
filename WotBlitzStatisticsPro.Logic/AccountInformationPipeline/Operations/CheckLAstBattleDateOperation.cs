using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class CheckLastBattleDateOperation : IOperation<AccountInformationPipelineContext>
    {
        private readonly ILogger<CheckLastBattleDateOperation> _logger;

        public CheckLastBattleDateOperation(ILogger<CheckLastBattleDateOperation> logger)
        {
            _logger = logger;
        }

        public Task Invoke(AccountInformationPipelineContext context, Func<AccountInformationPipelineContext, Task> next)
        {
            if (context.DbAccountInfo == null ||
                context.DbAccountInfo.LastBattleTime >= context.AccountInfo.LastBattleTime)
            {
                return next.Invoke(context);
            }
            _logger.LogInformation($"Exiting without saving. Db LastBattleTime: {context.DbAccountInfo.LastBattleTime}, WG LastBattleTime: {context.AccountInfo.LastBattleTime}");
            return Task.CompletedTask;
        }
    }
}