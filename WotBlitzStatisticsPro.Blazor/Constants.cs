using WotBlitzStatisticsPro.Blazor.Model;

namespace WotBlitzStatisticsPro.Blazor
{
    public static class Constants
    {
        public const string ClanTagColor = "#d4d481";


        //public const string ScaleVeryBadColor = "#000000";
        //public const string ScaleBadColor = "#cd3333";
        //public const string ScaleBelowAverageColor = "#d77900";
        //public const string ScaleAverageColor = "#d7b600";
        //public const string ScaleGoodColor = "#6d9521";
        //public const string ScaleVeryGoodColor = "#4c762e";
        //public const string ScaleGreatColor = "#4a92b7";
        //public const string ScaleUnicumColor = "#83579d";
        //public const string ScaleSuperUnicumColor = "#5a3175";
        public const string ScaleVeryBadColor = "#a3a3a3";
        public const string ScaleBadColor = "#dc7070";
        public const string ScaleBelowAverageColor = "#ff9f25";
        public const string ScaleAverageColor = "#ffdd25";
        public const string ScaleGoodColor = "#9ad131";
        public const string ScaleVeryGoodColor = "#6fad43";
        public const string ScaleGreatColor = "#81b3cd";
        public const string ScaleUnicumColor = "#a785bb";
        public const string ScaleSuperUnicumColor = "#8348ab";

        public const string HeavyTank = "heavyTank";
        public const string AtSpg = "AT-SPG";
        public const string MediumTank = "mediumTank";
        public const string LightTank = "lightTank";

        public const string CountryUsa = "usa";
        public const string CountryFrance = "france";
        public const string CountryUssr = "ussr";
        public const string CountryChina = "china";
        public const string CountryUk = "uk";
        public const string CountryJapan = "japan";
        public const string CountryGermany = "germany";
        public const string CountryOther = "other";
        public const string CountryEuropean = "european";


        public const string LoginInfoLocalStorageKey = "login_info";

        public static TankTreeRowMap[] TanksTreeHelper = new TankTreeRowMap[]
        {
            new TankTreeRowMap(2065,2)
        };
    }
}