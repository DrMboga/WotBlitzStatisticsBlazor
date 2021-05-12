using System.Collections.Generic;
using System.Linq;
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
            var searchResponse = await _wargamingApiClient.FindAccounts(accountNick, realmType, language);

            if (searchResponse == null)
            {
                return new AccountsSearchResponse();
            }

            var response = new AccountsSearchResponse
            {
                AccountsCount = searchResponse.Count,
                Accounts = _mapper.Map<List<WotAccountListResponse>, List<AccountsSearchResponseItem>>(searchResponse)
            };

            if (searchResponse.Count > 100)
            {
                return response;
            }

            var accountIds = response.Accounts.Select(a => a.AccountId).ToArray();

            var shortAccountInfos =
                await _wargamingApiClient.GetShortPlayerAccountsInfo(accountIds, realmType, language);

            var accountClans = await _wargamingApiClient.GetBulkPlayerClans(accountIds, realmType, language);
            List<ClanInfo>? clans = null;
            if (accountClans != null)
            {
                clans = await _wargamingApiClient.GetShortClansInfo(accountClans.Where(c => c.ClanId.HasValue).Select(c => c.ClanId!.Value).ToArray(),
                    realmType, language);
            }

            for (int i = 0; i < response.Accounts.Count; i++)
            {
                var accountResponse = response.Accounts.ToArray()[i];
                var shortAccountInfo = shortAccountInfos?.FirstOrDefault(a => a.AccountId == accountResponse.AccountId);
                if (shortAccountInfo != null)
                {
                    _mapper.Map(shortAccountInfo, accountResponse);
                }

                // Clan
                if (accountClans != null && clans != null)
                {
                    var aClan = accountClans.FirstOrDefault(c => c.AccountId == accountResponse.AccountId);
                    var clan = clans.FirstOrDefault(c => c.ClanId == aClan?.ClanId);
                    if (clan != null)
                    {
                        accountResponse.ClanTag = clan.Tag;
                    }
                }
            }

            // Filter WOT Blitz accounts
            response.Accounts = response.Accounts.Where(a => a.BattlesCount > 0).ToList();
            response.AccountsCount = response.Accounts.Count;

            return response;
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