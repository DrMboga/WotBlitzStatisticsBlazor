using System.Collections.Generic;
using Newtonsoft.Json;
using WotBlitzStatisticsPro.Common.Model;

namespace WotBlitzStatisticsPro.WgApiClient.Model
{
    public class WotAccountTanksStatistics
    {
        ///<summary>
        /// Player account identifier
        ///</summary>
        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("battle_life_time")]
        public int BattleLifeTimeInSeconds { get; set; }

        ///<summary>
        /// Last battle
        ///</summary>
        [JsonProperty("last_battle_time")]
        public int LastBattleTime { get; set; }

        [JsonProperty("in_garage")]
        public bool? InGarage { get; set; }

        [JsonProperty("in_garage_updated")]
        private int? InGarageUpdated { get; set; }

        ///<summary>
        /// Mastery:
        ///
        /// 0 — None
        /// 1 — Rank 3
        /// 2 — Rank 2
        /// 3 — Rank 1
        /// 4 — Mastery
        ///</summary>
        [JsonProperty("mark_of_mastery")]
        private long _markOfMastery { get; set; }
        public MarkOfMastery MarkOfMastery => (MarkOfMastery)_markOfMastery;

        ///<summary>
        /// Tank identifier
        ///</summary>
        [JsonProperty("tank_id")]
        public long TankId { get; set; }

        ///<summary>
        /// Whole statistics
        ///</summary>
        [JsonProperty("all")]
        public WotAccountTanksFullStatistics? All { get; set; }

        [JsonProperty("frags")]
        public Dictionary<string, string>? Frags { get; set; }

	}
}