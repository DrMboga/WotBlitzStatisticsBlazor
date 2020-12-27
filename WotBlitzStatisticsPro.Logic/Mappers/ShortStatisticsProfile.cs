using AutoMapper;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic.Calculations;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class ShortStatisticsProfile: Profile
    {
        public ShortStatisticsProfile()
        {
            CreateMap<IStatistics, ShortStatistics>()
                .ForMember(d => d.LastBattleTime, 
                    o => o.MapFrom(s => s.LastBattleTime.ToDateTime()))
                .ForMember(d => d.AvgDamage,
                    o => o.MapFrom(s => s.Battles.HasValue && s.DamageDealt.HasValue && s.Battles > 0 ? ((decimal)s.DamageDealt / s.Battles) : 0m))
                .ForMember(d => d.AvgXp,
                    o => o.MapFrom(s => s.Battles.HasValue && s.Xp.HasValue && s.Battles > 0 ? ((decimal)s.Xp / s.Battles) : 0m))
                .ForMember(d => d.WinRate,
                    o => o.MapFrom(s => s.Battles.HasValue && s.Wins.HasValue && s.Battles > 0 ? (100 * (decimal)s.Wins / s.Battles) : 0m))
                ;
        }
    }
}