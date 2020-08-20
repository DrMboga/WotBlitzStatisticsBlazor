using AutoMapper;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class AccountInfoStatisticsProfile : Profile
    {
        public AccountInfoStatisticsProfile()
        {
            CreateMap<WotAccountFullStatistics, AccountInfoHistory>();
        }
    }
}