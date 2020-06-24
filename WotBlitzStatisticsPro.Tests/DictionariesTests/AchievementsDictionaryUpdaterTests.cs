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
    public class AchievementsDictionaryUpdaterTests
    {
        private AchievementsDictionaryUpdater _achievementDictionariesUpdater;
        private Mock<IWargamingDictionariesApiClient> _wargamingDictionariesApiClientMock;
        private Mock<IDictionariesDataAccessor> _dataAccessorMock;

        private List<WotEncyclopediaAchievementsResponse> _achievementsInfoResponseEn;
        private List<WotEncyclopediaAchievementsResponse> _achievementsInfoResponseRu;
        private List<WotEncyclopediaAchievementsResponse> _achievementsInfoResponseDe;

        [SetUp]
        public void Init()
        {
            // Generating fake data
            _achievementsInfoResponseEn = GetAchievementsInfoResponse("en");
            _achievementsInfoResponseRu = GetAchievementsInfoResponse("ru", _achievementsInfoResponseEn);
            _achievementsInfoResponseDe = GetAchievementsInfoResponse("de", _achievementsInfoResponseEn);


            // Real mapper instance
            var configurationExp = new MapperConfigurationExpression();
            configurationExp.AddProfile<AchievementDictionaryProfile>();
            configurationExp.AddProfile<AchievementOptionProfile>();
            var mapperConfiguration = new MapperConfiguration(configurationExp);
            IMapper mapper = new Mapper(mapperConfiguration);

            // Wargaming client mock
            _wargamingDictionariesApiClientMock = new Mock<IWargamingDictionariesApiClient>();
            _wargamingDictionariesApiClientMock.Setup(w =>
                    w.GetAchievementsDictionary(It.IsAny<RealmType>(), RequestLanguage.En))
                .ReturnsAsync(_achievementsInfoResponseEn);
            _wargamingDictionariesApiClientMock.Setup(w =>
                    w.GetAchievementsDictionary(It.IsAny<RealmType>(), RequestLanguage.Ru))
                .ReturnsAsync(_achievementsInfoResponseRu);
            _wargamingDictionariesApiClientMock.Setup(w =>
                    w.GetAchievementsDictionary(It.IsAny<RealmType>(), RequestLanguage.De))
                .ReturnsAsync(_achievementsInfoResponseDe);

            // MongoDb data accessor mock
            _dataAccessorMock = new Mock<IDictionariesDataAccessor>();

            _achievementDictionariesUpdater = new AchievementsDictionaryUpdater(
                _wargamingDictionariesApiClientMock.Object,
                _dataAccessorMock.Object,
                mapper);

        }

        [Test]
        public async Task ShouldCallWargamingApi3Times()
        {
            await _achievementDictionariesUpdater.Update();

            // Should call wargaming API once for each language
            _wargamingDictionariesApiClientMock.Verify(d => d.GetAchievementsDictionary(It.IsAny<RealmType>(), RequestLanguage.En), Times.Once);
            _wargamingDictionariesApiClientMock.Verify(d => d.GetAchievementsDictionary(It.IsAny<RealmType>(), RequestLanguage.Ru), Times.Once);
            _wargamingDictionariesApiClientMock.Verify(d => d.GetAchievementsDictionary(It.IsAny<RealmType>(), RequestLanguage.De), Times.Once);
        }

        [Test]
        public async Task ShouldSaveAppropriateAchievementsDictionary()
        {
            List<IAchievementDictionary> targetAchievementDictionaries = null;
            _dataAccessorMock
                .Setup(d => d.UpdateAchievements(It.IsAny<List<IAchievementDictionary>>()))
                .Callback((List<IAchievementDictionary> dictionary) => targetAchievementDictionaries = dictionary);

            await _achievementDictionariesUpdater.Update();

            targetAchievementDictionaries.Should().NotBeNull();
            targetAchievementDictionaries.Should().HaveCount(targetAchievementDictionaries.Count);

            for (var i = 0; i < targetAchievementDictionaries.Count; i++)
            {
                targetAchievementDictionaries[i].AchievementId.Should()
                    .Be(_achievementsInfoResponseEn[i].AchievementId);
                targetAchievementDictionaries[i].Name.First(n => n.Language == RequestLanguage.En).Value.Should()
                    .Be(_achievementsInfoResponseEn[i].Name);
                targetAchievementDictionaries[i].Name.First(n => n.Language == RequestLanguage.Ru).Value.Should()
                    .Be(_achievementsInfoResponseRu[i].Name);
                targetAchievementDictionaries[i].Name.First(n => n.Language == RequestLanguage.De).Value.Should()
                    .Be(_achievementsInfoResponseDe[i].Name);
                targetAchievementDictionaries[i].Description.First(n => n.Language == RequestLanguage.En).Value.Should()
                    .Be(_achievementsInfoResponseEn[i].Description);
                targetAchievementDictionaries[i].Description.First(n => n.Language == RequestLanguage.Ru).Value.Should()
                    .Be(_achievementsInfoResponseRu[i].Description);
                targetAchievementDictionaries[i].Description.First(n => n.Language == RequestLanguage.De).Value.Should()
                    .Be(_achievementsInfoResponseDe[i].Description);
                targetAchievementDictionaries[i].Condition.First(n => n.Language == RequestLanguage.En).Value.Should()
                    .Be(_achievementsInfoResponseEn[i].Condition);
                targetAchievementDictionaries[i].Condition.First(n => n.Language == RequestLanguage.Ru).Value.Should()
                    .Be(_achievementsInfoResponseRu[i].Condition);
                targetAchievementDictionaries[i].Condition.First(n => n.Language == RequestLanguage.De).Value.Should()
                    .Be(_achievementsInfoResponseDe[i].Condition);

                if (_achievementsInfoResponseEn[i].Options == null)
                {
                    targetAchievementDictionaries[i].Options.Should().BeNull();
                }
                else
                {
                    targetAchievementDictionaries[i].Options.Should().NotBeNull();
                    targetAchievementDictionaries[i].Options.Count.Should()
                        .Be(_achievementsInfoResponseEn[i].Options.Length);

                }
            }

        }


        #region Fixtures

        private static List<WotEncyclopediaAchievementsResponse> GetAchievementsInfoResponse(string language, List<WotEncyclopediaAchievementsResponse> baseEncyclopedia = null)
        {
            var result = new List<WotEncyclopediaAchievementsResponse>();
            var faker = new Faker(language);

            if (baseEncyclopedia == null)
            {
                var random = faker.Random;
                for (int i = 0; i < random.Number(200); i++)
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

        private static WotEncyclopediaAchievementsResponse FakeNewDictionaryItem(Faker faker)
        {
            return new WotEncyclopediaAchievementsResponse
            {
                Name = faker.Commerce.ProductName(),
                AchievementId = faker.Lorem.Word(),
                Description = faker.Lorem.Sentence(),
                Condition = faker.Lorem.Sentence(),
                Options = faker.Random.Bool() ? FakeOptions(faker) : null
            };
        }

        private static WotEncyclopediaAchievementsResponse FakeDictionaryItem(Faker faker, WotEncyclopediaAchievementsResponse baseResponse)
        {
            return new WotEncyclopediaAchievementsResponse
            {
                Name = faker.Commerce.ProductName(),
                AchievementId = baseResponse.AchievementId,
                Description = faker.Lorem.Sentence(),
                Condition = faker.Lorem.Sentence(),
                Options = baseResponse.Options
            };
        }

        private static WotEncyclopediaAchievementsOptions[] FakeOptions(Faker faker)
        {
            var result = new WotEncyclopediaAchievementsOptions[4];
            for (int i = 0; i < 4; i++)
            {
                result[i] = new WotEncyclopediaAchievementsOptions
                {
                    Name = faker.Lorem.Word(),
                    Description = faker.Lorem.Sentence(),
                    Image = faker.Internet.Url()
                };
            }

            return result;
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
                result[faker.Lorem.Word()] = new WotEncyclopediaInfoAchievementSection { Name = faker.Lorem.Word() };
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