using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;

namespace WotBlitzStatisticsPro.Tests.OperationStepsTests
{
    [TestFixture]
    public class GetAccountInfoOperationTest: OperationsStepsTestBase
    {
        private GetAccountInfoOperation _operation;
        private AccountInformationPipelineContextData _contextData;

        [SetUp]
        public void Init()
        {
            InitAutoMapper();
            InitWgApiClient();
            _operation = new GetAccountInfoOperation(
                WargamingApiClient,
                Mapper,
                (new Mock<ILogger<GetAccountInfoOperation>>()).Object);

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
        }
    }
}