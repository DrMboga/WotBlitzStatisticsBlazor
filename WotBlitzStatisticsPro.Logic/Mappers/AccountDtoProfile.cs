using System.Linq;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess.Model;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;
using WotBlitzStatisticsPro.Logic.Calculations;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class AccountDtoProfile: Profile
    {
        public AccountDtoProfile()
        {
            CreateMap<AccountInfo, AccountInfoResponse>()
                .ForMember(dest => dest.CreatedAt,
                    o => o.MapFrom(s => s.CreatedAt.ToDateTime()))
                .ForMember(dest => dest.LastBattleTime,
                    o => o.MapFrom(s => s.LastBattleTime.ToDateTime()));

            CreateMap<AccountInfoHistory, AccountInfoResponse>()
                .ForMember(d => d.LastBattleTime, o => o.Ignore())
                .ForMember(d => d.Battles, 
                    o => o.MapFrom(s => s.Battles ?? 0));

            CreateMap<TankInfo, TankInfoResponse>()
                .ForMember(dest => dest.LastBattleTime,
                    o => o.MapFrom(s => s.LastBattleTime.ToDateTime()));

            CreateMap<TankInfoHistory, TankInfoResponse>()
                .ForMember(d => d.LastBattleTime, 
                    o => o.Ignore());

            CreateMap<IVehiclesDictionary, TankInfoResponse>()
                .ForMember(d => d.TankId, o => o.Ignore())
                .ForMember(d => d.TankNationId,
                    o => o.MapFrom(s => string.IsNullOrEmpty(s.NationId) ? "-" : s.NationId))
                .ForMember(d => d.TankTypeId,
                    o => o.MapFrom(s => string.IsNullOrEmpty(s.TypeId) ? "-" : s.TypeId))
                .ForMember(d => d.Name,
                    o => o.MapFrom((src, dest, destMember, context) =>
                        src.Name.FirstOrDefault(l => l.Language == (RequestLanguage) context.Items["language"])?.Value));

        }
    }
}