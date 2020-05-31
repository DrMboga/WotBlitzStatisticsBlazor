using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.Logic.Dictionaries;

namespace WotBlitzStatisticsPro.Logic
{
    public class WargamingDictionaries: IWargamingDictionaries
    {
        private readonly DictionariesUpdaterResolver _dictionaryUpdaterFactoryMethod;

        public WargamingDictionaries(DictionariesUpdaterResolver dictionaryUpdaterFactoryMethod)
        {
            _dictionaryUpdaterFactoryMethod = dictionaryUpdaterFactoryMethod;
        }
        
        public async Task<UpdateDictionariesResponseItem[]> UpdateDictionaries(UpdateDictionariesRequest updateDictionariesRequest)
        {
            var response = new List<UpdateDictionariesResponseItem>();

            foreach (var dictionaryType in (DictionaryType[])Enum.GetValues(typeof(DictionaryType)))
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

            return response.ToArray();
        }
    }
}