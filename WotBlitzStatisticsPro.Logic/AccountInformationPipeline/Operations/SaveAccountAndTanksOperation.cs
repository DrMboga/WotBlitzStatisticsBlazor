using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations
{
    public class SaveAccountAndTanksOperation : IOperation<AccountInformationPipelineContext>
    {
        private readonly IWargamingAccountDataAccessor _accountDataAccessor;
        private readonly ILogger<SaveAccountAndTanksOperation> _logger;

        public SaveAccountAndTanksOperation(
            IWargamingAccountDataAccessor accountDataAccessor,
            ILogger<SaveAccountAndTanksOperation> logger)
        {
            _accountDataAccessor = accountDataAccessor;
            _logger = logger;
        }

        public async Task Invoke(AccountInformationPipelineContext context, Func<AccountInformationPipelineContext, Task> next)
        {
            await _accountDataAccessor.AddOurUpdateAccountInfo(context.AccountInfo);
            await _accountDataAccessor.AddAccountInfoHistory(context.AccountInfoHistory);

            var tanksCount = 0;
            var tankIdsAsString = new StringBuilder();

            foreach (var tankInfo in context.Tanks)
            {
                var tankFromDb = await _accountDataAccessor.ReadTankInfo(tankInfo.AccountId, tankInfo.TankId);
                if (tankFromDb == null || tankInfo.LastBattleTime > tankFromDb.LastBattleTime)
                {
                    await _accountDataAccessor.AddOrUpdateTankInfo(tankInfo);
                    await _accountDataAccessor.AddTankInfoHistory(context.TanksHistory[tankInfo.TankId]);
                    tanksCount++;
                    tankIdsAsString.Append($" {tankInfo.TankId}; ");
                }
            }

            _logger.LogInformation($"Updated account {context.AccountInfo.AccountId} and {tanksCount} tanks: {tankIdsAsString}");

            await next.Invoke(context);
        }
    }
}