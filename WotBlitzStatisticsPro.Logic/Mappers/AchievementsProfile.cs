using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Common.Model.Achievements;
using WotBlitzStatisticsPro.DataAccess.Model;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.Mappers
{
    public class AchievementsProfile: Profile
    {
        public AchievementsProfile()
        {
            CreateMap<WotEncyclopediaAchievementsOptions, AchievementOption>()
                .ForMember(d => d.Name, o => o.MapFrom(_ => new List<LocalizableString>()))
                .ForMember(d => d.Description, o => o.MapFrom(_ => new List<LocalizableString>()));


            CreateMap<WotEncyclopediaAchievementsResponse, AchievementDictionary>()
                .ForMember(d => d.Name, o => o.MapFrom(_ => new List<LocalizableString>()))
                .ForMember(d => d.Condition, o => o.MapFrom(_ => new List<LocalizableString>()))
                .ForMember(d => d.Description, o => o.MapFrom(_ => new List<LocalizableString>()))
                .ForMember(d => d.HeroInfo, o => o.MapFrom(_ => new List<LocalizableString>()))
                .ForMember(d => d.SectionId, o => o.MapFrom(s => s.Section))
                .ForMember(d => d.Options, o => o.Ignore());

            CreateMap<AchievementSectionDictionary, AchievementSection>()
                .ForMember(s => s.SectionId,
                    o => o.MapFrom(d => d.AchievementSectionId))
                .ForMember(d => d.Name,
                    o => o.MapFrom((src, dest, destMember, context) =>
                        src.AchievementSectionNames
                            .FirstOrDefault(l => l.Language == (RequestLanguage) context.Items["language"])?.Value));

            CreateMap<KeyValuePair<string, int>, Achievement>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Key))
                .ForMember(d => d.AchievementValue, o => o.MapFrom(s => s.Value));

            CreateMap<AchievementDictionary, Achievement>()
                .ForMember(d => d.Condition,
                    o => o.MapFrom((src, dest, destMember, context) =>
                        src.Condition
                            .FirstOrDefault(l => l.Language == (RequestLanguage) context.Items["language"])?.Value))
                .ForMember(d => d.Description,
                    o => o.MapFrom((src, dest, destMember, context) =>
                        src.Description
                            .FirstOrDefault(l => l.Language == (RequestLanguage) context.Items["language"])?.Value))
                .ForMember(d => d.Name,
                    o => o.MapFrom((src, dest, destMember, context) =>
                        src.Name
                            .FirstOrDefault(l => l.Language == (RequestLanguage) context.Items["language"])?.Value))
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.AchievementValue, o => o.Ignore())
                .ForMember(d => d.MaxSeriesValue, s => s.Ignore())
                ;
        }
    }
}