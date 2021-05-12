using System;

namespace WotBlitzStatisticsPro.Blazor.Model
{
    [Obsolete("This is temporary item. In the future there should be two new data models with 'clan, winrate and battles' for player, and 'name, tag members count' for clan")]
    public record SearchItem(long ItemId, string ItemName);

}