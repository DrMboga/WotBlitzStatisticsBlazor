using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.WgApiClient
{
    public interface IWargamingDictionariesApiClient
    {
        Task<(
            WotEncyclopediaInfoResponse,
            WotClanMembersDictionaryResponse)> GetStaticDictionariesAsync(
            RealmType realmType = RealmType.Ru,
            RequestLanguage language = RequestLanguage.En);
    }
}