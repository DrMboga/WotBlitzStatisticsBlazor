using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;

namespace WotBlitzStatisticsPro.Tests.OperationStepsTests
{
    [TestFixture]
    public class ReadAccountInfoFromDbOperationTest: OperationsStepsTestBase
    {
        private ReadAccountInfoFromDbOperation _operation;
        private AccountInformationPipelineContextData _contextData;

        [SetUp]
        public void Init()
        {
            InitDataAccessors();
            _operation = new ReadAccountInfoFromDbOperation(
                WargamingDataAccessorMock.Object);

            _contextData = new AccountInformationPipelineContextData();
        }

        [Test]
        public async Task ShouldReadAccountInfoFromDataAccessor()
        {
            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            await _operation.Invoke(context, null);

            _contextData.DbAccountInfo.Should().NotBeNull();

            var accountInfoSerialized = JsonConvert.SerializeObject(_contextData.DbAccountInfo);

            var expectedAccountInfo =
                await File.ReadAllTextAsync($"{TestContext.CurrentContext.TestDirectory}\\Fixtures\\MappedAccountInfo.json");
            accountInfoSerialized.Should().Be(expectedAccountInfo);
        }

    }
}