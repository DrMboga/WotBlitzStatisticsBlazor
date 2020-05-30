using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient;
using WotBlitzStatisticsPro.WgApiClient.Model;

namespace WotBlitzStatisticsPro.Logic.Dictionaries
{
    public class StaticDictionariesUpdater : IDictionaryUpdater
    {
        private readonly IWargamingDictionariesApiClient _wargamingDictionariesApiClient;
        private readonly IMapper _mapper;

        public StaticDictionariesUpdater(
            IWargamingDictionariesApiClient wargamingDictionariesApiClient,
            IMapper mapper)
        {
            _wargamingDictionariesApiClient = wargamingDictionariesApiClient;
            _mapper = mapper;
        }
        public async Task<UpdateDictionariesResponseItem> Update()
        {
            var (
                languages,
                nations,
                vehicleTypes,
                clanRoles,
                achievementsSections) = await GetAndMapDictionaries();

            // ToDo: Save dictionary to Mongo

            // ToDo: create unit tests

            throw new System.NotImplementedException();
        }

        private async Task<(
            List<LanguageDictionary>,
            List<NationDictionary>,
            List<VehicleTypeDictionary>,
            List<ClanRoleDictionary>,
            List<AchievementSectionDictionary>)> GetAndMapDictionaries()
        {
            var defaultRealmType = RealmType.Eu;

            List<LanguageDictionary> languages = null;
            var nations = new List<NationDictionary>();
            var vehicleTypes = new List<VehicleTypeDictionary>();
            var clanRoles = new List<ClanRoleDictionary>();
            var achievementsSections = new List<AchievementSectionDictionary>();

            foreach (var requestLanguage in (RequestLanguage[])Enum.GetValues(typeof(RequestLanguage)))
            {
                var (wotEncyclopediaInfoResponse, wotClanMembersDictionaryResponse) =
                    await _wargamingDictionariesApiClient.GetStaticDictionariesAsync(defaultRealmType, requestLanguage);

                if (languages == null)
                {
                    languages =
                        _mapper.Map<Dictionary<string, string>, List<LanguageDictionary>>(wotEncyclopediaInfoResponse
                            .Languages);
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
            List<NationDictionary> destinationDictionary)
        {
            foreach (var source in sourceDictionary)
            {
                var destinationItem = destinationDictionary.FirstOrDefault(d => d.NationId == source.Key);
                if (destinationItem == null)
                {
                    destinationItem = new NationDictionary
                    {
                        NationId = source.Key, NationNames = new Dictionary<RequestLanguage, string>()
                    };
                    destinationDictionary.Add(destinationItem);
                }

                destinationItem.NationNames[requestLanguage] = source.Value;
            }
        }

        private void MapVehicleTypes(
            RequestLanguage requestLanguage,
            Dictionary<string, string> sourceDictionary,
            List<VehicleTypeDictionary> destinationDictionary)
        {
            foreach (var source in sourceDictionary)
            {
                var destinationItem = destinationDictionary.FirstOrDefault(d => d.VehicleTypeId == source.Key);
                if (destinationItem == null)
                {
                    destinationItem = new VehicleTypeDictionary
                    {
                        VehicleTypeId = source.Key, VehicleTypeNames = new Dictionary<RequestLanguage, string>()
                    };
                    destinationDictionary.Add(destinationItem);
                }

                destinationItem.VehicleTypeNames[requestLanguage] = source.Value;
            }
        }

        private void MapClanRoles(
            RequestLanguage requestLanguage,
            Dictionary<string, string> sourceDictionary,
            List<ClanRoleDictionary> destinationDictionary)
        {
            foreach (var source in sourceDictionary)
            {
                var destinationItem = destinationDictionary.FirstOrDefault(d => d.ClanRoleId == source.Key);
                if (destinationItem == null)
                {
                    destinationItem = new ClanRoleDictionary
                    {
                        ClanRoleId = source.Key, ClanRoleNames = new Dictionary<RequestLanguage, string>()
                    };
                    destinationDictionary.Add(destinationItem);
                }

                destinationItem.ClanRoleNames[requestLanguage] = source.Value;
            }
        }

        private void MapAchievementsSections(
            RequestLanguage requestLanguage,
            Dictionary<string, WotEncyclopediaInfoAchievementSection> sourceSections,
            List<AchievementSectionDictionary> destinationDictionary)
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
                        AchievementSectionNames = new Dictionary<RequestLanguage, string>()
                    };
                    destinationDictionary.Add(destinationItem);
                }

                destinationItem.AchievementSectionNames[requestLanguage] = section.Value.Name;
            }
        }
    }
}