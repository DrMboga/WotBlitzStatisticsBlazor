using System.Collections.Generic;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.Logic.Calculations
{
    public static class TierHelper
    {
		public static void CalculateMiddleTier(this AccountInfoHistory account, IList<TankInfoHistory> allTanks, Dictionary<long, int> tankTires)
        {
            double x = 0d;
            if (!account.Battles.HasValue)
            {
                return;
            }
            foreach (var tank in allTanks)
            {
                if (tankTires.ContainsKey(tank.TankId) && tank.Battles > 0)
                {
                    x += tankTires[tank.TankId] * tank.Battles.DoubleValue();
                }
            }
            if (account.Battles > 0)
                x /= account.Battles.Value;
            account.AvgTier = x;
        }

	}
}