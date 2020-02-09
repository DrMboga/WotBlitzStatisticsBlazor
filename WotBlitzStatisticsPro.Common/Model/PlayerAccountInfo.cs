using System;
using System.Collections.Generic;

namespace WotBlitzStatisticsPro.Common.Model
{
	public class PlayerAccountInfo
	{
		public long AccountId { get; set; }
		public string NickName { get; set; }
		public DateTime? AccountCreatedAt { get; set; }
		public DateTime? LastBattleTime { get; set; }
		public long Battles { get; set; }
		public double Wn7 { get; set; }
		public double AvgTier { get; set; }
		public double Winrate { get; set; }
		public double AvgDamage { get; set; }
		public double AvgXp { get; set; }
		public IEnumerable<PlayerAchievementInfo> Achievements { get; set; }
		public IEnumerable<PlayerTankInfo> TopTanks { get; set; }
	}
}
