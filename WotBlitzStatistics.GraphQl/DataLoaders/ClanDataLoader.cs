using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatistics.GraphQl.DataLoaders
{
    public class ClanDataLoader : DataLoaderBase<long, ClanInfo>
    {
        private readonly IWargamingApiClient _wgApiClient;

        public ClanDataLoader(IWargamingApiClient wgApiClient)
        {
            _wgApiClient = wgApiClient;
        }

        protected override async Task<IReadOnlyList<Result<ClanInfo>>> FetchAsync(
            IReadOnlyList<long> keys, 
            CancellationToken cancellationToken)
        {
            var result = new List<Result<ClanInfo>>();
            foreach (var key in keys)
            {
                result.Add(await _wgApiClient.GetClanInfo(key));
            }

            return result.AsReadOnly();
        }
    }
}