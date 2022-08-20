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

            // usa
            new TankTreeRowMap(1825, 2), // First tank in a tree

            new TankTreeRowMap(10273, 1), // M8A1 (4)
            new TankTreeRowMap(5409, 2), // M7 (4)

            new TankTreeRowMap(3361, 2), // T1 Heavy Tank (5)
            new TankTreeRowMap(1057, 4), // M4 Sherman (5)

            new TankTreeRowMap(11553, 0), // M18 Hellcat (6)
            new TankTreeRowMap(7201, 1), // M36 Jackson (6)
            new TankTreeRowMap(1313, 4), // M4A3E8 Sherman 6)
            new TankTreeRowMap(16673, 5), // T37 (6)
            new TankTreeRowMap(9761, 6), // M24 Chaffee (6)

            new TankTreeRowMap(3873, 2), // T29 (7)
            new TankTreeRowMap(23585, 3), // M-VII-Yoh (7)

            new TankTreeRowMap(8225, 1), // T28 (8)

            new TankTreeRowMap(2593, 0), // T30 (9)
            new TankTreeRowMap(20001, 6), // T92E1 (9)
            new TankTreeRowMap(15393, 5), // T54E1 (9)

            // france
            new TankTreeRowMap(15937, 1), // First tank in a tree

            new TankTreeRowMap(9793, 0), // Somua SAu 40 (4)
            new TankTreeRowMap(1089, 1), // B1 (4)

            new TankTreeRowMap(6721, 1), // BDR G1 B (5)
            new TankTreeRowMap(14145, 2), // AMX ELC bis (5)

            // ussr
            new TankTreeRowMap(4609, 2), // First tank in a tree
            new TankTreeRowMap(3329, 0), // МС-1 обр. 1

            new TankTreeRowMap(6913, 1), // СУ-85Б (4)
            new TankTreeRowMap(2049, 2), // А-20 (4)

            new TankTreeRowMap(11777, 2), // КВ-1 (5)
            new TankTreeRowMap(1, 5), // Т-34 (5)

            new TankTreeRowMap(2817, 2), // КВ-1С (6)
            new TankTreeRowMap(10497, 3), // КВ-2 (6)
            new TankTreeRowMap(2561, 4), // Т-34-85 6)
            new TankTreeRowMap(16641, 6), // МТ-25 (6)

            new TankTreeRowMap(2305, 0), // СУ-152 (7)
            new TankTreeRowMap(10241, 1), // СУ-100М1 (7)
            new TankTreeRowMap(513, 2), // ИС (7)
            new TankTreeRowMap(5889, 3), // КВ-3 (7)
            new TankTreeRowMap(18433, 5), // ЛТТБ (7)
            new TankTreeRowMap(24065, 6), // ЛТГ (7)

            new TankTreeRowMap(18177, 6), // Т-54 обл. (8)

            new TankTreeRowMap(7937, 5), // Т-54 (9)
            new TankTreeRowMap(23809, 6), // Объект 84 (9)

            new TankTreeRowMap(16897, 4), // Объект 140 (10)
            new TankTreeRowMap(13825, 5), // Т-62А (10)

            // china
            new TankTreeRowMap(2353, 1), // First tank in a tree

            new TankTreeRowMap(7729, 0), // WZ-131G FT (6)
            new TankTreeRowMap(5169, 1), // Type 58 (6)

            new TankTreeRowMap(3633, 1), // IS-2 (7)
            new TankTreeRowMap(1073, 2), // T-34-1 (7)

            // uk
            new TankTreeRowMap(6993, 2), // First tank in a tree

            new TankTreeRowMap(9041, 0), // Alecto (4)
            new TankTreeRowMap(849, 3), // Matilda (4)

            new TankTreeRowMap(2129, 2), // Crusader (5)
            new TankTreeRowMap(2897, 4), // Churchill I (5)

            new TankTreeRowMap(593, 1), // Sherman Firefly (6)
            new TankTreeRowMap(1105, 2), // Cromwell (6)

            new TankTreeRowMap(18257, 1), // Challenger (7)
            new TankTreeRowMap(5457, 2), // Comet (7)

            new TankTreeRowMap(5969, 2), // Centurion Mk. I (8)
            new TankTreeRowMap(20049, 3), // FV301 (8)

            // japan
            new TankTreeRowMap(865, 2), // First tank in a tree

            new TankTreeRowMap(1377, 1), // Type 3 Chi-Nu (5)
            new TankTreeRowMap(5473, 2), // Mitsu 108 (5)

            new TankTreeRowMap(5217, 0), // Chi-To SPG (7)
            new TankTreeRowMap(1121, 1), // Type 5 Chi-Ri (7)

            // european
            new TankTreeRowMap(2689, 1), // First tank in a tree

            new TankTreeRowMap(3713, 0), // Strv 74 (6)
            new TankTreeRowMap(8065, 1), // 40TP Habicha (6)
            new TankTreeRowMap(1409, 2), // P.43 bis 6)
            new TankTreeRowMap(6529, 3), // Škoda T 25 (6)

        };
    }
}