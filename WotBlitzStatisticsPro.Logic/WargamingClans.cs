using System;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic
{
    public class WargamingClans: IWargamingClans
    {
        private readonly IDictionariesDataAccessor _dictionariesDataAccessor;
        private readonly IWargamingApiClient _wargamingApiClient;
        private readonly IMapper _mapper;

        public WargamingClans(
            IDictionariesDataAccessor dictionariesDataAccessor,
            IWargamingApiClient wargamingApiClient, 
            IMapper mapper)
        {
            _dictionariesDataAccessor = dictionariesDataAccessor;
            _wargamingApiClient = wargamingApiClient;
            _mapper = mapper;
        }

        public async Task<ClanInfoResponse?> GelClanInfoByAccount(long accountId, RealmAndLanguage queryParams)
        {
            var clanRoles = await _dictionariesDataAccessor.GetClanRoles(queryParams.Language);
            var accountClanInfo =
                await _wargamingApiClient.GetPlayerClanInfo(accountId, queryParams.Realm, queryParams.Language);
            if (accountClanInfo?.ClanId == null)
            {
                return null;
            }

            var result = _mapper.Map<ClanAccountInfo, ClanInfoResponse>(accountClanInfo, 
                opt => opt.Items["roles"] = clanRoles);

            var clanInfo = await _wargamingApiClient.GetClanInfo(accountClanInfo.ClanId.Value, queryParams.Realm,
                queryParams.Language);

            _mapper.Map(clanInfo, result);

            return result;
        }
    }
}