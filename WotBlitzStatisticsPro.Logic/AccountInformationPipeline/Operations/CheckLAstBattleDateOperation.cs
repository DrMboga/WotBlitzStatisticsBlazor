using System;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class CheckLAstBattleDateOperation : IOperation<AccountInformationPipelineContext>
    {
        public Task Invoke(AccountInformationPipelineContext context, Func<AccountInformationPipelineContext, Task> next)
        {
            if (context.DbAccountInfo == null ||
                context.DbAccountInfo.LastBattleTime >= context.AccountInfo.LastBattleTime)
            {
                return next.Invoke(context);
            }
            return Task.CompletedTask;
        }
    }
}