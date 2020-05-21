using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatistics.Logic
{
    public class WargamingDictionaries: IWargamingDictionaries
    {
        public Task<UpdateDictionariesResponseItem[]> UpdateDictionaries(UpdateDictionariesRequest updateDictionariesRequest)
        {
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
            throw new System.NotImplementedException();
        }
    }
}