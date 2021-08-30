using System;
using System.Threading;
using AngleSharp.Dom;
using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Services;
using WotBlitzStatisticsPro.Blazor.Shared;
using Index = WotBlitzStatisticsPro.Blazor.Pages.Index;

namespace WotBlitzStatisticsPro.Blazor.Tests.Pages
{
    public class NavMenuAndIndexPageTests: TestContextBase
    {
        public enum ComponentType
        {
            NavMenu,
            Index
        }

        private IRenderedComponent<NavMenu> _navMenuComponent;
        private IRefreshableElementCollection<IElement> _navMenuElements;
        private IRenderedComponent<Index> _indexComponent;
        private IRefreshableElementCollection<IElement> _indexButtons;

        private LoginInfo _loginInfo;
        private Mock<ILocalStorageService> _localStorageServiceMock;

        [SetUp]
        public void Setup()
        {
            _loginInfo = new LoginInfo { NickName = "Fake_Nick", AccountId = 123456789 };
            _localStorageServiceMock = new();

            TestContext?.Services.AddSingleton(_localStorageServiceMock.Object);

            _navMenuComponent = TestContext?.RenderComponent<NavMenu>();
            _indexComponent = TestContext?.RenderComponent<Index>();

            _navMenuElements = _navMenuComponent?.FindAll(".rz-navigation-item");
            _navMenuElements.Should().NotBeNull();
            _navMenuElements?.Count.Should().Be(4);

            _indexButtons = _indexComponent?.FindAll(".rz-button");
            _indexButtons.Should().NotBeNull();
            _indexButtons?.Count.Should().Be(3);

            
        }

        [Test]
        public void MavMenuShouldNavigateToRootWhenHomePressed()
        {
            var homeElement = _navMenuElements[0];
            homeElement.Should().NotBeNull();

            homeElement.Click();

            NavigationManagerMock.Uri.Should().Be(NavigationManagerMock.BaseUri);
        }

