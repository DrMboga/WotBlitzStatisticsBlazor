using System.Threading;
using Bunit;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Radzen;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Services;
using WotBlitzStatisticsPro.Blazor.Shared;

namespace WotBlitzStatisticsPro.Blazor.Tests
{
    public class MainLayoutTest: TestContextWrapper
    {
        private readonly Mock<IMediator> _mediatorMock = new();
        private readonly Mock<ISearchDialogService> _searchServiceMock = new();
        private IRenderedComponent<MainLayout> _component;

        [SetUp]
        public void Setup()
        {
            TestContext = new Bunit.TestContext();
            TestContext.Services.AddSingleton(_mediatorMock.Object);

            TestContext.Services.AddSingleton<DialogService>();
            TestContext.Services.AddSingleton(_searchServiceMock.Object);
            TestContext.Services.AddLocalization();

            _component = TestContext.RenderComponent<MainLayout>();
        }

        [Test]
        public void ShouldFireMediatorEventEachTimeWhenLanguageChanged()
        {
            // =====================================
            // Hint for css lookup
            /*
By.css('.classname')          // get by class name
By.css('input[type=radio]')   // get input by type radio
By.css('.parent .child')      // get child who has a parent
             */

            // Take a look at the component text
            // var html = _component.Markup;

            // =====================================

            // All 3 languages in a RadzenSplitButton
            var elements = _component.FindAll(".rz-menuitem");

            elements.Should().NotBeNull();
            elements.Count.Should().Be(3);

            string[] expectedLanguages = {"en-US", "ru-RU", "de-DE"};
            for (int i = 0; i < 3; i++)
            {
                elements[i].Click();
                _mediatorMock.Verify(m => m.Publish(
                    It.Is<ChangeCurrentCultureMessage>(m => m.CultureName == expectedLanguages[0]), 
                    It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        [TearDown]
        public void TearDown() => TestContext?.Dispose();
    }
}