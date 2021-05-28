using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Radzen.Blazor;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Pages;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Tests.Pages
{
    public class SearchDialogTests: TestContextBase
    {
        private IRenderedComponent<SearchDialog> _component;
        private Mock<IGraphQlBackendService> _graphQlBackendMock;
        private Mock<ILocalStorageService> _localStorageServiceMock;

        private readonly GraphQlBackendMockService _mockDataService = new(false);

        private UserSettings _settings;

        [SetUp]
        public void Setup()
        {
            _settings = new();

            _graphQlBackendMock = new ();
            _localStorageServiceMock = new();
            _localStorageServiceMock.Setup(s => s.ReadSettings()).ReturnsAsync(_settings);

            TestContext?.Services.AddSingleton(_graphQlBackendMock.Object);
            TestContext?.Services.AddSingleton(_localStorageServiceMock.Object);

            TestContext?.JSInterop.SetupVoid("Radzen.preventArrows", _ => true).SetVoidResult();
            TestContext?.JSInterop.SetupVoid("Radzen.closePopup", _ => true).SetVoidResult();

            _component = TestContext?.RenderComponent<SearchDialog>();
        }

        [Test]
        public void ShouldChangeCurrentRealmOnDropdownClick()
        {
            // Default realm is Eu
            _component.Instance.CurrentRealmType.Should().Be(RealmType.Eu);

            // Find 4 dropdown items
            var items = _component.FindAll(".rz-dropdown-item");
            items.Should().NotBeNull();
            items.Count.Should().Be(4);

            // Act
            // Asia is the last dropdown item
            var asiaItem = items[3];
            asiaItem.Click();

            // Assert
            _component.Instance.CurrentRealmType.Should().Be(RealmType.Asia);
        }

        [TestCase(DialogType.FindPlayer)]
        [TestCase(DialogType.FindClan)]
        public async Task ShouldCallAppropriateSearchMethodOnFindEvent(DialogType dialogType)
        {
            string search = "Anakin";
            _component.Instance.DialogType = dialogType;

            // Act
            await _component.Instance.OnSearchTextChange(search);

            if (dialogType == DialogType.FindPlayer)
            {
                _graphQlBackendMock.Verify(b => b.FindPlayers(search, _component.Instance.CurrentRealmType), Times.Once);
                _graphQlBackendMock.Verify(b => b.FindClans(search, _component.Instance.CurrentRealmType), Times.Never);
            }

            if (dialogType == DialogType.FindClan)
            {
                _graphQlBackendMock.Verify(b => b.FindClans(search, _component.Instance.CurrentRealmType), Times.Once);
                _graphQlBackendMock.Verify(b => b.FindPlayers(search, _component.Instance.CurrentRealmType), Times.Never);
            }
        }

        [Test]
        public async Task IfSearchStringLessThanThreeCharactersSearchShouldNotHappen()
        {
            string search = "An";

            // Act
            await _component.Instance.OnSearchTextChange(search);

            // Assert
            _graphQlBackendMock.Verify(b => b.FindPlayers(It.IsAny<string>(), _component.Instance.CurrentRealmType), Times.Never);
        }

        [Test]
        public async Task ShouldShowProgressBarAndHideListOnFindEvent()
        {
            var progressBar = _component.FindComponent<RadzenProgressBar>();
            var listBox = _component.FindComponent<RadzenListBox<long>>();

            // initially progress bar should be hidden and listBox should be shown
            progressBar.Instance.Visible.Should().Be(false);
            listBox.Instance.Visible.Should().Be(true);

            _graphQlBackendMock.Setup(b => b.FindPlayers(It.IsAny<string>(), _component.Instance.CurrentRealmType))
                .Callback(() =>
                {
                    // While executing the FindPlayerMethod, progress bar should be shown and listBox should be hidden
                    progressBar.Instance.Visible.Should().Be(true);
                    listBox.Instance.Visible.Should().Be(false);
                });

            // Act
            await _component.Instance.OnSearchTextChange("Anakin");

            // Here after returning a value, progress bar should be hidden again and listBox should be shown
            progressBar.Instance.Visible.Should().Be(false);
            listBox.Instance.Visible.Should().Be(true);
        }

        [Test]
        public async Task ShouldFillListOnFindPlayersEvent()
        {
            string search = "Anakin";
            _component.Instance.DialogType = DialogType.FindPlayer;

            var listBox = _component.FindComponent<RadzenListBox<long>>();
            // Initially listBox should be empty
            listBox.Instance.Data.ToDynamicArray().Length.Should().Be(0);

            var players = await _mockDataService.FindPlayers(search, _component.Instance.CurrentRealmType);
            _graphQlBackendMock.Setup(b => b.FindPlayers(search, _component.Instance.CurrentRealmType)).ReturnsAsync(players);

            // Act
            await _component.Instance.OnSearchTextChange(search);

            // All list items
            var items = listBox.Instance.Data;

            // Assert
            var playerItems = items as IFindPlayers_Players[] ?? items.Cast<IFindPlayers_Players>().ToArray();
            playerItems.Should().NotBeNull();
            playerItems.Should().NotBeEmpty();
            playerItems.Length.Should().Be(players?.Count);
            foreach (var playerItem in playerItems)
            {
                var expectedPlayer = players?.FirstOrDefault(p => p.AccountId == playerItem.AccountId);
                expectedPlayer.Should().NotBeNull();
                playerItem.Nickname.Should().Be(expectedPlayer?.Nickname);
                playerItem.WinRate.Should().Be(expectedPlayer?.WinRate);
                playerItem.BattlesCount.Should().Be(expectedPlayer?.BattlesCount);
            }
        }

        [Test]
        public async Task ShouldFillListOnFindClansEvent()
        {
            string search = "Anakin";
            _component.Instance.DialogType = DialogType.FindClan;

            var listBox = _component.FindComponent<RadzenListBox<long>>();
            // Initially listBox should be empty
            listBox.Instance.Data.ToDynamicArray().Length.Should().Be(0);

            var clans = await _mockDataService.FindClans(search, _component.Instance.CurrentRealmType);
            _graphQlBackendMock.Setup(b => b.FindClans(search, _component.Instance.CurrentRealmType)).ReturnsAsync(clans);

            // Act
            await _component.Instance.OnSearchTextChange(search);

            // All list items
            listBox = _component.FindComponent<RadzenListBox<long>>();
            var items = listBox.Instance.Data;

            // Assert
            var clanItems = items as IFindClans_Clans[] ?? items.Cast<IFindClans_Clans>().ToArray();
            clanItems.Should().NotBeNull();
            clanItems.Should().NotBeEmpty();
            clanItems.Length.Should().Be(clans?.Count);
            foreach (var clanItem in clanItems)
            {
                var expectedClan = clans?.FirstOrDefault(p => p.ClanId == clanItem.ClanId);
                expectedClan.Should().NotBeNull();
                clanItem.Name.Should().Be(expectedClan?.Name);
                clanItem.Tag.Should().Be(expectedClan?.Tag);
            }
        }

        [Test]
        public async Task ShouldChangeCurrentValueWhenItemInTheListSelected()
        {
            string search = "Anakin";
            _component.Instance.DialogType = DialogType.FindPlayer;

            var players = await _mockDataService.FindPlayers(search, _component.Instance.CurrentRealmType);
            _graphQlBackendMock.Setup(b => b.FindPlayers(search, _component.Instance.CurrentRealmType)).ReturnsAsync(players);

            await _component.Instance.OnSearchTextChange(search);
            var items = _component.FindAll(".rz-multiselect-item");
            items.Count.Should().Be(players?.Count);

            int i = 2;

            // Act
            items[i].Click();

            // Assert
            _component.Instance.CurrentValue.Should().Be(players?[i].AccountId);
        }

        [TestCase(DialogType.FindPlayer)]
        [TestCase(DialogType.FindClan)]
        public void ShouldRedirectToAppropriatePageWhenOkButtonClicked(DialogType dialogType)
        {
            int currentValue = 123456789;
            _component.Instance.DialogType = dialogType;

            _component.Instance.CurrentValue = currentValue;

            var button = _component.Find(".rz-button");

            // Act
            button.Click();

            if (dialogType == DialogType.FindPlayer)
            {
                MediatorMock.Verify(m => m.Publish(
                    It.Is<OpenPlayerInfoMessage>(m => m.AccountId == currentValue),
                    It.IsAny<CancellationToken>()), Times.Once);

            }
            if (dialogType == DialogType.FindClan)
            {
                // OpenPlayerInfoMessage
                MediatorMock.Verify(m => m.Publish(
                    It.Is<OpenClanInfoMessage>(m => m.ClanId == currentValue),
                    It.IsAny<CancellationToken>()), Times.Once);

            }
        }
    }
}