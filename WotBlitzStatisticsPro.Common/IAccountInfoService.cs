using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Common
{
	public interface IAccountInfoService
	{
		Task<PlayerAccountInfo> GetAccountInfo(long accountId);
	}
}
