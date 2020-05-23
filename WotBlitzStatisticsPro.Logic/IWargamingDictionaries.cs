using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic
{
    public interface IWargamingDictionaries
    {
        Task<UpdateDictionariesResponseItem[]> UpdateDictionaries(
            UpdateDictionariesRequest updateDictionariesRequest);
    }
}