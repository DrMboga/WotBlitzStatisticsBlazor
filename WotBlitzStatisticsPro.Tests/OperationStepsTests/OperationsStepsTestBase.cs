using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NUnit.Framework;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.DataAccess.Model;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline;
using WotBlitzStatisticsPro.Logic.Mappers;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Tests.OperationStepsTests
{
    public class OperationsStepsTestBase
    {
        protected const long AccountId = 571050560;
        protected const string ApplicationId = "demo";
        protected const RealmType Realm = RealmType.Eu;
        protected const RequestLanguage Language = RequestLanguage.En;

        protected IMapper Mapper;
        protected IWargamingApiClient WargamingApiClient;
        protected IWargamingTanksApiClient WargamingTanksApiClient;
        protected Mock<IDictionariesDataAccessor> DictionariesDataAccessorMock;
        protected Mock<IWargamingAccountDataAccessor> WargamingDataAccessorMock;

        protected void InitAutoMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AccountDtoProfile>();
                cfg.AddProfile<AccountInfoProfile>();
                cfg.AddProfile<AccountInfoStatisticsProfile>();
                cfg.AddProfile<AccountSearchResponseProfile>();
                cfg.AddProfile<AchievementsProfile>();
                cfg.AddProfile<ClanSearchResponseProfile>();
                cfg.AddProfile<DictionaryLanguageMapper>();
                cfg.AddProfile<ShortStatisticsProfile>();
                cfg.AddProfile<TankInfoProfile>();
                cfg.AddProfile<TankInfoStatisticsProfile>();
                cfg.AddProfile<VehicleDictionaryProfile>();
                cfg.AddProfile<VehiclePriceProfile>();
            });

            Mapper = new Mapper(config);
        }

        protected void InitWgApiClient()
        {
            var settingsMock = new Mock<IWargamingApiSettings>();
            settingsMock.SetupGet(s => s.ApplicationId).Returns(ApplicationId);

            var playerInfoFilePath = GetFixturePath("PlayerInfo50.json");
            var tanksInfoFilePath = GetFixturePath("TanksInfo50.json");
            var playerAchievementsFilePath = GetFixturePath("PlayerAchievements50.json");
            var tanksAchievementsFilePath = GetFixturePath("TanksAchievemnts50.json");

            var playerInfoRequestUrl = $"https://api.wotblitz.eu/wotb/account/info/?application_id={ApplicationId}&language=en&account_id={AccountId}";
            var playerInfoResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(File.ReadAllText(playerInfoFilePath)),
            };

            var tanksInfoRequestUrl = $"https://api.wotblitz.eu/wotb/tanks/stats/?application_id={ApplicationId}&language=en&account_id={AccountId}";
            var tanksInfoResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(File.ReadAllText(tanksInfoFilePath)),
            };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(m => m.RequestUri.ToString() == playerInfoRequestUrl),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(playerInfoResponse);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(m => m.RequestUri.ToString() == tanksInfoRequestUrl),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(tanksInfoResponse);

            var client  = new WargamingApiClient(new HttpClient(handlerMock.Object), settingsMock.Object);
            WargamingApiClient = client;
            WargamingTanksApiClient = client;
        }

        protected void InitDataAccessors()
        {
            var tankopediaFile = File.ReadAllText(GetFixturePath("Tankopedia.json"));
            var vehicles = JsonConvert.DeserializeObject<List<VehiclesDictionary>>(tankopediaFile);

            var tankTires = vehicles.Select(v => new {TankId = v.TankId, Tier = v.Tier})
                .ToDictionary(k => k.TankId, v => v.Tier);

            DictionariesDataAccessorMock = new Mock<IDictionariesDataAccessor>();
            DictionariesDataAccessorMock.Setup(d => d.GetTankTires(It.IsAny<long[]>())).ReturnsAsync(tankTires);


            WargamingDataAccessorMock = new Mock<IWargamingAccountDataAccessor>();
            WargamingDataAccessorMock.Setup(d => d.ReadAccountInfo(AccountId))
                .ReturnsAsync(GetAccountInfoFromFixture());
        }

        protected void FillAccountAndTanks(AccountInformationPipelineContextData contextData)
        {
            var mappedAccountInfoHistory = File.ReadAllText(GetFixturePath("MappedAccountHistory.json"));
            var mappedTanks = File.ReadAllText(GetFixturePath("MappedTanks.json"));
            var mappedTanksHistory = File.ReadAllText(GetFixturePath("MappedTanksHistory.json"));

            contextData.AccountInfo = GetAccountInfoFromFixture();
            contextData.AccountInfoHistory =
                JsonConvert.DeserializeObject<AccountInfoHistory>(mappedAccountInfoHistory);
            contextData.Tanks = JsonConvert.DeserializeObject<List<TankInfo>>(mappedTanks);
            contextData.TanksHistory =
                JsonConvert.DeserializeObject<Dictionary<long, TankInfoHistory>>(mappedTanksHistory);

        }

        protected AccountInfo GetAccountInfoFromFixture()
        {
            var mappedAccountInfo = File.ReadAllText(GetFixturePath("MappedAccountInfo.json"));
            return JsonConvert.DeserializeObject<AccountInfo>(mappedAccountInfo);
        }

        protected string GetFixturePath(string fixtureFileName)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixtures", fixtureFileName);
        }
    }
}