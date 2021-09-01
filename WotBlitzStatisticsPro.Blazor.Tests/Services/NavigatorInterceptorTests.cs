using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Tests.Services
{
    public class NavigatorInterceptorTests: TestContextBase
    {
        private NavigationMessagesInterceptor _service;
        private MockNavigationManager _navigationManager;
        private Mock<ILocalStorageService> _localStorageMock;


        [SetUp]
        public void Setup()
        {
            _localStorageMock = new();

            _navigationManager = new MockNavigationManager();
            _service = new NavigationMessagesInterceptor(_navigationManager, _localStorageMock.Object, MediatorMock.Object);

        }

        [Test]
        public async Task ShouldNavigateToAppropriateLinkWhenOpenPlayerInfoMessageArrived()
        {
            int accountId = 42;
            var message = new OpenPlayerInfoMessage(accountId, false);

            await _service.Handle(message, CancellationToken.None);

            _navigationManager.Uri.Should().Be($"{_navigationManager.BaseUri}player/{accountId}");
        }

        [Test]
        public async Task ShouldCallProlongWargamingAccessTokenMessageIfFiveDaysBeforeTokenExpiration()
        {
            int accountId = 42;
            string oldToken = "OldTocken";
            long expiration = Convert.ToInt64((DateTime.Now.AddDays(4) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            _localStorageMock.Setup(s => s.GetItemAsync<LoginInfo>(Constants.LoginInfoLocalStorageKey))
                .ReturnsAsync(new LoginInfo { AccountId = accountId, AccessToken = oldToken, ExpiresAt = expiration});

            var message = new OpenPlayerInfoMessage(accountId, true);

            await _service.Handle(message, CancellationToken.None);

            MediatorMock.Verify(m => m.Publish(
                It.IsAny<ProlongWargamingAccessToken>(),
                It.IsAny<CancellationToken>()), Times.Once);
            MediatorMock.Verify(m => m.Publish(
                It.IsAny<RedirectToWgLoginMessage>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Test]
        public async Task ShouldNotCallProlongWargamingAccessTokenMessageIfMoreThenFiveDaysBeforeTokenExpiration()
        {
            int accountId = 42;
            string oldToken = "OldTocken";
            long expiration = Convert.ToInt64((DateTime.Now.AddDays(6) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            _localStorageMock.Setup(s => s.GetItemAsync<LoginInfo>(Constants.LoginInfoLocalStorageKey))
                .ReturnsAsync(new LoginInfo { AccountId = accountId, AccessToken = oldToken, ExpiresAt = expiration });

            var message = new OpenPlayerInfoMessage(accountId, true);

            await _service.Handle(message, CancellationToken.None);

            MediatorMock.Verify(m => m.Publish(
                It.IsAny<ProlongWargamingAccessToken>(),
                It.IsAny<CancellationToken>()), Times.Never);

            MediatorMock.Verify(m => m.Publish(
                It.IsAny<RedirectToWgLoginMessage>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Test]
        public async Task ShouldNotCallProlongWargamingAccessTokenMessageIfPlayerNotLoffedIn()
        {
            int accountId = 42;
            var message = new OpenPlayerInfoMessage(accountId, false);

            await _service.Handle(message, CancellationToken.None);

            MediatorMock.Verify(m => m.Publish(
                It.IsAny<RedirectToWgLoginMessage>(),
                It.IsAny<CancellationToken>()), Times.Never);

            MediatorMock.Verify(m => m.Publish(
                It.IsAny<ProlongWargamingAccessToken>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Test]
        public async Task ShouldCallRedirectToWgLoginMessageIfTokenIsExpired()
        {
            int accountId = 42;
            string oldToken = "OldTocken";
            var realm = RealmType.Na;
            long expiration = Convert.ToInt64((DateTime.Now.AddDays(-1) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
            _localStorageMock.Setup(s => s.GetItemAsync<LoginInfo>(Constants.LoginInfoLocalStorageKey))
                .ReturnsAsync(new LoginInfo { AccountId = accountId, AccessToken = oldToken, ExpiresAt = expiration, Realm = realm });

            var message = new OpenPlayerInfoMessage(accountId, true);

            await _service.Handle(message, CancellationToken.None);



            MediatorMock.Verify(m => m.Publish(
                It.Is<RedirectToWgLoginMessage>(m => m.Realm == realm),
                It.IsAny<CancellationToken>()), Times.Once);

            MediatorMock.Verify(m => m.Publish(
                It.IsAny<ProlongWargamingAccessToken>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}