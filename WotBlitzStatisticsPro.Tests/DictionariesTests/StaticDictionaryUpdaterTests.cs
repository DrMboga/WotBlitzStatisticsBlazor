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
    public class StaticDictionaryUpdaterTests
    {
        private StaticDictionariesUpdater _staticDictionariesUpdater;

        private Mock<IWargamingDictionariesApiClient> _wargamingDictionariesApiClientMock;
        private Mock<IDictionariesDataAccessor> _dataAccessorMock;

        private readonly WotEncyclopediaInfoResponse[] _encyclopediaInfoResponse = new WotEncyclopediaInfoResponse[3];

        private readonly WotClanMembersDictionaryResponse[] _clanMembersDictionary = new WotClanMembersDictionaryResponse[3];

        [SetUp]
        public void Init()
        {
            // Generating fake data
            _encyclopediaInfoResponse[0] = GetEncyclopediaInfoResponse("en");
            _encyclopediaInfoResponse[1] = GetEncyclopediaInfoResponse("ru", _encyclopediaInfoResponse[0]);
            _encyclopediaInfoResponse[2] = GetEncyclopediaInfoResponse("de", _encyclopediaInfoResponse[0]);

            _clanMembersDictionary[0] = GetClanMembersDictionaryResponse("en");
            _clanMembersDictionary[1] = GetClanMembersDictionaryResponse("ru", _clanMembersDictionary[0]);
            _clanMembersDictionary[2] = GetClanMembersDictionaryResponse("de", _clanMembersDictionary[0]);

            // Real mapper instance
            var configurationExp = new MapperConfigurationExpression();
            configurationExp.AddProfile<DictionaryLanguageMapper>();
            var mapperConfiguration = new MapperConfiguration(configurationExp);
            IMapper mapper = new Mapper(mapperConfiguration);

            // Wargaming client mock
            _wargamingDictionariesApiClientMock = new Mock<IWargamingDictionariesApiClient>();
            _wargamingDictionariesApiClientMock.Setup(w =>
                    w.GetStaticDictionariesAsync(It.IsAny<RealmType>(), RequestLanguage.En))
                .ReturnsAsync((_encyclopediaInfoResponse[0], _clanMembersDictionary[0]));
            _wargamingDictionariesApiClientMock.Setup(w =>
                    w.GetStaticDictionariesAsync(It.IsAny<RealmType>(), RequestLanguage.Ru))
                .ReturnsAsync((_encyclopediaInfoResponse[1], _clanMembersDictionary[1]));
            _wargamingDictionariesApiClientMock.Setup(w =>
                    w.GetStaticDictionariesAsync(It.IsAny<RealmType>(), RequestLanguage.De))
                .ReturnsAsync((_encyclopediaInfoResponse[2], _clanMembersDictionary[2]));

            // MongoDb data accessor mock
            _dataAccessorMock = new Mock<IDictionariesDataAccessor>();

            _staticDictionariesUpdater = new StaticDictionariesUpdater(
                _wargamingDictionariesApiClientMock.Object,
                _dataAccessorMock.Object,
                mapper);
        }

        [Test]
        public async Task ShouldCallWargamingApi3Times()
        {
            await _staticDictionariesUpdater.Update();

            // Should call wargaming API once for each language
            _wargamingDictionariesApiClientMock.Verify(d => d.GetStaticDictionariesAsync(It.IsAny<RealmType>(), RequestLanguage.En), Times.Once);
            _wargamingDictionariesApiClientMock.Verify(d => d.GetStaticDictionariesAsync(It.IsAny<RealmType>(), RequestLanguage.Ru), Times.Once);
            _wargamingDictionariesApiClientMock.Verify(d => d.GetStaticDictionariesAsync(It.IsAny<RealmType>(), RequestLanguage.De), Times.Once);
        }

        [Test]
        public async Task ShouldSaveAppropriateLanguagesDictionary()
        {
            List<ILanguageDictionary> languageDictionary = null;
            _dataAccessorMock
                .Setup(d => d.UpdateLanguages(It.IsAny<List<ILanguageDictionary>>()))
                .Callback((List<ILanguageDictionary> dictionary) => languageDictionary = dictionary);

            await _staticDictionariesUpdater.Update();

            var sourceLanguages = _encyclopediaInfoResponse[0].Languages.ToArray();

            languageDictionary.Should().NotBeNull();
            languageDictionary.Should().HaveCount(sourceLanguages.Length);
            for (int i = 0; i < sourceLanguages.Length; i++)
            {
                languageDictionary[i].LanguageId.Should().Be(sourceLanguages[i].Key);
                languageDictionary[i].LanguageName.Should()
                    .Be(sourceLanguages[i].Value);
            }
        }

        [Test]
        public async Task ShouldSaveAppropriateNationsDictionary()
        {
            List<INationDictionary> nations = null;
            _dataAccessorMock
                .Setup(d => d.UpdateNations(It.IsAny<List<INationDictionary>>()))
                .Callback((List<INationDictionary> dictionary) => nations = dictionary);

            await _staticDictionariesUpdater.Update();

            var sourceNationsEn = _encyclopediaInfoResponse[0].VehicleNations.ToArray();
            var sourceNationsRu = _encyclopediaInfoResponse[1].VehicleNations.ToArray();
            var sourceNationsDe = _encyclopediaInfoResponse[2].VehicleNations.ToArray();

            nations.Should().NotBeNull();
            nations.Should().HaveCount(sourceNationsEn.Length);
            for (int i = 0; i < sourceNationsEn.Length; i++)
            {
                nations[i].NationId.Should().Be(sourceNationsEn[i].Key);
                nations[i].NationNames.First(n => n.Language == RequestLanguage.En).Value.Should()
                    .Be(sourceNationsEn[i].Value);
                nations[i].NationNames.First(n => n.Language == RequestLanguage.Ru).Value.Should()
                    .Be(sourceNationsRu[i].Value);
                nations[i].NationNames.First(n => n.Language == RequestLanguage.De).Value.Should()
                    .Be(sourceNationsDe[i].Value);
            }
        }

        [Test]
        public async Task ShouldSaveAppropriateVehicleTypesDictionary()
        {
            List<IVehicleTypeDictionary> vehicleTypes = null;
            _dataAccessorMock
                .Setup(d => d.UpdateVehicleTypes(It.IsAny<List<IVehicleTypeDictionary>>()))
                .Callback((List<IVehicleTypeDictionary> dictionary) => vehicleTypes = dictionary);

            await _staticDictionariesUpdater.Update();

            var vehicleTypesEn = _encyclopediaInfoResponse[0].VehicleTypes.ToArray();
            var vehicleTypesRu = _encyclopediaInfoResponse[1].VehicleTypes.ToArray();
            var vehicleTypesDe = _encyclopediaInfoResponse[2].VehicleTypes.ToArray();

            vehicleTypes.Should().NotBeNull();
            vehicleTypes.Should().HaveCount(vehicleTypesEn.Length);
            for (int i = 0; i < vehicleTypesEn.Length; i++)
            {
                vehicleTypes[i].VehicleTypeId.Should().Be(vehicleTypesEn[i].Key);
                vehicleTypes[i].VehicleTypeNames.First(n => n.Language == RequestLanguage.En).Value.Should()
                    .Be(vehicleTypesEn[i].Value);
                vehicleTypes[i].VehicleTypeNames.First(n => n.Language == RequestLanguage.Ru).Value.Should()
                    .Be(vehicleTypesRu[i].Value);
                vehicleTypes[i].VehicleTypeNames.First(n => n.Language == RequestLanguage.De).Value.Should()
                    .Be(vehicleTypesDe[i].Value);
            }
        }

        [Test]
        public async Task ShouldSaveAppropriateClanRolesDictionary()
        {
            List<IClanRoleDictionary> clanRoles = null;
            _dataAccessorMock
                .Setup(d => d.UpdateClanRoles(It.IsAny<List<IClanRoleDictionary>>()))
                .Callback((List<IClanRoleDictionary> dictionary) => clanRoles = dictionary);

            await _staticDictionariesUpdater.Update();

            var clanRoleEn = _clanMembersDictionary[0].ClanRoles.ToArray();
            var clanRoleRu = _clanMembersDictionary[1].ClanRoles.ToArray();
            var clanRoleDe = _clanMembersDictionary[2].ClanRoles.ToArray();

            clanRoles.Should().NotBeNull();
            clanRoles.Should().HaveCount(clanRoleEn.Length);
            for (int i = 0; i < clanRoleEn.Length; i++)
            {
                clanRoles[i].ClanRoleId.Should().Be(clanRoleEn[i].Key);
                clanRoles[i].ClanRoleNames.First(n => n.Language == RequestLanguage.En).Value.Should()
                    .Be(clanRoleEn[i].Value);
                clanRoles[i].ClanRoleNames.First(n => n.Language == RequestLanguage.Ru).Value.Should()
                    .Be(clanRoleRu[i].Value);
                clanRoles[i].ClanRoleNames.First(n => n.Language == RequestLanguage.De).Value.Should()
                    .Be(clanRoleDe[i].Value);
            }
        }

        [Test]
        public async Task ShouldSaveAppropriateAchievementsSectionsDictionary()
        {
            List<IAchievementSectionDictionary> achievementsSections = null;
            _dataAccessorMock
                .Setup(d => d.UpdateAchievementsSections(It.IsAny<List<IAchievementSectionDictionary>>()))
                .Callback((List<IAchievementSectionDictionary> dictionary) => achievementsSections = dictionary);

            await _staticDictionariesUpdater.Update();

            var asEn = _encyclopediaInfoResponse[0].AchievementSections.ToArray();
            var asRu = _encyclopediaInfoResponse[1].AchievementSections.ToArray();
            var asDe = _encyclopediaInfoResponse[2].AchievementSections.ToArray();

            achievementsSections.Should().NotBeNull();
            achievementsSections.Should().HaveCount(asEn.Length);
            for (int i = 0; i < asEn.Length; i++)
            {
                achievementsSections[i].AchievementSectionId.Should().Be(asEn[i].Key);
                achievementsSections[i].AchievementSectionNames.First(n => n.Language == RequestLanguage.En).Value.Should()
                    .Be(asEn[i].Value.Name);
                achievementsSections[i].AchievementSectionNames.First(n => n.Language == RequestLanguage.Ru).Value.Should()
                    .Be(asRu[i].Value.Name);
                achievementsSections[i].AchievementSectionNames.First(n => n.Language == RequestLanguage.De).Value.Should()
                    .Be(asDe[i].Value.Name);
            }
        }

        #region Fixtures

        private static WotEncyclopediaInfoResponse GetEncyclopediaInfoResponse(string language, WotEncyclopediaInfoResponse baseEncyclopedia = null)
        {
            return new WotEncyclopediaInfoResponse
            {
                AchievementSections = baseEncyclopedia == null ? FakeAchievementSections(16, language) : FakeAchievementSections(language, baseEncyclopedia.AchievementSections),
                Languages = baseEncyclopedia == null ? FakeDictionary(14) : baseEncyclopedia.Languages,
                VehicleNations = baseEncyclopedia == null ? FakeDictionary(8, language) : FakeDictionary(language, baseEncyclopedia.VehicleNations),
                VehicleTypes = baseEncyclopedia == null ? FakeDictionary(4, language) : FakeDictionary(language, baseEncyclopedia.VehicleTypes)
            };
        }

        private static WotClanMembersDictionaryResponse GetClanMembersDictionaryResponse(string language, WotClanMembersDictionaryResponse baseClanRoles = null)
        {
            return new WotClanMembersDictionaryResponse
            {
                ClanRoles = baseClanRoles == null ? FakeDictionary(3, language) : FakeDictionary(language, baseClanRoles.ClanRoles)
            };
        }

        private static Dictionary<string, string> FakeDictionary(int elementsCount, string language = "en")
        {
            var result = new Dictionary<string, string>();
            var faker = new Faker(language);

            for (int i = 0; i < elementsCount; i++)
            {
                result[faker.Lorem.Word()] = faker.Lorem.Word();
            }

            return result;
        }

        private static Dictionary<string, string> FakeDictionary(string language,
            Dictionary<string, string> baseDictionary)
        {
            var result = new Dictionary<string, string>();
            var faker = new Faker(language);

            foreach (var baseValue in baseDictionary)
            {
                result[baseValue.Key] = faker.Lorem.Word();
            }

            return result;
        }

        private static Dictionary<string, WotEncyclopediaInfoAchievementSection> FakeAchievementSections(int elementsCount, string language = "en")
        {
            var result = new Dictionary<string, WotEncyclopediaInfoAchievementSection>();
            var faker = new Faker(language);

            for (int i = 0; i < elementsCount; i++)
            {
                result[faker.Lorem.Word()] = new WotEncyclopediaInfoAchievementSection {Name = faker.Lorem.Word()};
            }

            return result;
        }

        private static Dictionary<string, WotEncyclopediaInfoAchievementSection> FakeAchievementSections(string language,
            Dictionary<string, WotEncyclopediaInfoAchievementSection> baseDictionary)
        {
            var result = new Dictionary<string, WotEncyclopediaInfoAchievementSection>();
            var faker = new Faker(language);

            foreach (var baseValue in baseDictionary)
            {
                result[baseValue.Key] = new WotEncyclopediaInfoAchievementSection { Name = faker.Lorem.Word() };
            }

            return result;
        }

        #endregion
    }
}