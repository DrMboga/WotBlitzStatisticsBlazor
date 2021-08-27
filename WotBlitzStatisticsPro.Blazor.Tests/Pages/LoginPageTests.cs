using Bunit;
using Moq;
using NUnit.Framework;
using System.Threading;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Pages;

namespace WotBlitzStatisticsPro.Blazor.Tests.Pages
{
    public class LoginPageTests: TestContextBase
    {
        [Test]
        public void ShouldParseLoginDataAndSendRedirectFromWgLoginMessage()
        {
            string accessToken = "fake_token";
            string nickname = "fake_nick";
            long accountId = 123456789;
            long expiration = 987654321;
            NavigationManagerMock.NavigateTo($"/login?&status=ok&access_token={accessToken}&nickname={nickname}&account_id={accountId}&expires_at={expiration}");

            var component = TestContext.RenderComponent<Login>();

            MediatorMock.Verify(m => m.Publish(
                It.Is<RedirectFromWgLoginMessage>(m => m.AccessToken == accessToken &&
                                                       m.NickName == nickname &&
                                                       m.AccountId == accountId &&
                                                       m.ExpiresAt == expiration),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
