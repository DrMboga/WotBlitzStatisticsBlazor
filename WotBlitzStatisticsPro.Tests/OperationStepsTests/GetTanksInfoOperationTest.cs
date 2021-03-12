using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;

namespace WotBlitzStatisticsPro.Tests.OperationStepsTests
{
    [TestFixture]
    public class GetTanksInfoOperationTest: OperationsStepsTestBase
    {
        private GetTanksInfoOperation _operation;
        private AccountInformationPipelineContextData _contextData;

        [SetUp]
        public void Init()
        {
            InitAutoMapper();
            InitWgApiClient();
            _operation = new GetTanksInfoOperation(
                WargamingTanksApiClient,
                Mapper,
                (new Mock<ILogger<GetTanksInfoOperation>>()).Object);

            _contextData = new AccountInformationPipelineContextData();
        }

        [Test]
        public async Task ShouldGetAndSaveTanksInformation()
        {
            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            await _operation.Invoke(context, null);

            _contextData.Tanks.Should().NotBeNull();
            _contextData.TanksHistory.Should().NotBeNull();

            var tanksSerialized = JsonConvert.SerializeObject(_contextData.Tanks);
            var tanksHistorySerialized = JsonConvert.SerializeObject(_contextData.TanksHistory);

            var expectedTanksInfo =
                await File.ReadAllTextAsync(GetFixturePath("MappedTanks.json"));
            tanksSerialized.Should().Be(expectedTanksInfo);
            var expectedTanksHistory =
                await File.ReadAllTextAsync(GetFixturePath("MappedTanksHistory.json"));
            tanksHistorySerialized.Should().Be(expectedTanksHistory);
        }

    }
}