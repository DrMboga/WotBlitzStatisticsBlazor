using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;

namespace WotBlitzStatisticsPro.Tests.OperationStepsTests
{
    [TestFixture]

    public class SaveAccountAntTanksOperationTest: OperationsStepsTestBase
    {
        private SaveAccountAndTanksOperation _operation;
        private AccountInformationPipelineContextData _contextData;

        private Dictionary<long, double> _expectedTankWn7 = new Dictionary<long, double>();

        [SetUp]
        public void Init()
        {
            InitDataAccessors();
            _operation = new SaveAccountAndTanksOperation(
                WargamingDataAccessorMock.Object,
                (new Mock<ILogger<SaveAccountAndTanksOperation>>()).Object);

            _contextData = new AccountInformationPipelineContextData();
            FillAccountAndTanks(_contextData);
        }

        [Test]
        public async Task ShouldSaveAccountInfo()
        {
            _contextData.NeedToSaveData = true;
            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            await _operation.Invoke(context, null);

            WargamingDataAccessorMock.Verify(d => d.AddOurUpdateAccountInfo(It.Is<AccountInfo>(a => a.AccountId == AccountId)), Times.Once);
        }

        [Test]
        public async Task ShouldNotSaveAccountInfoIfFlagIsNotSet()
        {
            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            await _operation.Invoke(context, null);

            WargamingDataAccessorMock.Verify(d => d.AddOurUpdateAccountInfo(It.Is<AccountInfo>(a => a.AccountId == AccountId)), Times.Never);
            WargamingDataAccessorMock.Verify(d => d.AddAccountInfoHistory(It.IsAny<AccountInfoHistory>()), Times.Never);
            WargamingDataAccessorMock.Verify(d => d.AddOrUpdateTankInfo(It.IsAny<TankInfo>()), Times.Never);
            WargamingDataAccessorMock.Verify(d => d.AddTankInfoHistory(It.IsAny<TankInfoHistory>()), Times.Never);
        }

        [Test]
        public async Task ShouldSaveAccountInfoHistory()
        {
            _contextData.NeedToSaveData = true;
            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            await _operation.Invoke(context, null);

            WargamingDataAccessorMock.Verify(d => d.AddAccountInfoHistory(It.Is<AccountInfoHistory>(a => a.AccountId == AccountId)), Times.Once);
        }

        [Test]
        public async Task ShouldSaveAllTanksIfNotTanksInDatabase()
        {
            _contextData.NeedToSaveData = true;
            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            await _operation.Invoke(context, null);

            var tanksCount = _contextData.Tanks.Count;

            WargamingDataAccessorMock.Verify(d => d.AddOrUpdateTankInfo(It.IsAny<TankInfo>()), Times.Exactly(tanksCount));
            WargamingDataAccessorMock.Verify(d => d.AddTankInfoHistory(It.IsAny<TankInfoHistory>()), Times.Exactly(tanksCount));
        }

        [Test]
        public async Task ShouldSaveTanksThatLastDateIsGreaterThenInDatabase()
        {
            _contextData.NeedToSaveData = true;
            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            int outdatedTanksCount = 3;
            int outdatedTanksIndex = 0;

            foreach (var tank in _contextData.Tanks)
            {
                if (outdatedTanksIndex < outdatedTanksCount)
                {
                    var tankInfo = new TankInfo
                    {
                        TankInfoId = new TankInfoKey
                        {
                            TankId = tank.TankId,
                            AccountId = tank.AccountId,
                        },
                        LastBattleTime = tank.LastBattleTime - 1
                    };
                    WargamingDataAccessorMock.Setup(d => d.ReadTankInfo(tank.AccountId, tank.TankId))
                        .ReturnsAsync(tankInfo);
                    outdatedTanksIndex++;
                }
                else
                {
                    WargamingDataAccessorMock.Setup(d => d.ReadTankInfo(tank.AccountId, tank.TankId))
                        .ReturnsAsync(tank);
                }
            }


            await _operation.Invoke(context, null);

            var tanksCount = _contextData.Tanks.Count;

            WargamingDataAccessorMock.Verify(d => d.AddOrUpdateTankInfo(It.IsAny<TankInfo>()), Times.Exactly(outdatedTanksCount));
            WargamingDataAccessorMock.Verify(d => d.AddTankInfoHistory(It.IsAny<TankInfoHistory>()), Times.Exactly(outdatedTanksCount));
        }

    }
}