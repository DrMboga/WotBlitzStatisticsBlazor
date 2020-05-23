using AutoMapper;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class AccountSearchResponseProfile : Profile
    {
        public AccountSearchResponseProfile()
        {
            CreateMap<WotAccountListResponse, AccountsSearchResponseItem>()
                .ForMember(
                    d => d.AccountId, 
                    o => o.MapFrom(s => s.AccountId.Value));
        }
    }
}