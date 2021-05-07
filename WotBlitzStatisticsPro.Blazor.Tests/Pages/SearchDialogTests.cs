using Bunit;
using NUnit.Framework;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Pages;

namespace WotBlitzStatisticsPro.Blazor.Tests.Pages
{
    public class SearchDialogTests: TestContextBase
    {
        private IRenderedComponent<SearchDialog> _component;


        [SetUp]
        public void Setup()
        {
            _component = TestContext?.RenderComponent<SearchDialog>();
        }


        [TestCase(DialogType.FindPlayer)]
        [TestCase(DialogType.FindClan)]
        [Ignore("Search component is not implemented yet")]
        public void ShouldRedirectToAppropriatePageWhenOkButtonClicked(DialogType dialogType)
        {
            // Find OK button by CSS and click
            // Check OpenPlayerInfoMessage with appropriate accountId/clanId
        }
    }
}