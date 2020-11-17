﻿using System;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Logic
{
    public class WargamingAccounts: IWargamingAccounts
    {
        private readonly IOperationFactory _operationFactory;

        public WargamingAccounts(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public async Task<AccountInfoResponse> GatherAccountInformation(RealmType realm, long accountId, RequestLanguage requestLanguage)
        {
            var contextData = new AccountInformationPipelineContextData();
            var context = new OperationContext(new AccountRequest(accountId, realm, requestLanguage));
            context.AddOrReplace(contextData);
            var pipeline = new Pipeline<IOperationContext>(_operationFactory);

            pipeline.AddOperation<GetAccountInfoOperation>()
                .AddOperation<GetTanksInfoOperation>()
                .AddOperation<CalculateStatisticsOperation>()
                .AddOperation<BuildAccountInfoResponseOperation>()
                ;

            await pipeline.Build()
                .Invoke(context, null)
                .ConfigureAwait(false);

            return contextData.Response;
        }

        public async Task<AccountInfoResponse> GatherAndSaveAccountInformation(RealmType realm, long accountId, RequestLanguage requestLanguage)
        {
            var contextData = new AccountInformationPipelineContextData();
            var context = new OperationContext(new AccountRequest(accountId, realm, requestLanguage));
            context.AddOrReplace(contextData);
            var pipeline = new Pipeline<IOperationContext>(_operationFactory);

            pipeline.AddOperation<GetAccountInfoOperation>()
                .AddOperation<ReadAccountInfoFromDbOperation>()
                .AddOperation<CheckLastBattleDateOperation>()
                .AddOperation<GetTanksInfoOperation>()
                .AddOperation<CalculateStatisticsOperation>()
                .AddOperation<SaveAccountAndTanksOperation>()
                .AddOperation<BuildAccountInfoResponseOperation>()
                ;

            await pipeline.Build()
                .Invoke(context, null)
                .ConfigureAwait(false);

            return contextData.Response;
        }

        public async Task<AccountInfoHistoryResponse> GetAccountInfoHistory(RealmType realm, long accountId, DateTime startDate, RequestLanguage requestLanguage)
        {
            var contextData = new HistoryInformationPipelineContextData();
            var context = new OperationContext(new AccountRequest(accountId, realm, requestLanguage));
            context.AddOrReplace(contextData);
            var pipeline = new Pipeline<IOperationContext>(_operationFactory);

            // ToDo:
            // 1. First read account info from DB operation
            pipeline.AddOperation<ReadAccountInfoFromDbOperation>()

                // 2. Read account history from DB at the startDate !Array SortedByDate! operation
                // 3. Fill the OverallAccountStatistics
                // PeriodAccountStatistics
                // PeriodDifference
                // StatisticsHistory
                ;

            await pipeline.Build()
                .Invoke(context, null)
                .ConfigureAwait(false);

            return contextData.Response;
        }
    }
}