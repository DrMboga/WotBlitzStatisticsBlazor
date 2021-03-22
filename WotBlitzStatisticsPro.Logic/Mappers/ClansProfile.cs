using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;
using WotBlitzStatisticsPro.Logic.Calculations;


namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class ClansProfile: Profile
    {
        public ClansProfile()
        {
            CreateMap<ClanAccountInfo, ClanInfoResponse>()
                .ForMember(d => d.JoinedAt,
                    o => o.MapFrom(s => s.JoinedAt.HasValue ? s.JoinedAt.Value.ToDateTime() : new DateTime(1970, 1, 1)))
                .ForMember(d => d.Role, 
                    o => o.MapFrom((src, dest, destMember, context) =>
                    {
                        var dictionary = context.Items["roles"] as Dictionary<string, string>;
                        if (string.IsNullOrEmpty(src.Role) || dictionary == null)
                        {
                            return string.Empty;
                        }

                        return dictionary[src.Role];
                    }))
            ;

            CreateMap<ClanInfo, ClanInfoResponse>()
                .ForMember(d => d.CreatedAt,
                    o => o.MapFrom(s => s.CreatedAt.HasValue ? s.CreatedAt.Value.ToDateTime() : new DateTime(1970, 1, 1)))
                .ForMember(d => d.UpdatedAt,
                    o => o.MapFrom(s => s.UpdatedAt.HasValue ? (DateTime?)s.UpdatedAt.Value.ToDateTime() : null))
                ;
;
        }
    }
}