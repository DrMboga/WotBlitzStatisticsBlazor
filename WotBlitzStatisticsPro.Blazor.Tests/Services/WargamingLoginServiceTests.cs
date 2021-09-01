using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Moq;
using NUnit.Framework;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Tests.Services
{
    public class WargamingLoginServiceTests: TestContextBase
    {
        private Mock<IGraphQlBackendService> _graphQlBackendMock;
        private Mock<ILocalStorageService> _localStorageMock;

        private WargamingLoginService _service;


        [SetUp]
        public void Setup()
        {
            _graphQlBackendMock = new();
            _localStorageMock = new();

            _service = new WargamingLoginService(
                _graphQlBackendMock.Object,
                TestContext.Services.GetService<DialogService>(),
                TestContext.Services.GetService<IStringLocalizer<App>>(),
                NavigationManagerMock,
                _localStorageMock.Object,
                MediatorMock.Object
                );
        }

        [Test]
        public async Task ShouldRequestRedirectUrlFromBackendWhenRedirectToWgLoginMessageArrives()
        {
            var realm = RealmType.Eu;
            string url = "/fakeUrl";
            _graphQlBackendMock.Setup(b => b.GetWgLoginUrl(realm)).ReturnsAsync(url);
            await _service.Handle(new RedirectToWgLoginMessage(realm), CancellationToken.None);

            _graphQlBackendMock.Verify(b => b.GetWgLoginUrl(realm), Times.Once);
        }

        [Test]
        public async Task ShouldNavigateToAppropriateUrlWhenRedirectToWgLoginMessageArrives()
        {
            var realm = RealmType.Eu;
            string url = "/fakeUrl";
            _graphQlBackendMock.Setup(b => b.GetWgLoginUrl(It.IsAny<RealmType>())).ReturnsAsync(url);
            await _service.Handle(new RedirectToWgLoginMessage(realm), CancellationToken.None);

            NavigationManagerMock.NavigationCount.Should().Be(1);
            NavigationManagerMock.Uri.Should().Be($"https://unit-test.example{url}&redirect_uri=https://unit-test.example/login/{realm}");
        }

        [Test]
        public async Task ShouldStoreAppropriateDataToLocalStorageWhenRedirectFromWgLoginMessageArrives()
        {
            var realm = RealmType.Asia;
            string nick = "fakeNick";
            string token = "fakeToken";
            long accountId = 123456789;
            long expiration = 987654321;
            
            await _service.Handle(new RedirectFromWgLoginMessage(realm, nick, accountId, token, expiration), CancellationToken.None);

            _localStorageMock.Verify(s => s.SetItemAsync<LoginInfo>(
                    Constants.LoginInfoLocalStorageKey, 
                    It.Is<LoginInfo>(l => l.Realm == realm && l.NickName == nick && l.AccountId == accountId && l.AccessToken == token && l.ExpiresAt == expiration))
               , Times.Once);
        }

        [Test]
        public async Task ShouldFireOnPlayerInfoMessageWhenRedirectFromWgLoginMessageArrives()
        {
            var realm = RealmType.Asia;
            string nick = "fakeNick";
            string token = "fakeToken";
            long accountId = 123456789;
            long expiration = 987654321;

            await _service.Handle(new RedirectFromWgLoginMessage(realm, nick, accountId, token, expiration), CancellationToken.None);

            MediatorMock.Verify(m => m.Publish(
                It.Is<OpenPlayerInfoMessage>(m => m.AccountId == accountId && m.IsLoggedIn),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task ShouldCallAppropriateBackendMethodAndSaveNewTokenToLocalStorageWhenProlongWargamingAccessTokenMessageInvoked()
        {
            // Setup
            int accountId = 42;
            var realm = RealmType.Na;
            string oldToken = "OldToken";
            string newToken = "NewToken";
            long newEvpiration = 129876543;

            _localStorageMock.Setup(s => s.GetItemAsync<LoginInfo>(Constants.LoginInfoLocalStorageKey))
                .ReturnsAsync(new LoginInfo { AccountId = accountId, AccessToken = oldToken, ExpiresAt = 12345678, Realm = realm });
            _graphQlBackendMock.Setup(s => s.ProlongToken(accountId, oldToken, realm)).ReturnsAsync(new LoginInfo { AccountId = accountId, AccessToken = newToken, ExpiresAt = newEvpiration, Realm = realm });

            // Avtion
            await _service.Handle(new ProlongWargamingAccessToken(), CancellationToken.None);

            // Assert
            _graphQlBackendMock.Verify(s => s.ProlongToken(accountId, oldToken, realm), Times.Once);
            _localStorageMock.Verify(s => s.SetItemAsync<LoginInfo>(
                    Constants.LoginInfoLocalStorageKey,
                    It.Is<LoginInfo>(l => l.Realm == realm && l.AccountId == accountId && l.AccessToken == newToken && l.ExpiresAt == newEvpiration))
               , Times.Once);
        }
    }
}
