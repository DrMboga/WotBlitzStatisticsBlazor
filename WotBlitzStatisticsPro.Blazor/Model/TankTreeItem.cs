using System;
using System.Collections.Generic;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Model
{
    public class TankTreeItem
    {
        public long TankId { get; set; }

        public int Tier { get; set; }

        public int Row { get; set; }

        public string TankTypeId { get; set; }

        public bool IsPremium { get; set; }

        public bool IsResearched { get; set; }

        public string PreviewImage { get; set; }

        public string Name { get; set; }

        public MarkOfMastery? MarkOfMastery { get; set; }

        public decimal? WinRate { get; set; }

        public decimal? AvgDamage { get; set; }

        public long? Battles { get; set; }

        public DateTimeOffset? LastBattleTime { get; set; }

        public Decimal PriceCredit { get; set; }

        public List<TankTreeRowMap>? NextRows { get; set; }
        
    }
}