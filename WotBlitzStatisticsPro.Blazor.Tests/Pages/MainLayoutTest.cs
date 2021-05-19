using System.Threading;
using Bunit;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Radzen;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Shared;

namespace WotBlitzStatisticsPro.Blazor.Tests.Pages
{
    public class MainLayoutTest : TestContextBase
    {
        private IRenderedComponent<MainLayout> _component;

        [SetUp]
        public void Setup()
        {
            _component = TestContext?.RenderComponent<MainLayout>();
        }

        [Test]
        public void ShouldFireMediatorEventEachTimeWhenLanguageChanged()
        {
            // =====================================
            // Hint for css selector
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
                MediatorMock.Verify(m => m.Publish(
                    It.Is<ChangeCurrentCultureMessage>(m => m.CultureName == expectedLanguages[0]),
                    It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        [TestCase(NotificationType.Info, NotificationSeverity.Info)]
        [TestCase(NotificationType.Warning, NotificationSeverity.Warning)]
        [TestCase(NotificationType.Error, NotificationSeverity.Error)]
        public void ShouldEmitRadzenMessageWhenNotificationsServiceHasMessage(NotificationType notificationType, NotificationSeverity expectedSeverity)
        {
            string expectedSummary = "Foo";
            string expectedMessage = "Bar";

            NotificationsServiceMock.SetupGet(n => n.Type).Returns(notificationType);
            NotificationsServiceMock.SetupGet(n => n.Summary).Returns(expectedSummary);
            NotificationsServiceMock.SetupGet(n => n.Message).Returns(expectedMessage);

            // Action
            NotificationsServiceMock.Raise(n => n.MessageArrived += null);

            var radzenNotification = TestContext?.Services.GetService<NotificationService>();
            var msg = radzenNotification?.Messages;
            msg.Should().NotBeNull();
            msg?.Count.Should().Be(1);

            msg?[0].Summary.Should().Be(expectedSummary);
            msg?[0].Detail.Should().Be(expectedMessage);
            msg?[0].Severity.Should().Be(expectedSeverity);
        }
    }
}