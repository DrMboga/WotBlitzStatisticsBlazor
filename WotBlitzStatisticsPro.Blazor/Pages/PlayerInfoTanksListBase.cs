using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Radzen;
using Radzen.Blazor;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Helpers;
using WotBlitzStatisticsPro.Blazor.Model;
using MediatR;
using WotBlitzStatisticsPro.Blazor.Messages;
namespace WotBlitzStatisticsPro.Blazor.Pages
{
    public class PlayerInfoTanksListBase: ComponentBase
    {
        [Parameter]
        public IEnumerable<ITank> TanksList { get; set; }

        [Inject]
        public TooltipService TooltipService { get; set; }

        [Inject]
        public IStringLocalizer<App> Localize { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        public RadzenDataGrid<ITank> TanksGrid { get; set; }

        public IEnumerable<ITank> FilteredTankList { get; set; }

        public List<FilterItem<int>> TierFilter { get; set; } = new();
        public IEnumerable<int> FilteredTiers { get; set; } = new int[] { };

        public List<FilterItem<string>> TankTypesFilter { get; set; } = new();
        public IEnumerable<string> FilteredTankTypes { get; set; } = new string[] { };

        public bool? FilterIsPremium { get; set; } = null;

        public List<FilterItem<string>> NationsFilter { get; set; } = new();
        public IEnumerable<string> FilteredNations { get; set; } = new string[] { };

        public List<FilterItem<MarkOfMastery>> MasteryFilter { get; set; } = new();
        public IEnumerable<MarkOfMastery> FilteredMastery { get; set; } = new MarkOfMastery[] { };

        public int TotalBattles { get; set; }
        public int AvgWinRate { get; set; }
        public double AvgWn7 { get; set; }
        public int AvgTotalDamage { get; set; }
        public int AvgTotalXp { get; set; }
        public int AvgSurvivalRate { get; set; }
        public int? MinBattles { get; set; } = null;

        protected override void OnInitialized()
        {
            FilteredTankList = TanksList.OrderByDescending(t => t.LastBattleTime);
            CountTotalParams();
            for (int i = 1; i < 11; i++)
            {
                TierFilter.Add(new FilterItem<int>(i, i.RomanNumber()));
            }
            FillTankTypesFilter();
            FillNationsFilter();
            FillMasteryFilter();
        }

        public void ShowTooltip(ElementReference elementReference, string message, TooltipOptions options = null) => TooltipService.Open(elementReference, message, options);

        public void OnFilterChange(object value)
        {
            FilteredTankList = TanksList;
            if (FilteredTiers.Any())
            {
                FilteredTankList = FilteredTankList.Where(t => FilteredTiers.Contains(t.Tier));
            }
            if (FilteredTankTypes.Any())
            {
                FilteredTankList = FilteredTankList.Where(t => FilteredTankTypes.Contains(t.TankTypeId));
            }
            if (FilterIsPremium.HasValue)
            {
                FilteredTankList = FilteredTankList.Where(t => t.IsPremium == FilterIsPremium.Value);
            }
            if (FilteredNations.Any())
            {
                FilteredTankList = FilteredTankList.Where(t => FilteredNations.Contains(t.TankNationId));
            }
            if (FilteredMastery.Any())
            {
                FilteredTankList = FilteredTankList.Where(t => FilteredMastery.Contains(t.MarkOfMastery));
            }
            if (MinBattles.HasValue)
            {
                FilteredTankList = FilteredTankList.Where(t => t.Battles > MinBattles.Value);
            }

            CountTotalParams();
        }

        private void FillTankTypesFilter()
        {
            // ToDo: Should get values from Dictionary here instead of hard code
            TankTypesFilter.Add(new FilterItem<string>(Constants.HeavyTank, Constants.HeavyTank.TankTypeAsset(false)));
            TankTypesFilter.Add(new FilterItem<string>(Constants.AtSpg, Constants.AtSpg.TankTypeAsset(false)));
            TankTypesFilter.Add(new FilterItem<string>(Constants.MediumTank, Constants.MediumTank.TankTypeAsset(false)));
            TankTypesFilter.Add(new FilterItem<string>(Constants.LightTank, Constants.LightTank.TankTypeAsset(false)));
        }

        private void FillNationsFilter()
        {
            // ToDo: Should get values from Dictionary here instead of hard code
            NationsFilter.Add(new FilterItem<string>(Constants.CountryUsa, Constants.CountryUsa.NationAsset()));
            NationsFilter.Add(new FilterItem<string>(Constants.CountryFrance, Constants.CountryFrance.NationAsset()));
            NationsFilter.Add(new FilterItem<string>(Constants.CountryUssr, Constants.CountryUssr.NationAsset()));
            NationsFilter.Add(new FilterItem<string>(Constants.CountryChina, Constants.CountryChina.NationAsset()));
            NationsFilter.Add(new FilterItem<string>(Constants.CountryUk, Constants.CountryUk.NationAsset()));
            NationsFilter.Add(new FilterItem<string>(Constants.CountryJapan, Constants.CountryJapan.NationAsset()));
            NationsFilter.Add(new FilterItem<string>(Constants.CountryGermany, Constants.CountryGermany.NationAsset()));
            NationsFilter.Add(new FilterItem<string>(Constants.CountryOther, Constants.CountryOther.NationAsset()));
            NationsFilter.Add(new FilterItem<string>(Constants.CountryEuropean, Constants.CountryEuropean.NationAsset()));
        }

        private void FillMasteryFilter()
        {
            foreach (MarkOfMastery mastery in Enum.GetValues(typeof(MarkOfMastery)))
            {
                MasteryFilter.Add(new FilterItem<MarkOfMastery>(mastery, mastery.IconAsset()));
            }
        }

        private void CountTotalParams()
        {
            TotalBattles = Convert.ToInt32(FilteredTankList.Sum(t => t.Battles));
            if (TotalBattles > 0)
            {
                AvgWinRate = Convert.ToInt32(100 * FilteredTankList.Sum(t => t.Wins) / TotalBattles);
                AvgWn7 = Convert.ToDouble(FilteredTankList.Sum(t => t.Wn7)) / FilteredTankList.Count();
                AvgTotalDamage = Convert.ToInt32(FilteredTankList.Sum(t => t.DamageDealt) / TotalBattles);
                AvgTotalXp = Convert.ToInt32(FilteredTankList.Sum(t => t.Xp) / TotalBattles);
                AvgSurvivalRate = Convert.ToInt32(100 * FilteredTankList.Sum(t => t.WinAndSurvived) / TotalBattles);
            }
            else
            {
                AvgWinRate = 0;
                AvgWn7 = 0;
                AvgTotalDamage = 0;
                AvgTotalXp = 0;
                AvgSurvivalRate = 0;
            }
        }
    }
}