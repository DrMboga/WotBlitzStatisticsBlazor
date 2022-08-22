using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Helpers;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Pages
{
    public class PlayerInfoTanksTreeBase: ComponentBase
    {
        [Parameter]
        public IEnumerable<ITank> TanksList { get; set; }

        [Inject]
        public IStringLocalizer<App> Localize { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public IMediaQueriesService MediaQueriesService { get; set; }

        [Inject]
        public ISvgHelper SvgHelper { get; set; }

        [Inject]
        public IGraphQlBackendService GraphQlBackendService { get; set; }

        [Inject]
        public INotificationsService Notifications { get; set; }

        public IReadOnlyList<IDictionary_Vehicles> VehiclesLibrary { get; set; }

        public int FrameHeigth { get; set; }

        public int CardWidth { get; } = 200;
        public int CardHeigth { get; } = 120;

        public int LeftMargin { get; } = 30;

        public List<TankTreeItem> TreeItems { get; set; } = new();

        public string SelectedNation { get; set; }

        public List<string> Connections { get; set; } = new List<string>();

        public List<string> ConnectionsInVerticalView { get; set; } = new List<string>();

        public List<FilterItem<string>> NationsFilter { get; set; } = new();

        public string FrameStyle
        {
            get
            {
                return $"min-height: {FrameHeigth}px; overflow-y: auto; overflow-x: auto;";
            }
        }

        protected async override Task OnInitializedAsync()
        {
            FillNationsFilter();
            var screenHeight = await MediaQueriesService.WindowHeight();

            await LoadTree();
        }

        public int GetTextWidth(string text, string fontFace, int fontSize)
        {
            return SvgHelper.CalculateTextBlockSize(text, fontFace, fontSize).Width;
        }

        private void BuildTree()
        {
            TreeItems.Clear();
            Connections.Clear();
            ConnectionsInVerticalView.Clear();
            var vehiclesTree = VehiclesLibrary?.Where(v => v != null && v.IsPremium == false).ToList();
            for (int tier = 1; tier < 11; tier++)
            {
                var vehiclesByTier = vehiclesTree.Where(v => v.Tier == tier).ToList();
                foreach (var vehicleFromDictionary in vehiclesByTier)
                {
                    int currentRow = 0;
                    if (tier == 1)
                    {
                        var rowMap = Constants.TanksTreeHelper.FirstOrDefault(v => v.TankId == vehicleFromDictionary.TankId);
                        if(rowMap != null)
                        {
                            currentRow = rowMap.Row;
                        }
                    }
                    else
                    {
                        currentRow = FindRowFromPreviousTierMapping(vehicleFromDictionary);
                    }

                    var treeItem = BuildNonPremTreeItem(vehicleFromDictionary, currentRow);

                    // Map next tier tanks by rows
                    treeItem.NextRows = BuildNextTanksRowMapping(vehicleFromDictionary, currentRow);
                    if(treeItem.NextRows != null)
                    {
                        foreach (var nextRow in treeItem.NextRows)
                        {
                            Connections.Add(SvgHelper.TankTreeConnectionPath(treeItem.Row, nextRow.Row, tier, CardWidth, CardHeigth));
                            // TODO: Calc ConnectionsInVerticalView
                        }
                    }
                    
                    TreeItems.Add(treeItem);
                }
            }

            int maxNonPremTreeRow = GetMaxRowNumber(TreeItems);
            
            // TODO: build matrix and connections
            
            // Adding prem tanks
            var premTanks = TanksList.Where(t => t.IsPremium && t.TankNationId == SelectedNation).ToList();
            int maxPremsCount = maxNonPremTreeRow;
            foreach (var premTier in premTanks.Select(b => b.Tier).Distinct())
            {
                int row = maxNonPremTreeRow + 1;
                foreach (var prem in premTanks.Where(t => t.Tier == premTier))
                {
                    TreeItems.Add(new TankTreeItem
                    {
                        Tier = prem.Tier,
                        TankId = prem.TankId,
                        Name = prem.Name,
                        PreviewImage = prem.PreviewImage,
                        TankTypeId = prem.TankTypeId,
                        IsPremium = true,
                        MarkOfMastery = prem.MarkOfMastery,
                        WinRate = prem.WinRate,
                        AvgDamage = prem.AvgDamage,
                        Battles = prem.Battles,
                        LastBattleTime = prem.LastBattleTime,
                        IsResearched = true,
                        Row = row
                    });
                    row++;
                    if (row > maxPremsCount)
                    {
                        maxPremsCount = row;
                    }
                }
            }

            FrameHeigth = maxPremsCount * (CardHeigth + 20) + 20;
        }

        private List<TankTreeRowMap>? BuildNextTanksRowMapping(IDictionary_Vehicles vehicleFromDictionary, int currentRow)
        {
            List<TankTreeRowMap>? nextRowsMap = null;

            if (vehicleFromDictionary.NexTanksInTree != null && vehicleFromDictionary.NexTanksInTree.Count > 0)
            {
                nextRowsMap = new List<TankTreeRowMap>();
                foreach (var nextTankInTree in vehicleFromDictionary.NexTanksInTree)
                {
                    var rowMap = Constants.TanksTreeHelper.FirstOrDefault(v => v.TankId == nextTankInTree);
                    if (rowMap != null)
                    {
                        nextRowsMap.Add(rowMap);
                    }
                    else
                    {
                        nextRowsMap.Add(new TankTreeRowMap(vehicleFromDictionary.NexTanksInTree[0], currentRow));
                    }
                }
            }

            return nextRowsMap;
        }

        private int FindRowFromPreviousTierMapping(IDictionary_Vehicles vehicleFromDictionary)
        {
            int currentRow = 0;
            var previousTierTanks = TreeItems.Where(t => t.Tier == vehicleFromDictionary.Tier - 1).ToList();
            foreach (var previousTierTank in previousTierTanks)
            {
                if (previousTierTank.NextRows != null)
                {
                    var rowMap =
                        previousTierTank.NextRows.FirstOrDefault(p => p.TankId == vehicleFromDictionary.TankId);
                    if (rowMap != null)
                    {
                        currentRow = rowMap.Row;
                        break;
                    }
                }
            }

            return currentRow;
        }

        private TankTreeItem BuildNonPremTreeItem(IDictionary_Vehicles vehicleFromDictionary, int row)
        {
            var treeItem = new TankTreeItem
            {
                Tier = vehicleFromDictionary.Tier,
                TankId = vehicleFromDictionary.TankId,
                Name = vehicleFromDictionary.Name,
                PriceCredit = vehicleFromDictionary.PriceCredit,
                PreviewImage = vehicleFromDictionary.PreviewImage,
                TankTypeId = vehicleFromDictionary.TypeId,
                IsPremium = false,
                Row = row
            };
            var researched = TanksList.FirstOrDefault(t => t.TankId == treeItem.TankId);
            treeItem.IsResearched = researched != null;
            if (researched != null)
            {
                treeItem.MarkOfMastery = researched.MarkOfMastery;
                treeItem.WinRate = researched.WinRate;
                treeItem.AvgDamage = researched.AvgDamage;
                treeItem.Battles = researched.Battles;
                treeItem.LastBattleTime = researched.LastBattleTime;
            }

            return treeItem;
        }

        private int GetMaxRowNumber(List<TankTreeItem> branch)
        {
            int maxRowsCount = 0;
            foreach (var tier in branch.Select(b => b.Tier).Distinct())
            {
                int tierTanksCount = branch.Count(t => t.Tier == tier);
                if (tierTanksCount > maxRowsCount)
                {
                    maxRowsCount = tierTanksCount;
                }
            }

            return maxRowsCount;
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

            SelectedNation = NationsFilter[0].ItemId;
        }

        public string NationFilterStyle(string nation)
        {
            string basic = "nation-filter-flag";
            if (SelectedNation == nation)
            {
                return $"{basic} filter-selected";
            }
            return basic;
        }

        public async Task ApplyNationFilter(MouseEventArgs e, string nationToApply)
        {
            SelectedNation = nationToApply;
            await LoadTree();
        }

        private async Task LoadTree()
        {
            try
            {
                VehiclesLibrary = await GraphQlBackendService.GetVehiclesByNation(SelectedNation);
                BuildTree();
            }
            catch (System.Exception e)
            {
                Notifications.ReportError("Can not get data from backend", e.Message, e.StackTrace);
            }

        }
    }
}
