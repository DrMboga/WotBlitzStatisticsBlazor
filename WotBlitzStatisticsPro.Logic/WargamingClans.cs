using System;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic
{
    public class WargamingClans: IWargamingClans
    {
        private const RealmType DefaultRealm = RealmType.Ru;
        private const RequestLanguage DefaultRequestLanguage = RequestLanguage.En;

        public Task<ClanInfoResponse> GelClanInfoByAccount(long accountId, RealmAndLanguage queryParams)
        {
            // ToDo: Make Wargaming request
            return Task.FromResult(new ClanInfoResponse {ClanId = 42, Name = "Fake clan"});
        }
    }
}