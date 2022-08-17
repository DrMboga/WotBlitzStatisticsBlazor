using System;
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

        /*
         * Mongo express filter:
         * {"NationId": "germany", "IsPremium": false, "Tier": 9}
         * Projection:
         * {"Tier" : true,"Name": { $slice: 1 }}
         */
        [Obsolete("Do this as the dictionary in the DB, to make possibility to change it in the future")]
        public static TankTreeRowMap[] TanksTreeHelper = new TankTreeRowMap[]
        {
            // Germany
            new TankTreeRowMap(2065, 2), // First tank in a tree
            new TankTreeRowMap(1809, 1), // Hetzer (4)
            new TankTreeRowMap(17425, 3), // Pz.Kpfw. IV Ausf. D (4)

            new TankTreeRowMap(17, 3), // Pz.Kpfw. IV Ausf. G (5)
            new TankTreeRowMap(5393, 7), // VK 16.02 Leopard (5)

            new TankTreeRowMap(1553, 1), // Jagdpanzer IV (6)
            new TankTreeRowMap(2321, 5), // VK 36.01 (H) (6)
            new TankTreeRowMap(7185, 3), // VK 30.01 (P) 6)
            new TankTreeRowMap(10001, 8), // VK 28.01 (6)
            new TankTreeRowMap(11793, 0), // Nashorn (6)
            new TankTreeRowMap(14097, 6), // VK 30.01 (D) (6)

            new TankTreeRowMap(1297, 6), // Panther I  (7)
            new TankTreeRowMap(3857, 1), // Jagdpanther (7)
            new TankTreeRowMap(4113, 7), // VK 30.02 (D) 7)
            new TankTreeRowMap(11025, 0), // Sturer Emil (7)

            new TankTreeRowMap(5137, 5), // Tiger II (8)
            new TankTreeRowMap(7697, 2), // Ferdinand (8)
            new TankTreeRowMap(8465, 6), // Panther II (8)
            new TankTreeRowMap(10513, 3), // VK 45.02 (P) Ausf. A (8)
            new TankTreeRowMap(11537, 1), // Jagdpanther II (8)
            new TankTreeRowMap(13841, 7), // Indien-Panzer (8)
            new TankTreeRowMap(18449, 8), // Ru 251 (8)
            new TankTreeRowMap(20497, 4), // VK 100.01 (P) (8)

            new TankTreeRowMap(7953, 1), // Jagdtiger (9)
            new TankTreeRowMap(14865, 7), // Leopard Prototyp A (9)


        };
    }
}