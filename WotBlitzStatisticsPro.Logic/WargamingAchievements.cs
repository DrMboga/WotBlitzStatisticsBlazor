using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Common.Model.Achievements;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.DataAccess.Model;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic
{
    public class WargamingAchievements: IWargamingAchievements
    {
        private readonly IDictionariesDataAccessor _dictionariesDataAccessor;
        private readonly IWargamingAchievementsApiClient _wargamingAchievementsService;
        private readonly IMapper _mapper;
        private readonly ILogger<WargamingAchievements> _logger;

        public WargamingAchievements(
            IDictionariesDataAccessor dictionariesDataAccessor,
            IWargamingAchievementsApiClient wargamingAchievementsService,
            IMapper mapper,
            ILogger<WargamingAchievements> logger)
        {
            _dictionariesDataAccessor = dictionariesDataAccessor;
            _wargamingAchievementsService = wargamingAchievementsService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AccountAchievementsResponse> GetAccountAchievements(RealmType realm, long accountId, RequestLanguage requestLanguage)
        {
            try
            {
                // Get account achievements from WG API
                var wgAchievements =
                    await _wargamingAchievementsService.GetAccountAchievements(accountId, realm, requestLanguage);

                return await FillAchievements(accountId, wgAchievements, requestLanguage);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GetAccountAchievements error");

                throw;
            }
        }

        public async Task<AccountAchievementsResponse> GetTankAchievements(RealmType realm, long accountId, long tankId, RequestLanguage requestLanguage)
        {
            try
            {
                // Get account achievements from WG API
                var wgAchievements =
                    await _wargamingAchievementsService.GetTankAchievements(accountId, tankId, realm, requestLanguage);

                return await FillAchievements(accountId, wgAchievements, requestLanguage);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GetTankAchievements error");

                throw;
            }
        }

        private async Task<AccountAchievementsResponse> FillAchievements(long accountId, WotAccountAchievementResponse? wgAchievements,
            RequestLanguage requestLanguage)
        {
            // Read achievement sections from DB
            var sectionsDictionary = await _dictionariesDataAccessor.GetAchievementSections();
            var sections =
                _mapper.Map<List<AchievementSectionDictionary>, List<AchievementSection>>(sectionsDictionary,
                    context => context.Items["language"] = requestLanguage);

            var response = new AccountAchievementsResponse
            {
                AccountId = accountId,
                Sections = sections
            };

            if (wgAchievements?.Achievements == null)
            {
                return response;
            }

            // Map ID And value
            var achievements = _mapper.Map<Dictionary<string, int>, List<Achievement>>(wgAchievements.Achievements);

            // Add Max series
            if (wgAchievements.MaxSeries != null)
            {
                foreach (var achievementsMaxSeries in wgAchievements.MaxSeries)
                {
                    if (achievementsMaxSeries.Value == 0)
                    {
                        continue;
                    }
                    var existing = achievements.FirstOrDefault(a => a.Id == achievementsMaxSeries.Key);
                    if (existing == null)
                    {
                        achievements.Add(new Achievement
                        { Id = achievementsMaxSeries.Key, MaxSeriesValue = achievementsMaxSeries.Value });
                    }
                    else
                    {
                        existing.MaxSeriesValue = achievementsMaxSeries.Value;
                    }
                }
            }

            // Read achievements dictionaries from DB
            var achievementDictionaries =
                await _dictionariesDataAccessor.GetAchievements(achievements.Select(a => a.Id).ToArray());

            // Map achievements dictionaries
            foreach (var achievement in achievements)
            {
                _mapper.Map(achievementDictionaries[achievement.Id], achievement,
                    context => context.Items["language"] = requestLanguage);

                // Map achievement option if exists
                if (achievementDictionaries[achievement.Id].Options.Count > 0)
                {
                    if (achievement.AchievementValue < achievementDictionaries[achievement.Id].Options.Count)
                    {
                        achievement.Image = achievementDictionaries[achievement.Id]
                            .Options[achievement.AchievementValue - 1].Image;
                        achievement.ImageBig = achievementDictionaries[achievement.Id]
                            .Options[achievement.AchievementValue - 1].ImageBig;
                    }
                }
            }

            // Sort achievements by sections
            foreach (var section in response.Sections)
            {
                section.Medals = achievements.Where(a => a.SectionId == section.SectionId).ToList();
            }

            return response;
        }
    }
}