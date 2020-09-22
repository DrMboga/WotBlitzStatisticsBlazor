using AutoMapper;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class TankInfoStatisticsProfile: Profile
    {
        public TankInfoStatisticsProfile()
        {
            CreateMap<WotAccountTanksFullStatistics, TankInfoHistory>();
        }
    }
}