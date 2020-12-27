using AutoMapper;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class ClanSearchResponseProfile: Profile
    {
        public ClanSearchResponseProfile()
        {
            CreateMap<WotClanListResponse, ClanSearchResponseItem>()
                .ForMember(
                    d => d.ClanId,
                    o => o.MapFrom(s => s.ClanId ?? -1));

        }
    }
}