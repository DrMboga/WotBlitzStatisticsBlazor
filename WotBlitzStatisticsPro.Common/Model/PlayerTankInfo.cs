namespace WotBlitzStatisticsPro.Common.Model
{
	public class PlayerTankInfo
	{
		public long TankId { get; set; }
		public MarkOfMastery MarkOfMastery { get; set; }
		public long Battles { get; set; }
		public decimal WinRate { get; set; }
		public decimal AvgDamage { get; set; }
		public decimal AvgXp { get; set; }
		public string Name { get; set; }
		public int Tier { get; set; }
		public string TierRoman { get; set; }
		public string Nation { get; set; }
		public string Type { get; set; }
		public bool IsPremium { get; set; }
		public string PreviewImageUrl { get; set; }
	}
}
