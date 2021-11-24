using System.Collections.Generic;
using System.Linq;
using System.Text;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Helpers
{
    public static class TanksHelper
    {
        public static ITank FindMostRelevantTank(this IReadOnlyList<ITank> allTanks)
        {
            const int topTanksToMerge = 6;
            if (allTanks.Count == 1)
            {
                return allTanks.First();
            }

            // Merge 6 tanks with max battles with 6 tanks with max Wn7, then with 6 tanks with max AvgDamage then with 6 tanks with Max Win rate. And sort result by max AvgXp and take first
            
            var topByBattles = allTanks
                .OrderByDescending(t => t.Battles)
                .Take(topTanksToMerge)
                .Select(t => t.TankId)
                .ToList();
            var topByWn7 = allTanks
                .Where(t => topByBattles.Contains(t.TankId))
                .OrderByDescending(t => t.Wn7)
                .Take(topTanksToMerge)
                .Select(t => t.TankId)
                .ToList();
            var topByDamage = allTanks
                .Where(t => topByBattles.Contains(t.TankId))
                .OrderByDescending(t => t.AvgDamage)
                .Take(topTanksToMerge)
                .Select(t => t.TankId)
                .ToList();
            var topByWinRate = allTanks
                .Where(t => topByBattles.Contains(t.TankId))
                .OrderByDescending(t => t.WinRate)
                .Take(topTanksToMerge)
                .Select(t => t.TankId)
                .ToList();

            var firstIntersection = topByBattles.Intersect(topByWn7).ToList();
            if (!firstIntersection.Any())
            {
                return allTanks.First(t => t.TankId == topByBattles.First());
            }
            if(firstIntersection.Count() == 1)
            {
                return allTanks.First(t => t.TankId == firstIntersection.First());
            }

            var secondIntersection = topByDamage.Intersect(firstIntersection).ToList();
            if (!secondIntersection.Any())
            {
                return allTanks.First(t => t.TankId == firstIntersection.First());
            }
            if (secondIntersection.Count() == 1)
            {
                return allTanks.First(t => t.TankId == secondIntersection.First());
            }

            var thirdIntersection = topByWinRate.Intersect(secondIntersection).ToList();
            if (!thirdIntersection.Any())
            {
                return allTanks.First(t => t.TankId == secondIntersection.First());
            }
            if (thirdIntersection.Count() == 1)
            {
                return allTanks.First(t => t.TankId == thirdIntersection.First());
            }

            return allTanks
                .Where(t => thirdIntersection.Contains(t.TankId))
                .OrderByDescending(t => t.AvgXp)
                .First();
        }

    }
}