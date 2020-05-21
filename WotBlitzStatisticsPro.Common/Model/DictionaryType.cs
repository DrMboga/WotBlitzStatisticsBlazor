using System;

namespace WotBlitzStatisticsPro.Common.Model
{
    /// <summary>
    /// List of dictionaries
    /// </summary>
    [Flags]
    public enum DictionaryType
    {
        /// <summary>
        /// Static dictionaries - Languages, VehicleNations, VehicleTypes, AchievementSections, ClanRoles
        /// </summary>
        StaticDictionaries = 1,
        /// <summary>
        /// Achievements
        /// </summary>
        Achievements = 2,
        /// <summary>
        /// Vehicles encyclopedia
        /// </summary>
        Vehicles = 4,
        /// <summary>
        /// Only vehicles and Achievements
        /// </summary>
        AchievementsAndVehicles = Achievements | Vehicles,
        /// <summary>
        /// All dictionaries
        /// </summary>
        All = StaticDictionaries | Achievements | Vehicles
    }
}