        [TestCase(ComponentType.NavMenu)]
        [TestCase(ComponentType.Index)]
        public void ShouldFireLoginMediatorEventWhenElementClicked(ComponentType componentType)
        {
            var targetElement = componentType switch
            {
                ComponentType.NavMenu => _navMenuElements[1],
                ComponentType.Index => _indexButtons[0],
                _ => throw new ArgumentOutOfRangeException(nameof(componentType), componentType, null)
            };
            targetElement.Click();

            MediatorMock.Verify(m => m.Publish(It.IsAny<LoginToWgMessage>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestCase(ComponentType.NavMenu)]
        [TestCase(ComponentType.Index)]
        public void ShouldFireOpenPlayerSearchMediatorEventWhenElementClicked(ComponentType componentType)
        {
            var targetElement = componentType switch
            {
                ComponentType.NavMenu => _navMenuElements[2],
                ComponentType.Index => _indexButtons[1],
                _ => throw new ArgumentOutOfRangeException(nameof(componentType), componentType, null)
            };
            targetElement.Click();

            MediatorMock.Verify(m => m.Publish(
                It.Is<OpenSearchDialogMessage>(m => m.Type == DialogType.FindPlayer), 
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestCase(ComponentType.NavMenu)]
        [TestCase(ComponentType.Index)]
        public void ShouldFireOpenClansSearchMediatorEventWhenElementClicked(ComponentType componentType)
        {
            var targetElement = componentType switch
            {
                ComponentType.NavMenu => _navMenuElements[3],
                ComponentType.Index => _indexButtons[2],
                _ => throw new ArgumentOutOfRangeException(nameof(componentType), componentType, null)
            };
            targetElement.Click();

            MediatorMock.Verify(m => m.Publish(
                It.Is<OpenSearchDialogMessage>(m => m.Type == DialogType.FindClan),
                It.IsAny<CancellationToken>()), Times.Once);

        }

        [TestCase(ComponentType.NavMenu)]
        [TestCase(ComponentType.Index)]
        public void ShouldShowLoginItemAndHideNickIfLoginInfoIsMissing(ComponentType componentType)
        {
            switch (componentType)
            {
                case ComponentType.NavMenu:
                    _navMenuElements.Should().Contain(e => e.InnerHtml.Contains("Login with WG.net ID"));
                    _navMenuElements.Should().NotContain(e => e.InnerHtml.Contains(_loginInfo.NickName));
                    _navMenuElements.Should().NotContain(e => e.InnerHtml.Contains("Log out"));
                    break;
                case ComponentType.Index:
                    _indexButtons.Should().Contain(e => e.InnerHtml.Contains("Login with WG.net ID"));
                    _indexButtons.Should().NotContain(e => e.InnerHtml.Contains(_loginInfo.NickName));
                    _indexButtons.Should().NotContain(e => e.InnerHtml.Contains("Log out"));
                    break;
            }
        }

        [TestCase(ComponentType.NavMenu)]
        [TestCase(ComponentType.Index)]
        public void ShouldShowNickItemAndHideLoginIfLoginInfoIsPresent(ComponentType componentType)
        {
            _localStorageServiceMock.Setup(s => s.GetItemAsync<LoginInfo>(It.IsAny<string>())).ReturnsAsync(_loginInfo);

            switch (componentType)
            {
                case ComponentType.NavMenu:
                    var navMenuComponent = TestContext?.RenderComponent<NavMenu>();
                    var navMenuElements = navMenuComponent?.FindAll(".rz-navigation-item");
                    navMenuElements.Should().NotBeNull();
                    navMenuElements.Count.Should().Be(5);
                    navMenuElements.Should().NotContain(e => e.InnerHtml.Contains("Login with WG.net ID"));
                    navMenuElements.Should().Contain(e => e.InnerHtml.Contains(_loginInfo.NickName));
                    navMenuElements.Should().Contain(e => e.InnerHtml.Contains("Log out"));
                    break;
                case ComponentType.Index:
                    var indexComponent = TestContext?.RenderComponent<Index>();
                    var indexButtons = indexComponent?.FindAll(".rz-button");
                    indexButtons.Should().NotBeNull();
                    indexButtons.Count.Should().Be(4);
                    indexButtons.Should().NotContain(e => e.InnerHtml.Contains("Login with WG.net ID"));
                    indexButtons.Should().Contain(e => e.InnerHtml.Contains(_loginInfo.NickName));
                    indexButtons.Should().Contain(e => e.InnerHtml.Contains("Log out"));
                    break;
            }
        }

        [TestCase(ComponentType.NavMenu)]
        [TestCase(ComponentType.Index)]
        public void ShouldFireOpenPlayerMessageWhenNickItemClicked(ComponentType componentType)
        {
            _localStorageServiceMock.Setup(s => s.GetItemAsync<LoginInfo>(It.IsAny<string>())).ReturnsAsync(_loginInfo);

            IElement targetElement = null;

            switch (componentType)
            {
                case ComponentType.NavMenu:
                    var navMenuComponent = TestContext?.RenderComponent<NavMenu>();
                    var navMenuElements = navMenuComponent?.FindAll(".rz-navigation-item");
                    targetElement = navMenuElements[1];
                    break;
                case ComponentType.Index:
                    var indexComponent = TestContext?.RenderComponent<Index>();
                    var indexButtons = indexComponent?.FindAll(".rz-button");
                    targetElement = indexButtons[0];

                    break;
            }

            targetElement?.Click();

            MediatorMock.Verify(m => m.Publish(
                It.Is<OpenPlayerInfoMessage>(m => m.AccountId == _loginInfo.AccountId && m.IsLoggedIn),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestCase(ComponentType.NavMenu)]
        [TestCase(ComponentType.Index)]
        public void ShouldFireLoGoutMessageIfLogOutItemClicked(ComponentType componentType)
        {
            _localStorageServiceMock.Setup(s => s.GetItemAsync<LoginInfo>(It.IsAny<string>())).ReturnsAsync(_loginInfo);

            IElement targetElement = null;

            switch (componentType)
            {
                case ComponentType.NavMenu:
                    var navMenuComponent = TestContext?.RenderComponent<NavMenu>();
                    var navMenuElements = navMenuComponent?.FindAll(".rz-navigation-item");
                    targetElement = navMenuElements[2];
                    break;
                case ComponentType.Index:
                    var indexComponent = TestContext?.RenderComponent<Index>();
                    var indexButtons = indexComponent?.FindAll(".rz-button");
                    targetElement = indexButtons[1];

                    break;
            }

            targetElement?.Click();

            MediatorMock.Verify(m => m.Publish(
                It.IsAny<LogOutFromWgMessage>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}