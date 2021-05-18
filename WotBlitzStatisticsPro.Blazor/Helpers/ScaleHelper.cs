namespace WotBlitzStatisticsPro.Blazor.Helpers
{
    public static class ScaleHelper
    {
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
    }
}