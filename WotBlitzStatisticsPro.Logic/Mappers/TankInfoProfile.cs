using AutoMapper;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class TankInfoProfile : Profile
    {
        public TankInfoProfile()
        {
            CreateMap<WotAccountTanksStatistics, TankInfo>();
        }
    }
}