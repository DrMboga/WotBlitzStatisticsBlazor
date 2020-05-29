using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic.Dictionaries
{
    public interface IDictionaryUpdater
    {
        Task<UpdateDictionariesResponseItem> Update();
    }
}