using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Pages;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Tests.Pages
{
    public class WgLoginDialogTests: TestContextBase
    {
        private UserSettings _settings;
        private IRenderedComponent<WgLoginDialog> _component;
        private Mock<ILocalStorageService> _localStorageServiceMock;


        [SetUp]
        public void Setup()
        {
            _settings = new();

            _localStorageServiceMock = new();
            _localStorageServiceMock.Setup(s => s.ReadSettings()).ReturnsAsync(_settings);

            TestContext?.Services.AddSingleton(_localStorageServiceMock.Object);

            TestContext?.JSInterop.SetupVoid("Radzen.preventArrows", _ => true).SetVoidResult();
            TestContext?.JSInterop.SetupVoid("Radzen.closePopup", _ => true).SetVoidResult();

            _component = TestContext?.RenderComponent<WgLoginDialog>();
        }


        [Test]
        public void ShouldChangeRealmPropertiesWhenDropDownSelectedChanged()
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

        [Test]
        public void ShouldNotSendLoginMessageWhenCancelClicked()
        {
            var buttons = _component.FindAll(".rz-button");
            buttons.Should().NotBeNull();
            buttons.Count.Should().Be(2);

            // Cancel is first
            buttons[0].Click();

            // Should not send any messages to mediator
            MediatorMock.Verify(m => m.Publish(
                    It.IsAny<RedirectToWgLoginMessage>(),
                    It.IsAny<CancellationToken>()), Times.Never);
        }

        [Test]
        public void ShouldSendRedirectToWgMessageWhenOkClicked()
        {
            var realm = RealmType.Na;
            _component.Instance.CurrentRealmType = realm;
            var buttons = _component.FindAll(".rz-button");
            buttons.Should().NotBeNull();
            buttons.Count.Should().Be(2);

            // OK is the second one
            buttons[1].Click();

            // Should send messages to mediator with appropriate Realm
            MediatorMock.Verify(m => m.Publish(
                    It.Is<RedirectToWgLoginMessage>(m => m.Realm == realm),
                    It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
