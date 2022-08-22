using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic;
using WotBlitzStatisticsPro.Logic.Dictionaries;
using AutoMapper;
using WotBlitzStatisticsPro.DataAccess;
namespace WotBlitzStatisticsPro.Tests.DictionariesTests
{
    [TestFixture]
    public class DictionariesServiceTests
    {
        private Mock<StaticDictionariesUpdater> _staticDictionaryUpdaterMock;
        private Mock<AchievementsDictionaryUpdater> _achievementsDictionaryUpdaterMock;
        private Mock<VehiclesDictionaryUpdater> _vehiclesDictionaryUpdaterMock;

        private IWargamingDictionaries _wargamingDictionaries;

        [SetUp]
        public void Init()
        {
            _staticDictionaryUpdaterMock = new Mock<StaticDictionariesUpdater>();
            _achievementsDictionaryUpdaterMock = new Mock<AchievementsDictionaryUpdater>();
            _vehiclesDictionaryUpdaterMock = new Mock<VehiclesDictionaryUpdater>();


            _staticDictionaryUpdaterMock.Setup(d => d.Update()).ReturnsAsync(new UpdateDictionariesResponseItem());
            _achievementsDictionaryUpdaterMock.Setup(d => d.Update())
                .ReturnsAsync(new UpdateDictionariesResponseItem());
            _vehiclesDictionaryUpdaterMock.Setup(d => d.Update()).ReturnsAsync(new UpdateDictionariesResponseItem());

            var serviceProvider = new ServiceCollection();

            serviceProvider.AddSingleton(_staticDictionaryUpdaterMock.Object);
            serviceProvider.AddSingleton(_achievementsDictionaryUpdaterMock.Object);
            serviceProvider.AddSingleton(_vehiclesDictionaryUpdaterMock.Object);

            WotBlitzStatisticsLogicInstaller.RegisterDictionariesFactoryMethod(serviceProvider);

            var services = serviceProvider.BuildServiceProvider();

            _wargamingDictionaries = new WargamingDictionaries(services.GetService<DictionariesUpdaterResolver>(),
                (new Mock<IDictionariesDataAccessor>()).Object,
                (new Mock<ILogger<WargamingDictionaries>>()).Object,
                (new Mock<IMapper>()).Object);
        }

        [Test]
        public async Task ShouldCallOnlyStaticDictionariesUpdater()
        {
            var updateResult = await _wargamingDictionaries.UpdateDictionaries(new UpdateDictionariesRequest
                {DictionaryTypes = DictionaryType.StaticDictionaries});

            _staticDictionaryUpdaterMock.Verify(u => u.Update(), Times.Once);
            _achievementsDictionaryUpdaterMock.Verify(u => u.Update(), Times.Never);
            _vehiclesDictionaryUpdaterMock.Verify(u => u.Update(), Times.Never);
        }

        [Test]
        public async Task ShouldCallOnlyAchievementsDictionariesUpdater()
        {
            var updateResult = await _wargamingDictionaries.UpdateDictionaries(new UpdateDictionariesRequest
                {DictionaryTypes = DictionaryType.Achievements});

            _staticDictionaryUpdaterMock.Verify(u => u.Update(), Times.Never);
            _achievementsDictionaryUpdaterMock.Verify(u => u.Update(), Times.Once);
            _vehiclesDictionaryUpdaterMock.Verify(u => u.Update(), Times.Never);
        }

        [Test]
        public async Task ShouldCallOnlyVehiclesDictionariesUpdater()
        {
            var updateResult = await _wargamingDictionaries.UpdateDictionaries(new UpdateDictionariesRequest
                {DictionaryTypes = DictionaryType.Vehicles});

            _staticDictionaryUpdaterMock.Verify(u => u.Update(), Times.Never);
            _achievementsDictionaryUpdaterMock.Verify(u => u.Update(), Times.Never);
            _vehiclesDictionaryUpdaterMock.Verify(u => u.Update(), Times.Once);
        }

        [Test]
        public async Task ShouldCallOnlyVehiclesAndAchievementsDictionariesUpdater()
        {
            var updateResult = await _wargamingDictionaries.UpdateDictionaries(new UpdateDictionariesRequest
                {DictionaryTypes = DictionaryType.AchievementsAndVehicles});

            _staticDictionaryUpdaterMock.Verify(u => u.Update(), Times.Never);
            _achievementsDictionaryUpdaterMock.Verify(u => u.Update(), Times.Once);
            _vehiclesDictionaryUpdaterMock.Verify(u => u.Update(), Times.Once);
        }

        [Test]
        public async Task ShouldCallAllDictionariesUpdater()
        {
            var updateResult = await _wargamingDictionaries.UpdateDictionaries(new UpdateDictionariesRequest
                {DictionaryTypes = DictionaryType.All});

            _staticDictionaryUpdaterMock.Verify(u => u.Update(), Times.Once);
            _achievementsDictionaryUpdaterMock.Verify(u => u.Update(), Times.Once);
            _vehiclesDictionaryUpdaterMock.Verify(u => u.Update(), Times.Once);
        }
    }
}