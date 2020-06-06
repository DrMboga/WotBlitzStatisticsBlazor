using System.Collections.Generic;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class AchievementOptionProfile : Profile
    {
        public AchievementOptionProfile()
        {
            CreateMap<WotEncyclopediaAchievementsOptions, AchievementOption>()
                .ForMember(d => d.Name, o => o.MapFrom(_ => new List<LocalizableString>()))
                .ForMember(d => d.Description, o => o.MapFrom(_ => new List<LocalizableString>()));
        }
    }
}