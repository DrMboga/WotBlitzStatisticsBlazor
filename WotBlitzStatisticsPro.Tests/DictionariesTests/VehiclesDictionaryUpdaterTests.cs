using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Bogus;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.Dictionaries;
using WotBlitzStatisticsPro.Logic.Mappers;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Tests.DictionariesTests
{
    [TestFixture]
    public class VehiclesDictionaryUpdaterTests
    {
        private VehiclesDictionaryUpdater _vehiclesDictionariesUpdater;
        private Mock<IWargamingDictionariesApiClient> _wargamingDictionariesApiClientMock;
        private Mock<IDictionariesDataAccessor> _dataAccessorMock;

        private List<WotEncyclopediaVehiclesResponse> _vehiclesInfoResponseEn;
        private List<WotEncyclopediaVehiclesResponse> _vehiclesInfoResponseRu;
        private List<WotEncyclopediaVehiclesResponse> _vehiclesInfoResponseDe;

        [SetUp]
        public void Init()
        {
            // Generating fake data
            _vehiclesInfoResponseEn = GetVehiclesInfoResponse("en");
            _vehiclesInfoResponseRu = GetVehiclesInfoResponse("ru", _vehiclesInfoResponseEn);
            _vehiclesInfoResponseDe = GetVehiclesInfoResponse("de", _vehiclesInfoResponseEn);


            // Real mapper instance
            var configurationExp = new MapperConfigurationExpression();
            configurationExp.AddProfile<VehiclePriceProfile>();
            configurationExp.AddProfile<VehicleDictionaryProfile>();
            var mapperConfiguration = new MapperConfiguration(configurationExp);
            IMapper mapper = new Mapper(mapperConfiguration);

            // Wargaming client mock
            _wargamingDictionariesApiClientMock = new Mock<IWargamingDictionariesApiClient>();
            _wargamingDictionariesApiClientMock.Setup(w =>
                    w.GetVehicles(It.IsAny<RealmType>(), RequestLanguage.En))
                .ReturnsAsync(_vehiclesInfoResponseEn);
            _wargamingDictionariesApiClientMock.Setup(w =>
                    w.GetVehicles(It.IsAny<RealmType>(), RequestLanguage.Ru))
                .ReturnsAsync(_vehiclesInfoResponseRu);
            _wargamingDictionariesApiClientMock.Setup(w =>
                    w.GetVehicles(It.IsAny<RealmType>(), RequestLanguage.De))
                .ReturnsAsync(_vehiclesInfoResponseDe);

            // MongoDb data accessor mock
            _dataAccessorMock = new Mock<IDictionariesDataAccessor>();

            _vehiclesDictionariesUpdater = new VehiclesDictionaryUpdater(
                _wargamingDictionariesApiClientMock.Object,
                _dataAccessorMock.Object,
                mapper);

        }

        [Test]
        public async Task ShouldCallWargamingApi3Times()
        {
            await _vehiclesDictionariesUpdater.Update();

            // Should call wargaming API once for each language
            _wargamingDictionariesApiClientMock.Verify(d => d.GetVehicles(It.IsAny<RealmType>(), RequestLanguage.En), Times.Once);
            _wargamingDictionariesApiClientMock.Verify(d => d.GetVehicles(It.IsAny<RealmType>(), RequestLanguage.Ru), Times.Once);
            _wargamingDictionariesApiClientMock.Verify(d => d.GetVehicles(It.IsAny<RealmType>(), RequestLanguage.De), Times.Once);
        }

        [Test]
        public async Task ShouldSaveAppropriateVehiclesDictionary()
        {
            List<VehiclesDictionary> targetVehicleDictionary = null;
            _dataAccessorMock
                .Setup(d => d.UpdateVehicles(It.IsAny<List<VehiclesDictionary>>()))
                .Callback((List<VehiclesDictionary> dictionary) => targetVehicleDictionary = dictionary);

            await _vehiclesDictionariesUpdater.Update();

            targetVehicleDictionary.Should().NotBeNull();
            targetVehicleDictionary.Should().HaveCount(targetVehicleDictionary.Count);

            for (var i = 0; i < targetVehicleDictionary.Count; i++)
            {
                targetVehicleDictionary[i].TankId.Should()
                    .Be(_vehiclesInfoResponseEn[i].TankId);
                targetVehicleDictionary[i].Name.First(n => n.Language == RequestLanguage.En).Value.Should()
                    .Be(_vehiclesInfoResponseEn[i].Name);
                targetVehicleDictionary[i].Name.First(n => n.Language == RequestLanguage.Ru).Value.Should()
                    .Be(_vehiclesInfoResponseRu[i].Name);
                targetVehicleDictionary[i].Name.First(n => n.Language == RequestLanguage.De).Value.Should()
                    .Be(_vehiclesInfoResponseDe[i].Name);
                targetVehicleDictionary[i].Description.First(n => n.Language == RequestLanguage.En).Value.Should()
                    .Be(_vehiclesInfoResponseEn[i].Description);
                targetVehicleDictionary[i].Description.First(n => n.Language == RequestLanguage.Ru).Value.Should()
                    .Be(_vehiclesInfoResponseRu[i].Description);
                targetVehicleDictionary[i].Description.First(n => n.Language == RequestLanguage.De).Value.Should()
                    .Be(_vehiclesInfoResponseDe[i].Description);
            }

        }


        #region Fixtures

        private static List<WotEncyclopediaVehiclesResponse> GetVehiclesInfoResponse(string language, List<WotEncyclopediaVehiclesResponse> baseEncyclopedia = null)
        {
            var result = new List<WotEncyclopediaVehiclesResponse>();
            var faker = new Faker(language);

            if (baseEncyclopedia == null)
            {
                var random = faker.Random;
                for (int i = 0; i < random.Number(400); i++)
                {
                    result.Add(FakeNewDictionaryItem(faker));
                }
            }
            else
            {
                foreach (var achievementsResponse in baseEncyclopedia)
                {
                    result.Add(FakeDictionaryItem(faker, achievementsResponse));
                }
            }

            return result;
        }

        private static WotEncyclopediaVehiclesResponse FakeNewDictionaryItem(Faker faker)
        {
            return new WotEncyclopediaVehiclesResponse
            {
                Name = faker.Commerce.ProductName(),
                TankId = faker.Random.Number(9999),
                Description = faker.Lorem.Sentence(),
            };
        }

        private static WotEncyclopediaVehiclesResponse FakeDictionaryItem(Faker faker, WotEncyclopediaVehiclesResponse baseResponse)
        {
            return new WotEncyclopediaVehiclesResponse
            {
                Name = faker.Commerce.ProductName(),
                Description = faker.Lorem.Sentence(),
                TankId = baseResponse.TankId
            };
        }

        #endregion

    }
}