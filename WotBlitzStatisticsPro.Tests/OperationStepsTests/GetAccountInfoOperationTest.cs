﻿using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NUnit.Framework;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;
using WotBlitzStatisticsPro.Logic.Model;

namespace WotBlitzStatisticsPro.Tests.OperationStepsTests
{
    [TestFixture]
    public class GetAccountInfoOperationTest: OperationsStepsTestBase
    {
        private GetAccountInfoOperation _operation;
        private AccountInformationPipelineContextData _contextData;
        private StatisticsCache _cache;

        [SetUp]
        public void Init()
        {
            InitAutoMapper();
            InitWgApiClient();
            _cache = new StatisticsCache();
            _operation = new GetAccountInfoOperation(
                WargamingApiClient,
                Mapper,
                (new Mock<ILogger<GetAccountInfoOperation>>()).Object,
                _cache);

            _contextData = new AccountInformationPipelineContextData();
        }

        [Test]
        public async Task ShouldGetAndSaveAccountInfoInformation()
        {
            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            await _operation.Invoke(context, null);

            _contextData.AccountInfo.Should().NotBeNull();
            _contextData.AccountInfoHistory.Should().NotBeNull();

            var accountInfoSerialized = JsonConvert.SerializeObject(_contextData.AccountInfo);
            var accountInfoHistorySerialized = JsonConvert.SerializeObject(_contextData.AccountInfoHistory);

            var expectedAccountInfo =
                await File.ReadAllTextAsync(GetFixturePath("MappedAccountInfo.json"));
            accountInfoSerialized.Should().Be(expectedAccountInfo);
            var expectedAccountInfoHistory =
                await File.ReadAllTextAsync(GetFixturePath("MappedAccountHistory.json"));
            accountInfoHistorySerialized.Should().Be(expectedAccountInfoHistory);

            var accountCache = _cache.GetAccountData(AccountId);
            accountCache.Should().NotBeNull();
            accountCache?.AccountInfo.Should().NotBeNull();
            accountCache?.AccountInfoHistory.Should().NotBeNull();
        }

        [Test]
        public async Task ShouldReadDataFromCacheIfItIsNotEmpty()
        {
            var accountInfo = GetAccountInfoFromFixture();
            var accountInfoHistory = GetAccountInfoHistoryFromFixture();
            _cache.SetAccountData(AccountId, new AccountDataCache(accountInfo, accountInfoHistory));

            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            await _operation.Invoke(context, null);

            _contextData.AccountInfo.Should().NotBeNull();
            _contextData.AccountInfoHistory.Should().NotBeNull();

            HttpHandlerMock
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Never(), 
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>());
        }
    }
}