using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Tests.Services
{
    public class NavigatorInterceptorTests
    {
        private NavigationMessagesInterceptor _service;
        private MockNavigationManager _navigationManager;

        [SetUp]
        public void Setup()
        {
            _navigationManager = new MockNavigationManager();
            _service = new NavigationMessagesInterceptor(_navigationManager);

        }

        [Test]
        public async Task ShouldNavigateToAppropriateLinkWhenOpenPlayerInfoMessageArrived()
        {
            int accountId = 42;
            var message = new OpenPlayerInfoMessage(accountId, false);

            await _service.Handle(message, CancellationToken.None);

            _navigationManager.Uri.Should().Be($"{_navigationManager.BaseUri}player/{accountId}");
        }
    }
}