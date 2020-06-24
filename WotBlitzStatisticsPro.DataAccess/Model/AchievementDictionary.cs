using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using WotBlitzStatisticsPro.Common.Dictionaries;

namespace WotBlitzStatisticsPro.DataAccess.Model
{
    public class AchievementDictionary : IAchievementDictionary
    {
        [BsonId]
        public string AchievementId { get; set; }
        public List<LocalizableString> Condition { get; set; }
        public List<LocalizableString> Description { get; set; }
        public List<LocalizableString> HeroInfo { get; set; }
        public string Image { get; set; }
        public string ImageBig { get; set; }
        public List<LocalizableString> Name { get; set; }
        public long? Order { get; set; }
        public bool Outdated { get; set; }
        public string SectionId { get; set; }
        public long? SectionOrder { get; set; }
        public string Type { get; set; }
        public List<AchievementOption> Options { get; set; }
    }
}