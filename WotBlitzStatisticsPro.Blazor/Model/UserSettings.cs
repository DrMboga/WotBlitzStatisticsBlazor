using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Model
{
    public class UserSettings
    {
        public const string UserSettingsLocalStorageKey = "user-settings";

        public string Culture { get; set; } = "en-US";

        public RealmType RealmType { get; set; } = RealmType.Eu;
    }
}