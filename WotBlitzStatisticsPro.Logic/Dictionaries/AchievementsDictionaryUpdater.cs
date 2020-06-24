using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.DataAccess.Model;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.Dictionaries
{
    public class AchievementsDictionaryUpdater : IDictionaryUpdater
    {
        private readonly IWargamingDictionariesApiClient _wargamingDictionariesApiClient;
        private readonly IDictionariesDataAccessor _dataAccessor;
        private readonly IMapper _mapper;

        [Obsolete("Parameter-less constructor only for unit tests")]
        public AchievementsDictionaryUpdater()
        {
            
        }

        public AchievementsDictionaryUpdater(IWargamingDictionariesApiClient wargamingDictionariesApiClient, IDictionariesDataAccessor dataAccessor, IMapper mapper)
        {
            _wargamingDictionariesApiClient = wargamingDictionariesApiClient;
            _dataAccessor = dataAccessor;
            _mapper = mapper;
        }

        public virtual async Task<UpdateDictionariesResponseItem> Update()
        {
            var achievementDictionary = await GetAndMapAchievementsDictionary();

           await _dataAccessor.UpdateAchievements(achievementDictionary);

            return new UpdateDictionariesResponseItem
            {
                DictionaryType = DictionaryType.Achievements,
                Description = $"Got and saved {achievementDictionary.Count} achievement dictionary items"
            };
        }

        private async Task<List<IAchievementDictionary>> GetAndMapAchievementsDictionary()
        {
            var defaultRealmType = RealmType.Eu;

            var achievements = new List<IAchievementDictionary>();

            foreach (var requestLanguage in (RequestLanguage[])Enum.GetValues(typeof(RequestLanguage)))
            {
                var wgAchievements =
                    await _wargamingDictionariesApiClient.GetAchievementsDictionary(defaultRealmType, requestLanguage);
                foreach (var wgAchievement in wgAchievements)
                {
                    var mappedAchievement =
                        achievements.FirstOrDefault(a => a.AchievementId == wgAchievement.AchievementId);
                    if (mappedAchievement == null)
                    {
                        mappedAchievement =
                            _mapper.Map<WotEncyclopediaAchievementsResponse, AchievementDictionary>(wgAchievement);
                        achievements.Add(mappedAchievement);
                    }
                    mappedAchievement.Name.Add(new LocalizableString { Language = requestLanguage, Value = wgAchievement.Name });
                    mappedAchievement.Condition.Add(new LocalizableString { Language = requestLanguage, Value = wgAchievement.Condition });
                    mappedAchievement.Description.Add(new LocalizableString { Language = requestLanguage, Value = wgAchievement.Description });
                    mappedAchievement.HeroInfo.Add(new LocalizableString { Language = requestLanguage, Value = wgAchievement.HeroInfo });

                    if (wgAchievement.Options != null)
                    {
                        if (mappedAchievement.Options == null)
                        {
                            mappedAchievement.Options = new List<AchievementOption>();
                        }

                        foreach (var wgAchievementOption in wgAchievement.Options)
                        {
                            // image is the only unique identifier
                            var mappedOption =
                                mappedAchievement.Options.FirstOrDefault(o => o.Image == wgAchievementOption.Image);
                            if (mappedOption == null)
                            {
                                mappedOption =
                                    _mapper.Map<WotEncyclopediaAchievementsOptions, AchievementOption>(
                                        wgAchievementOption);
                                mappedAchievement.Options.Add(mappedOption);
                            }
                            mappedOption.Name.Add(new LocalizableString { Language = requestLanguage, Value = wgAchievement.Name });
                            mappedOption.Description.Add(new LocalizableString { Language = requestLanguage, Value = wgAchievement.Description });
                        }
                    }
                }
            }

            return achievements;
        }
    }
}