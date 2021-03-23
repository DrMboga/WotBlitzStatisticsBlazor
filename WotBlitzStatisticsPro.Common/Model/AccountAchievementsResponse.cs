using System.Collections.Generic;
using WotBlitzStatisticsPro.Common.Model.Achievements;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// Represents information about player's achievements
    /// </summary>
    public class AccountAchievementsResponse
    {
        /// <summary>
        /// Player Id
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        /// Player Achievements by sections
        /// </summary>
        public List<AchievementSection>? AchievementSections { get; set; }
    }
}