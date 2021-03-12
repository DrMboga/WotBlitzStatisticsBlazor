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
    public class CheckLastBattleDateOperationTest: OperationsStepsTestBase
    {
        private CheckLastBattleDateOperation _operation;
        private AccountInformationPipelineContextData _contextData;

        [SetUp]
        public void Init()
        {
            _operation = new CheckLastBattleDateOperation(
                (new Mock<ILogger<CheckLastBattleDateOperation>>()).Object);

            _contextData = new AccountInformationPipelineContextData();
            FillAccountAndTanks(_contextData);
        }

        [Test]
        public async Task ShouldNotSetFlagIfDatesAreEqual()
        {
            _contextData.DbAccountInfo = GetAccountInfoFromFixture();
            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            await _operation.Invoke(context, null);

            _contextData.NeedToSaveData.Should().Be(false);

        }

        [Test]
        public async Task ShouldSetFlagIfDbDateIsLessThenWgDate()
        {
            _contextData.DbAccountInfo = GetAccountInfoFromFixture();
            _contextData.DbAccountInfo.LastBattleTime -= 1;
            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            await _operation.Invoke(context, null);

            _contextData.NeedToSaveData.Should().Be(true);

        }

        [Test]
        public async Task ShouldSetFlagIfDbAccountInfoIsNull()
        {
            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            await _operation.Invoke(context, null);

            _contextData.NeedToSaveData.Should().Be(true);

        }

    }
}