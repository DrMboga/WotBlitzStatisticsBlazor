using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class CheckIfHistoryIsEmptyOperation : IOperation<IOperationContext>
    {
        private readonly ILogger<CheckIfHistoryIsEmptyOperation> _logger;

        public CheckIfHistoryIsEmptyOperation(ILogger<CheckIfHistoryIsEmptyOperation> logger)
        {
            _logger = logger;
        }


        public Task Invoke(IOperationContext context, Func<IOperationContext, Task>? next)
        {
            var contextData = context.Get<IStatisticsPipelineData>();

            if (contextData?.History == null ||
                contextData.History.Length == 0)
            {
                _logger.LogInformation(
                    $"History request doesn't return any data");
                return Task.CompletedTask;
            }

            return next != null ? next.Invoke(context) : Task.CompletedTask;
        }
    }
}