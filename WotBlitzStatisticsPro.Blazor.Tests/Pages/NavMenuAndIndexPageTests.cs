using System;
using System.Threading;
using AngleSharp.Dom;
using Bunit;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
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


        [SetUp]
        public void Setup()
        {
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

    }
}