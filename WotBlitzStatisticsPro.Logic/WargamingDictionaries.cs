using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic.Dictionaries;

namespace WotBlitzStatisticsPro.Logic
{
    public class WargamingDictionaries: IWargamingDictionaries
    {
        private readonly DictionariesUpdaterResolver _dictionaryUpdaterFactoryMethod;
        private readonly ILogger<WargamingDictionaries> _logger;

        public WargamingDictionaries(DictionariesUpdaterResolver dictionaryUpdaterFactoryMethod, ILogger<WargamingDictionaries> logger)
        {
            _dictionaryUpdaterFactoryMethod = dictionaryUpdaterFactoryMethod;
            _logger = logger;
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