using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic
{
    public class WargamingSearch : IWargamingSearch
    {
        private readonly IWargamingApiClient _wargamingApiClient;
        private readonly IMapper _mapper;

        public WargamingSearch(IWargamingApiClient wargamingApiClient, IMapper mapper)
        {
            _wargamingApiClient = wargamingApiClient;
            _mapper = mapper;
        }

        public async Task<AccountsSearchResponse> FindAccounts(
            string accountNick, 
            RealmType realmType,
            RequestLanguage language)
        {
            var response = await _wargamingApiClient.FindAccounts(accountNick, realmType, language);

            if (response == null)
            {
                return new AccountsSearchResponse();
            }

            return new AccountsSearchResponse
            {
                AccountsCount = response.Count,
                Accounts = _mapper.Map<List<WotAccountListResponse>, List<AccountsSearchResponseItem>>(response)
            };
        }

        public async Task<ClanSearchResponse> FindClans(
            string searchString, 
            RealmType realmType, 
            RequestLanguage language)
        {
            var response = await _wargamingApiClient.FindClans(searchString, realmType, language);

            if (response == null)
            {
                return new ClanSearchResponse();
            }

            return new ClanSearchResponse
            {
                ClansCount = response.Count,
                Clans = _mapper.Map<List<WotClanListResponse>, List<ClanSearchResponseItem>>(response)
            };
        }
    }
}