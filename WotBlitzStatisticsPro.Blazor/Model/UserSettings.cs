namespace WotBlitzStatisticsPro.Blazor.Model
{
    public class UserSettings
    {
        public const string UserSettingsLocalStorageKey = "user-settings";

        public string Culture { get; set; } = "en-US";
    }
}