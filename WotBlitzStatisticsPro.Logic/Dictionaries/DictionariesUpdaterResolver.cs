using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.Logic.Dictionaries
{
    /// <summary>
    /// Dictionaries updater factory method.
    /// </summary>
    /// <param name="dictionaryType">Dictionary type for resolving service.</param>
    /// <returns>Updater service.</returns>
    public delegate IDictionaryUpdater? DictionariesUpdaterResolver(DictionaryType dictionaryType);

}