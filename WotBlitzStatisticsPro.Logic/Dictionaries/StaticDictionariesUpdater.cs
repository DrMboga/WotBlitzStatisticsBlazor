using System;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient;

namespace WotBlitzStatisticsPro.Logic.Dictionaries
{
    public class StaticDictionariesUpdater : IDictionaryUpdater
    {
        private readonly IWargamingDictionariesApiClient _wargamingDictionariesApiClient;

        public StaticDictionariesUpdater(IWargamingDictionariesApiClient wargamingDictionariesApiClient)
        {
            _wargamingDictionariesApiClient = wargamingDictionariesApiClient;
        }
        public async Task<UpdateDictionariesResponseItem> Update()
        {
            var defaultRealmType = RealmType.Eu;
            foreach (var requestLanguage in (RequestLanguage[]) Enum.GetValues(typeof(RequestLanguage)))
            {
                var (WotEncyclopediaInfoResponse, WotClanMembersDictionaryResponse) =
                    await _wargamingDictionariesApiClient.GetStaticDictionariesAsync(defaultRealmType, requestLanguage);
                // ToDo: map
                // ToDo: add to dictionary
            }

            // ToDo: Save dictionary to Mongo

            throw new System.NotImplementedException();
        }
    }
}