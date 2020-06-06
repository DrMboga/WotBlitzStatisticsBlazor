using System.Collections.Generic;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class AchievementDictionaryProfile : Profile
    {
        public AchievementDictionaryProfile()
        {
            CreateMap<WotEncyclopediaAchievementsResponse, AchievementDictionary>()
                .ForMember(d => d.Name, o => o.MapFrom(_ => new List<LocalizableString>()))
                .ForMember(d => d.Condition, o => o.MapFrom(_ => new List<LocalizableString>()))
                .ForMember(d => d.Description, o => o.MapFrom(_ => new List<LocalizableString>()))
                .ForMember(d => d.HeroInfo, o => o.MapFrom(_ => new List<LocalizableString>()))
                .ForMember(d => d.SectionId, o => o.MapFrom(s => s.Section))
                .ForMember(d => d.Options, o => o.Ignore());

        }
    }
}