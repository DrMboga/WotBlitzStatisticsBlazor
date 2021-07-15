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
                Constants.HeavyTank when !isPremium => "/tank-type/vehicle.class.heavy.small.scale-200.png",
                Constants.HeavyTank when isPremium => "/tank-type/vehicle.class.heavy.premium.small.scale-200.png",
                Constants.AtSpg when !isPremium => "/tank-type/vehicle.class.atspg.small.scale-200.png",
                Constants.AtSpg when isPremium => "/tank-type/vehicle.class.atspg.premium.small.scale-200.png",
                Constants.MediumTank when !isPremium => "/tank-type/vehicle.class.medium.small.scale-200.png",
                Constants.MediumTank when isPremium => "/tank-type/vehicle.class.medium.premium.small.scale-200.png",
                Constants.LightTank when !isPremium => "/tank-type/vehicle.class.light.small.scale-200.png",
                Constants.LightTank when isPremium => "/tank-type/vehicle.class.light.premium.small.scale-200.png",
                _ => ""
            };
        }

        public static string NationAsset(this string nationTypeId)
        {
            return nationTypeId switch
            {
                Constants.CountryUsa => "flags/usa.png",
                Constants.CountryFrance => "flags/france.png",
                Constants.CountryUssr => "flags/ussr.png",
                Constants.CountryChina => "flags/china.png",
                Constants.CountryUk => "flags/uk.png",
                Constants.CountryJapan => "flags/japan.png",
                Constants.CountryGermany => "flags/germany.png",
                Constants.CountryOther => "flags/other.png",
                Constants.CountryEuropean => "flags/eu.png",
                _ => "flags/vehicle.nation.unknown.scale-200.png"
            };
        }
    }
}
