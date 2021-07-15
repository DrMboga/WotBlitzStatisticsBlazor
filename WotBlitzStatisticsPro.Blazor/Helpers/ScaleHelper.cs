using System;

namespace WotBlitzStatisticsPro.Blazor.Helpers
{
    public static class ScaleHelper
    {
        public static string ScaleColor(this decimal winRate)
        {
            var intWinRate = Convert.ToInt32(winRate);
            return intWinRate.ScaleColor();
        }
        public static string ScaleColor(this int winRate)
        {
            return winRate switch
            {
                ( > 0 ) and ( < 45) => Constants.ScaleVeryBadColor,
                ( >= 45 ) and ( < 47 ) => Constants.ScaleBadColor,
                ( >= 47 ) and ( < 49 ) => Constants.ScaleBelowAverageColor,
                ( >= 49 ) and ( < 52 ) => Constants.ScaleAverageColor,
                ( >= 52 ) and ( < 54 ) => Constants.ScaleGoodColor,
                ( >= 54 ) and ( < 56 ) => Constants.ScaleVeryGoodColor,
                ( >= 56 ) and ( < 60 ) => Constants.ScaleGreatColor,
                ( >= 60 ) and ( < 65 ) => Constants.ScaleUnicumColor,
                _ => Constants.ScaleSuperUnicumColor
            };
        }

        public static string Wn7ScaleColor(this double wn7)
        {
            return wn7 switch
            {
                ( > 0 ) and ( < 500) => Constants.ScaleVeryBadColor,
                ( >= 500) and ( < 700) => Constants.ScaleBadColor,
                ( >= 700) and ( < 900) => Constants.ScaleBelowAverageColor,
                ( >= 900) and ( < 1100) => Constants.ScaleAverageColor,
                ( >= 1100) and ( < 1350) => Constants.ScaleGoodColor,
                ( >= 1350) and ( < 1550) => Constants.ScaleVeryGoodColor,
                ( >= 1550) and ( < 1850) => Constants.ScaleGreatColor,
                ( >= 1850) and ( < 2050) => Constants.ScaleUnicumColor,
                _ => Constants.ScaleSuperUnicumColor
            };
        }


    }
}