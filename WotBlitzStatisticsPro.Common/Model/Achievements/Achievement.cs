namespace WotBlitzStatisticsPro.Common.Model.Achievements
{
    /// <summary>
    /// Player's achievement information
    /// </summary>
    public class Achievement
    {
        /// <summary>
        /// Achievement Id
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Achievement value
        /// </summary>
        public int AchievementValue { get; set; }

        /// <summary>
        /// Achievement max series value
        /// </summary>
        public int? MaxSeriesValue { get; set; }

        /// <summary>
        /// Achievement condition
        /// </summary>
        public string? Condition { get; set; }

        /// <summary>
        /// Achievement description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Achievement normal sized image
        /// </summary>
        public string? Image { get; set; }

        /// <summary>
        /// Achievement big image
        /// </summary>
        public string? ImageBig { get; set; }

        /// <summary>
        /// Achievement name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Order
        /// </summary>
        public long? Order { get; set; }

        /// <summary>
        /// Section Id
        /// </summary>
        public string SectionId { get; set; } = string.Empty;

        /// <summary>
        /// Achievement type
        /// </summary>
        public string? MedalType { get; set; }

    }
}