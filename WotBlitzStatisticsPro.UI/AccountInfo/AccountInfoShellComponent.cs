using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.UI.AccountInfo
{
	public class AccountInfoShellComponent : ComponentBase
	{
		[Inject]
		public IAccountInfoService AccountInfoService { get; set; }

		[Parameter]
		public long AccountId { get; set; }

		public PlayerAccountInfo PlayerAccountInfo { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			PlayerAccountInfo = await AccountInfoService.GetAccountInfo(AccountId);
		}
	}
}
