using System;
using System.Collections.Generic;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class VehiclePriceProfile : Profile
    {
        public VehiclePriceProfile()
        {
            CreateMap<KeyValuePair<string, string>, VehiclePriceInXp>()
                .ForMember(d => d.TankId,
                    o => o.MapFrom(s => Convert.ToInt64(s.Key)))
                .ForMember(d => d.PricesXp,
                    o => o.MapFrom(s => Convert.ToInt64(s.Value)));
        }
    }
}