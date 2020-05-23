using System.Collections.Generic;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatistics.Logic
{
    public class WargamingDictionaries: IWargamingDictionaries
    {
        public Task<UpdateDictionariesResponseItem[]> UpdateDictionaries(UpdateDictionariesRequest updateDictionariesRequest)
        {
            var response = new List<UpdateDictionariesResponseItem>();
            // ToDo: Make factory
            if ((updateDictionariesRequest.DictionaryTypes & DictionaryType.StaticDictionaries) != 0)
            {
                // Update static 
            }
            if ((updateDictionariesRequest.DictionaryTypes & DictionaryType.Achievements) != 0)
            {
                // Update achievements 
            }
            if ((updateDictionariesRequest.DictionaryTypes & DictionaryType.Vehicles) != 0)
            {
                // Update vehicles 
            }

            return Task.FromResult(response.ToArray());
        }
    }
}