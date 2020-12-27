using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class AchievementDictionary : IAchievementDictionary
    {
        [BsonId] public string AchievementId { get; set; } = string.Empty;
        public List<LocalizableString> Condition { get; set; } = Enumerable.Empty<LocalizableString>().ToList();
        public List<LocalizableString> Description { get; set; } = Enumerable.Empty<LocalizableString>().ToList();
        public List<LocalizableString> HeroInfo { get; set; } = Enumerable.Empty<LocalizableString>().ToList();
        public string Image { get; set; } = string.Empty;
        public string ImageBig { get; set; } = string.Empty;
        public List<LocalizableString> Name { get; set; } = Enumerable.Empty<LocalizableString>().ToList();
        public long? Order { get; set; }
        public bool Outdated { get; set; }
        public string SectionId { get; set; } = string.Empty;
        public long? SectionOrder { get; set; }
        public string Type { get; set; } = string.Empty;
        public List<AchievementOption> Options { get; set; } = Enumerable.Empty<AchievementOption>().ToList();
    }
}