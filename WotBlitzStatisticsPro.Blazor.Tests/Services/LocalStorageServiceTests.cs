using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bunit;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Moq;
using NUnit.Framework;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Services;
using TestContext = Bunit.TestContext;

namespace WotBlitzStatisticsPro.Blazor.Tests.Services
{
    public class LocalStorageServiceTests
    {
        private TestContext _testContext;
        private BunitJSInterop _jsRuntimeMock;
        protected MockNavigationManager _navigationManagerMock;

        private LocalStorageService _localStorageService;


        [SetUp]
        public void Setup()
        {
            _navigationManagerMock = new MockNavigationManager();

            _testContext = new TestContext();
            _jsRuntimeMock = _testContext.JSInterop;
            _jsRuntimeMock.Setup<string>("localStorage.getItem", UserSettings.UserSettingsLocalStorageKey).SetResult(string.Empty);
            var localStorageSetItemHandler = _jsRuntimeMock.SetupVoid("localStorage.setItem", _ => true);
            localStorageSetItemHandler.SetVoidResult();

            _localStorageService = new LocalStorageService(_jsRuntimeMock.JSRuntime, _navigationManagerMock);
        }

        [Test]
        public async Task ShouldInvokeJsLocalStorageSetWithAppropriateDataOnChangeCurrentCulture()
        {
            string cultureName = "fake-CL";

            await _localStorageService.Handle(new ChangeCurrentCultureMessage(cultureName), CancellationToken.None);

            _jsRuntimeMock.Invocations.Count.Should().Be(2);
            var jsInvocations = _jsRuntimeMock.Invocations.ToArray();
            jsInvocations[0].Identifier.Should().Be("localStorage.getItem");
            jsInvocations[1].Identifier.Should().Be("localStorage.setItem");

            var args = jsInvocations[1].Arguments;
            args.Should().NotBeNull();
            args.Count.Should().Be(2);
            args[0].Should().Be("user-settings");
            args[1].Should().Be($"{{\"Culture\":\"{cultureName}\",\"RealmType\":{(int)RealmType.Eu}}}");

            _navigationManagerMock.NavigationCount.Should().Be(1);
        }

        [Test]
        public async Task ShouldInvokeJsLocalStorageSetWithAppropriateDataOnChangeCurrentRealm()
        {
            var expectedRealm = RealmType.Asia;
            await _localStorageService.Handle(new ChangeCurrentRealmTypeMessage(expectedRealm), CancellationToken.None);

            _jsRuntimeMock.Invocations.Count.Should().Be(2);
            var jsInvocations = _jsRuntimeMock.Invocations.ToArray();
            jsInvocations[0].Identifier.Should().Be("localStorage.getItem");
            jsInvocations[1].Identifier.Should().Be("localStorage.setItem");

            var args = jsInvocations[1].Arguments;
            args.Should().NotBeNull();
            args.Count.Should().Be(2);
            args[0].Should().Be("user-settings");
            args[1].Should().Be($"{{\"Culture\":\"en-US\",\"RealmType\":{(int)expectedRealm}}}");
        }

        [TearDown]
        public void TearDown() => _testContext?.Dispose();

    }
}