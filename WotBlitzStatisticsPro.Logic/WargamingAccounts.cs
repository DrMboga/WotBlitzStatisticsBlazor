using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;
using WotBlitzStatisticsPro.Logic.Calculations;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic
{
    public class WargamingAccounts: IWargamingAccounts
    {
        private readonly IOperationFactory _operationFactory;
        private readonly ILogger<WargamingAccounts> _logger;

        public WargamingAccounts(IOperationFactory operationFactory, ILogger<WargamingAccounts> logger)
        {
            _operationFactory = operationFactory;
            _logger = logger;
        }

        public async Task<AccountInfoResponse> GatherAccountInformation(
            RealmType realm, 
            long accountId,
            RequestLanguage requestLanguage)
        {
            var contextData = new AccountInformationPipelineContextData();
            try
            {

                var context = new OperationContext(new AccountRequest(accountId, realm, requestLanguage));
                context.AddOrReplace(contextData);
                var pipeline = new Pipeline<IOperationContext>(_operationFactory);

                pipeline.AddOperation<GetAccountInfoOperation>()
                    .AddOperation<GetTanksInfoOperation>()
                    .AddOperation<CalculateStatisticsOperation>()
                    .AddOperation<BuildAccountInfoResponseOperation>()
                    ;

                var firstOperation = pipeline.Build();
                if (firstOperation != null)
                {
                    await firstOperation
                        .Invoke(context, null)
                        .ConfigureAwait(false);
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "GatherAccountInformation error");

                throw;
            }

            return contextData?.Response ?? new AccountInfoResponse();
        }

        public async Task<DateTime> GatherAndSaveAccountInformation(
            RealmType realm, 
            long accountId, 
            RequestLanguage requestLanguage,
            string wargamingToken)
        {
            var contextData = new AccountInformationPipelineContextData();
            try
            {

                var context = new OperationContext(new AccountRequest(accountId, realm, requestLanguage, wargamingToken));
                context.AddOrReplace(contextData);
                var pipeline = new Pipeline<IOperationContext>(_operationFactory);

                pipeline.AddOperation<GetAccountInfoOperation>()
                    .AddOperation<ReadAccountInfoFromDbOperation>()
                    .AddOperation<CheckLastBattleDateOperation>()
                    .AddOperation<GetTanksInfoOperation>()
                    .AddOperation<CalculateStatisticsOperation>()
                    .AddOperation<SaveAccountAndTanksOperation>()
                    ;

                var firstOperation = pipeline.Build();
                if (firstOperation != null)
                {
                    await firstOperation
                        .Invoke(context, null)
                        .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GatherAndSaveAccountInformation error");

                throw;
            }
            return contextData?.AccountInfo?.LastBattleTime.ToDateTime() ?? new DateTime(1970,1,1);
        }

        public async Task<AccountInfoHistoryResponse> GetAccountInfoHistory(RealmType realm, long accountId, DateTime startDate, RequestLanguage requestLanguage)
        {
            var contextData = new AccountHistoryInformationPipelineContextData(startDate);
            try
            {
                var context = new OperationContext(new AccountRequest(accountId, realm, requestLanguage));
                context.AddOrReplace(contextData);
                var pipeline = new Pipeline<IOperationContext>(_operationFactory);

                pipeline.AddOperation<ReadAccountInfoFromDbOperation>()
                    .AddOperation<ReadAccountInfoHistoryFromDbOperation>()
                    .AddOperation<CheckIfHistoryIsEmptyOperation>()
                    .AddOperation<FillOverallStatisticsOperation>()
                    .AddOperation<FillPeriodStatisticsOperation>()
                    .AddOperation<FillPeriodDifferenceOperation>()
                    .AddOperation<FillStatisticsDifferenceOperation>()
                    .AddOperation<FillAccountInfoHistoryResponse>()
                    ;

                var firstOperation = pipeline.Build();
                if (firstOperation != null)
                {
                    await firstOperation
                        .Invoke(context, null)
                        .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GetAccountInfoHistory error");
                throw;
            }
            return contextData?.Response ?? new AccountInfoHistoryResponse();
        }

        public async Task<TankInfoHistoryResponse> GetTankInfoHistory(RealmType realm, long accountId, long tankId, DateTime startDate,
            RequestLanguage requestLanguage)
        {
            var contextData = new TankHistoryInformationContextData(startDate, tankId);
            try
            {
                var context = new OperationContext(new AccountRequest(accountId, realm, requestLanguage));
                context.AddOrReplace(contextData);
                var pipeline = new Pipeline<IOperationContext>(_operationFactory);

                pipeline.AddOperation<ReadTankInfoFromDbOperation>()
                    .AddOperation<ReadTankHistoryFromDbOperation>()
                    .AddOperation<CheckIfHistoryIsEmptyOperation>()
                    .AddOperation<FillOverallStatisticsOperation>()
                    .AddOperation<FillPeriodStatisticsOperation>()
                    .AddOperation<FillPeriodDifferenceOperation>()
                    .AddOperation<FillStatisticsDifferenceOperation>()
                    .AddOperation<FillTankHistoryResponseOperation>()
                    ;

                var firstOperation = pipeline.Build();
                if (firstOperation != null)
                {
                    await firstOperation
                        .Invoke(context, null)
                        .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GetAccountInfoHistory error");
                throw;
            }
            return contextData?.Response ?? new TankInfoHistoryResponse();
        }
    }
}