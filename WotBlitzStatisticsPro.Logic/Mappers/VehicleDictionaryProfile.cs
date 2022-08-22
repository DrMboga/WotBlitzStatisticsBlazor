using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class VehicleDictionaryProfile : Profile
    {
        public VehicleDictionaryProfile()
        {
            CreateMap<WotEncyclopediaVehiclesResponse, VehiclesDictionary>()
                .ForMember(d => d.TankId,
                    o => o.MapFrom(s => s.TankId))
                .ForMember(d => d.Name, o => o.MapFrom(_ => new List<LocalizableString>()))
                .ForMember(d => d.Description, o => o.MapFrom(_ => new List<LocalizableString>()))
                .ForMember(d => d.TypeId,
                    o => o.MapFrom(s => s.Type))
                .ForMember(d => d.NationId,
                    o => o.MapFrom(s => s.Nation))
                .ForMember(d => d.Tier,
                    o => o.MapFrom(s => s.Tier))
                .ForMember(d => d.PreviewImage,
                    o => o.MapFrom(s => s.Images == null ? string.Empty : s.Images["preview"]))
                .ForMember(d => d.NormalImage,
                    o => o.MapFrom(s => s.Images == null ? string.Empty : s.Images["normal"]))
                .ForMember(d => d.PriceCredit,
                    o => o.MapFrom(s => s.Cost == null ? decimal.Zero : Convert.ToDecimal(s.Cost["price_credit"])))
                .ForMember(d => d.PriceGold,
                    o => o.MapFrom(s => s.Cost == null ? decimal.Zero : Convert.ToDecimal(s.Cost["price_gold"])))
                .ForMember(d => d.NexTanksInTree,
                    o =>
                        o.MapFrom(s => s.NextTanks))
                .ForMember(d => d.PriceXp,
                    o =>
                        o.MapFrom(s => s.PricesXp));

            CreateMap<IVehiclesDictionary, VehicleResponse>()
                .ForMember(v => v.Name,
                    o => o.MapFrom((src, dest, destMember, context) =>
                            src.Name.FirstOrDefault(l => l.Language == (RequestLanguage) context.Items["language"])?.Value ?? string.Empty))
                .ForMember(v => v.Description,
                    o => o.MapFrom((src, dest, destMember, context) =>
                            src.Description.FirstOrDefault(l => l.Language == (RequestLanguage) context.Items["language"])?.Value ?? string.Empty))
                .ForMember(v => v.NexTanksInTree,
                    o => o.MapFrom(src => src.NexTanksInTree.Select(t => t.TankId).ToList()))
            ;

        }
    }
}