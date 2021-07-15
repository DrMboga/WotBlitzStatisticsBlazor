using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Helpers
{
    public static class AssetsHelper
    {
        public static string IconAsset(this MarkOfMastery mastery)
        {
            return mastery switch
            {
                MarkOfMastery.Rank3 => "/mastery/vehicle.mark.third.scale-200.png",
                MarkOfMastery.Rank2 => "/mastery/vehicle.mark.second.scale-200.png",
                MarkOfMastery.Rank1 => "/mastery/vehicle.mark.first.scale-200.png",
                MarkOfMastery.Master => "/mastery/vehicle.mark.master.scale-200.png",
                _ => "/mastery/vehicle.mark.none.big.scale-200.png"
            };
        }

        public static string TankTypeAsset(this string tankTypeId, bool isPremium)
        {
            return tankTypeId switch
            {
                "heavyTank" when !isPremium => "/tank-type/vehicle.class.heavy.small.scale-200.png",
                "heavyTank" when isPremium => "/tank-type/vehicle.class.heavy.premium.small.scale-200.png",
                "AT-SPG" when !isPremium => "/tank-type/vehicle.class.atspg.small.scale-200.png",
                "AT-SPG" when isPremium => "/tank-type/vehicle.class.atspg.premium.small.scale-200.png",
                "mediumTank" when !isPremium => "/tank-type/vehicle.class.medium.small.scale-200.png",
                "mediumTank" when isPremium => "/tank-type/vehicle.class.medium.premium.small.scale-200.png",
                "lightTank" when !isPremium => "/tank-type/vehicle.class.light.small.scale-200.png",
                "lightTank" when isPremium => "/tank-type/vehicle.class.light.premium.small.scale-200.png",
                _ => ""
            };
        }

        public static string NationAsset(this string nationTypeId)
        {
            return nationTypeId switch
            {
                "usa" => "flags/usa.png",
                "france" => "flags/france.png",
                "ussr" => "flags/ussr.png",
                "china" => "flags/china.png",
                "uk" => "flags/uk.png",
                "japan" => "flags/japan.png",
                "germany" => "flags/germany.png",
                "other" => "flags/other.png",
                "european" => "flags/eu.png",
                _ => "flags/vehicle.nation.unknown.scale-200.png"
            };
        }
    }
}
