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
    public class VehiclesDictionaryUpdater : IDictionaryUpdater
    {
        private readonly IWargamingDictionariesApiClient _wargamingDictionariesApiClient;
        private readonly IDictionariesDataAccessor _dataAccessor;
        private readonly IMapper _mapper;

        [Obsolete("Parameter-less constructor only for unit tests")]
        public VehiclesDictionaryUpdater()
        {
            _wargamingDictionariesApiClient = null!;
            _dataAccessor = null!;
            _mapper = null!;
        }

        public VehiclesDictionaryUpdater(IWargamingDictionariesApiClient wargamingDictionariesApiClient,
            IDictionariesDataAccessor dataAccessor, IMapper mapper)
        {
            _wargamingDictionariesApiClient = wargamingDictionariesApiClient;
            _dataAccessor = dataAccessor;
            _mapper = mapper;
        }

        public virtual async Task<UpdateDictionariesResponseItem> Update()
        {
            var vehiclesDictionary = await GetAndMapVehiclesDictionary();

            await _dataAccessor.UpdateVehicles(vehiclesDictionary);

            return new UpdateDictionariesResponseItem
            {
                DictionaryType = DictionaryType.Vehicles,
                Description = $"Got and saved {vehiclesDictionary.Count} vehicles dictionary items"
            };

        }

        private async Task<List<IVehiclesDictionary>> GetAndMapVehiclesDictionary()
        {
            var defaultRealmType = RealmType.Eu;

            var vehicles = new List<IVehiclesDictionary>();

            foreach (var requestLanguage in (RequestLanguage[]) Enum.GetValues(typeof(RequestLanguage)))
            {
                var wgVehicles =
                    await _wargamingDictionariesApiClient.GetVehicles(defaultRealmType, requestLanguage);

                if (wgVehicles == null)
                {
                    continue;
                }

                foreach (var wgVehicle in wgVehicles)
                {
                    var mappedVehicle = vehicles.FirstOrDefault(v => v.TankId == wgVehicle.TankId);
                    if (mappedVehicle == null)
                    {
                        mappedVehicle = _mapper.Map<WotEncyclopediaVehiclesResponse, VehiclesDictionary>(wgVehicle);
                        vehicles.Add(mappedVehicle);
                    }
                    mappedVehicle.Name.Add(new LocalizableString {Language = requestLanguage, Value = wgVehicle.Name});
                    mappedVehicle.Description.Add(new LocalizableString {Language = requestLanguage, Value = wgVehicle.Description});
                }

            }

            return vehicles;
        }

    }
}