using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.Common.Dictionaries;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.DataAccess;
using WotBlitzStatisticsPro.Logic.Dictionaries;

namespace WotBlitzStatisticsPro.Logic
{
    public class WargamingDictionaries: IWargamingDictionaries
    {
        private readonly DictionariesUpdaterResolver _dictionaryUpdaterFactoryMethod;
        private readonly IDictionariesDataAccessor _dictionariesDataAccessor;
        private readonly IMapper _mapper;
        private readonly ILogger<WargamingDictionaries> _logger;

        public WargamingDictionaries(
            DictionariesUpdaterResolver dictionaryUpdaterFactoryMethod,
            IDictionariesDataAccessor dictionariesDataAccessor,
            ILogger<WargamingDictionaries> logger,
            IMapper mapper)
        {
            _dictionaryUpdaterFactoryMethod = dictionaryUpdaterFactoryMethod;
            _dictionariesDataAccessor = dictionariesDataAccessor;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<VehicleResponse>?> GetVehiclesByNation(string nationId, RequestLanguage? language)
        {
            language = language ?? RequestLanguage.En;
            var vehicles = await _dictionariesDataAccessor.GetVehiclesByNation(nationId);
            return _mapper.Map<List<IVehiclesDictionary>, List<VehicleResponse>>(vehicles, opts => 
            {
                opts.Items["language"] = language;
            });
        }

        public async Task<UpdateDictionariesResponseItem[]> UpdateDictionaries(UpdateDictionariesRequest updateDictionariesRequest)
        {
            var response = new List<UpdateDictionariesResponseItem>();

            try
            {
                foreach (var dictionaryType in (DictionaryType[]) Enum.GetValues(typeof(DictionaryType)))
                {
                    if ((updateDictionariesRequest.DictionaryTypes & dictionaryType) != 0)
                    {
                        var dictionaryUpdater = _dictionaryUpdaterFactoryMethod(dictionaryType);
                        if (dictionaryUpdater != null)
                        {
                            response.Add(await dictionaryUpdater.Update());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "UpdateDictionaries error");
                throw;
            }

            return response.ToArray();
        }
    }
}