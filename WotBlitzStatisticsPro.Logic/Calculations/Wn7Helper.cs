using System;
using WotBlitzStatisticsPro.DataAccess.Model.Accounts;

namespace WotBlitzStatisticsPro.Logic.Calculations
{
    public static class Wn7Helper
    {
		public static double CalculateWn7(
            long battles, 
            double tier, 
            double avdFrags, 
            double avgDamage,
	        double avgSpot, 
            double avgDef, 
            double winRate)
		{
			double firstSummation = CalculateFirstSummation(tier, avdFrags);
			double secondSummation = CalculateSecondSummation(tier, avgDamage);
			double thirdSummation = CalculateThirdSummation(tier, avgSpot);
			double fourthSummation = CalculateFourthSummation(avgDef);
			double fifthSummation = CalculateFifthSummation(winRate);
			double sixthSummation = CalculateSixthSummation(tier, battles);

			return firstSummation + secondSummation + thirdSummation + fourthSummation + fifthSummation + sixthSummation;
		}

		public static void CalculateWn7(this TankInfoHistory tank, double tier)
		{
            if (!tank.Battles.HasValue)
            {
				return;
            }
			double avdFrags = tank.Frags.DoubleValue() / tank.Battles.DoubleValue();
            double avgDamage = tank.DamageDealt.DoubleValue() / tank.Battles.DoubleValue();
            double avgSpot = tank.Spotted.DoubleValue() / tank.Battles.DoubleValue();
            double avgDef = tank.DroppedCapturePoints.DoubleValue() / tank.Battles.DoubleValue();
            double winRate = (100d * tank.Wins.DoubleValue() / tank.Battles.DoubleValue()); // - 48;

			tank.Wn7 = CalculateWn7(tank.Battles.Value, tier, avdFrags, avgDamage, avgSpot, avgDef, winRate);
		}

		public static void CalculateWn7(this AccountInfoHistory account)
		{
            if (!account.Battles.HasValue)
            {
                return;
            }

			double avdFrags = account.Frags.DoubleValue() / account.Battles.DoubleValue();
            double avgDamage = account.DamageDealt.DoubleValue() / account.Battles.DoubleValue();
            double avgSpot = account.Spotted.DoubleValue() / account.Battles.DoubleValue();
            double avgDef = account.DroppedCapturePoints.DoubleValue() / account.Battles.DoubleValue();
            double winRate = (100 * account.Wins.DoubleValue() / account.Battles.DoubleValue()); // - 48;

			account.Wn7 = CalculateWn7(account.Battles.Value, account.AvgTier, avdFrags, avgDamage, avgSpot, avgDef, winRate);
		}


		//(1240-1040/(min(TIER,6)^0.164))*FRAGS
		private static double CalculateFirstSummation(double tier, double frags)
		{
			double x = Math.Min(tier, 6);
			x = Math.Pow(x, 0.164d);
			x = 1040d / x;
			x = 1240d - x;
			return x * frags;
		}

		//DAMAGE * 530/(184*exp(0.24*TIER)+130)
		private static double CalculateSecondSummation(double tier, double damage)
		{
			double x = 184d * Math.Exp(0.24d * tier) + 130d;
			return damage * 530d / x;
		}

		//SPOT * 125*min(TIER,3)/3
		private static double CalculateThirdSummation(double tier, double spot)
		{
			return spot * 125d * Math.Min(tier, 3d) / 3;
		}

		//min(DEF,2.2)*100
		private static double CalculateFourthSummation(double def)
		{
			return Math.Min(def, 2.2d) * 100;
		}

		//((185/(0.17+exp(((WINRATE)-35)*-0.134)))-500)*0.45
		private static double CalculateFifthSummation(double winRate)
		{
			double x = (winRate - 35d) * -0.134;
			x = Math.Exp(x) + 0.17d;
			return (185d / x - 500d) * 0.45d;
		}

		//(-1*(((5 - min(TIER,5))*125)/(1 + exp((TIER-(TOTAL/220^(3/TIER)))*1.5))))
		private static double CalculateSixthSummation(double tier, double total)
		{
			double x = -125d * (5d - Math.Min(tier, 5d));
			double y = total / Math.Pow(220d, 3d / tier);
			y = 1.5d * (tier - y);
			y = Math.Exp(y) + 1d;
			return x / y;
		}

		public static double DoubleValue(this long? val)
		{
			if (!val.HasValue)
				return 0d;
			return (double)val.Value;
		}

	}
}