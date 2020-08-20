using AutoMapper;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class AccountInfoProfile : Profile
    {
        public AccountInfoProfile()
        {
            CreateMap<WotAccountInfo, AccountInfo>();
        }
    }
}