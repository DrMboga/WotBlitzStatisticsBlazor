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
    public class StaticDictionariesUpdater : IDictionaryUpdater
    {
        private readonly IWargamingDictionariesApiClient _wargamingDictionariesApiClient;
        private readonly IDictionariesDataAccessor _dataAccessor;
        private readonly IMapper _mapper;

        [Obsolete("Parameter-less constructor only for unit tests")]
        public StaticDictionariesUpdater()
        {
            
        }

        public StaticDictionariesUpdater(
            IWargamingDictionariesApiClient wargamingDictionariesApiClient,
            IDictionariesDataAccessor dataAccessor,
            IMapper mapper)
        {
            _wargamingDictionariesApiClient = wargamingDictionariesApiClient;
            _dataAccessor = dataAccessor;
            _mapper = mapper;
        }
        public virtual async Task<UpdateDictionariesResponseItem> Update()
        {
            var (
                languages,
                nations,
                vehicleTypes,
                clanRoles,
                achievementsSections) = await GetAndMapDictionaries();

            await _dataAccessor.UpdateLanguages(languages);
            await _dataAccessor.UpdateNations(nations);
            await _dataAccessor.UpdateVehicleTypes(vehicleTypes);
            await _dataAccessor.UpdateClanRoles(clanRoles);
            await _dataAccessor.UpdateAchievementsSections(achievementsSections);

            return new UpdateDictionariesResponseItem
            {
                DictionaryType = DictionaryType.StaticDictionaries,
                Description =
                    $"Updated {languages.Count} items in Languages dictionary; {nations.Count} items in Nations dictionary; {vehicleTypes.Count} items in VehicleTypes dictionary; {clanRoles.Count} items in ClanRoles dictionary; {achievementsSections.Count} items in AchievementsSections dictionary"
            };
        }

        private async Task<(
            List<ILanguageDictionary>,
            List<INationDictionary>,
            List<IVehicleTypeDictionary>,
            List<IClanRoleDictionary>,
            List<IAchievementSectionDictionary>)> GetAndMapDictionaries()
        {
            var defaultRealmType = RealmType.Eu;

            List<ILanguageDictionary> languages = null;
            var nations = new List<INationDictionary>();
            var vehicleTypes = new List<IVehicleTypeDictionary>();
            var clanRoles = new List<IClanRoleDictionary>();
            var achievementsSections = new List<IAchievementSectionDictionary>();

            foreach (var requestLanguage in (RequestLanguage[])Enum.GetValues(typeof(RequestLanguage)))
            {
                var (wotEncyclopediaInfoResponse, wotClanMembersDictionaryResponse) =
                    await _wargamingDictionariesApiClient.GetStaticDictionariesAsync(defaultRealmType, requestLanguage);

                if (languages == null)
                {
                    languages =
                        _mapper.Map<Dictionary<string, string>, List<LanguageDictionary>>(wotEncyclopediaInfoResponse
                            .Languages).Cast<ILanguageDictionary>().ToList();
                }

                MapVehicleNations(requestLanguage, wotEncyclopediaInfoResponse.VehicleNations, nations);
                MapVehicleTypes(requestLanguage, wotEncyclopediaInfoResponse.VehicleTypes, vehicleTypes);
                MapClanRoles(requestLanguage, wotClanMembersDictionaryResponse.ClanRoles, clanRoles);
                MapAchievementsSections(requestLanguage, wotEncyclopediaInfoResponse.AchievementSections, achievementsSections);
            }

            return (languages, nations, vehicleTypes, clanRoles, achievementsSections);
        }

        private void MapVehicleNations(
            RequestLanguage requestLanguage,
            Dictionary<string, string> sourceDictionary,
            List<INationDictionary> destinationDictionary)
        {
            foreach (var source in sourceDictionary)
            {
                var destinationItem = destinationDictionary.FirstOrDefault(d => d.NationId == source.Key);
                if (destinationItem == null)
                {
                    destinationItem = new NationDictionary
                    {
                        NationId = source.Key, NationNames = new List<LocalizableString>()
                    };
                    destinationDictionary.Add(destinationItem);
                }

                destinationItem.NationNames.Add(
                    new LocalizableString {Language = requestLanguage, Value = source.Value});
            }
        }

        private void MapVehicleTypes(
            RequestLanguage requestLanguage,
            Dictionary<string, string> sourceDictionary,
            List<IVehicleTypeDictionary> destinationDictionary)
        {
            foreach (var source in sourceDictionary)
            {
                var destinationItem = destinationDictionary.FirstOrDefault(d => d.VehicleTypeId == source.Key);
                if (destinationItem == null)
                {
                    destinationItem = new VehicleTypeDictionary
                    {
                        VehicleTypeId = source.Key, VehicleTypeNames = new List<LocalizableString>()
                    };
                    destinationDictionary.Add(destinationItem);
                }

                destinationItem.VehicleTypeNames.Add(
                    new LocalizableString { Language = requestLanguage, Value = source.Value });
            }
        }

        private void MapClanRoles(
            RequestLanguage requestLanguage,
            Dictionary<string, string> sourceDictionary,
            List<IClanRoleDictionary> destinationDictionary)
        {
            foreach (var source in sourceDictionary)
            {
                var destinationItem = destinationDictionary.FirstOrDefault(d => d.ClanRoleId == source.Key);
                if (destinationItem == null)
                {
                    destinationItem = new ClanRoleDictionary
                    {
                        ClanRoleId = source.Key, ClanRoleNames = new List<LocalizableString>()
                    };
                    destinationDictionary.Add(destinationItem);
                }

                destinationItem.ClanRoleNames.Add(
                    new LocalizableString { Language = requestLanguage, Value = source.Value });
            }
        }

        private void MapAchievementsSections(
            RequestLanguage requestLanguage,
            Dictionary<string, WotEncyclopediaInfoAchievementSection> sourceSections,
            List<IAchievementSectionDictionary> destinationDictionary)
        {
            foreach (var section in sourceSections)
            {
                var destinationItem = 
                    destinationDictionary.FirstOrDefault(d => d.AchievementSectionId == section.Key);
                if (destinationItem == null)
                {
                    destinationItem = new AchievementSectionDictionary
                    {
                        AchievementSectionId = section.Key,
                        Order = Convert.ToInt32(section.Value.Order),
                        AchievementSectionNames = new List<LocalizableString>()
                    };
                    destinationDictionary.Add(destinationItem);
                }

                destinationItem.AchievementSectionNames.Add(
                    new LocalizableString { Language = requestLanguage, Value = section.Value.Name });
            }
        }
    }
}