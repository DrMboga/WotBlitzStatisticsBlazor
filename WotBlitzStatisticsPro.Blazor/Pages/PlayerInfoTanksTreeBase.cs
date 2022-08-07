using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.GraphQl;
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

        public List<TankTreeItem> TreeItems { get; set; } = new();

        public string SelectedNation { get; set; } = "germany";
        
        public string FrameStyle
        {
            get
            {
                return $"min-height: {FrameHeigth}px; overflow-y: auto; overflow-x: auto;";
            }
        }

        protected async override Task OnInitializedAsync()
        {
            var screenHeight = await MediaQueriesService.WindowHeight();

            // TODO: Move it to the Nation selector handler
            try
            {
                VehiclesLibrary = await GraphQlBackendService.GetVehiclesByNation(SelectedNation);
                BuildTree();
            }
            catch (System.Exception e)
            {
                Notifications.ReportError("Can not get data from backend", e.Message);
            }

        }

        public int GetTextWidth(string text, string fontFace, int fontSize)
        {
            return SvgHelper.CalculateTextBlockSize(text, fontFace, fontSize).Width;
        }

        private void BuildTree()
        {
            TreeItems.Clear();
            var vehiclesTree = VehiclesLibrary.Where(v => v.IsPremium == false).ToList();
            for (int tier = 1; tier < 11; tier++)
            {
                var vehiclesByTier = vehiclesTree.Where(v => v.Tier == tier).ToList();
                int row = 0;
                // TODO: Order
                foreach (var vehicleFromDictionary in vehiclesByTier)
                {
                    // Find previous map to figure out the row
                    int currentRow = FindRowFromPreviousTierMapping(vehicleFromDictionary, row);

                    var treeItem = BuildNonPremTreeItem(vehicleFromDictionary, currentRow);
                    
                    // Map next tier tanks by rows
                    treeItem.NextRows = BuildNextTanksRowMapping(vehicleFromDictionary, currentRow);
                    
                    TreeItems.Add(treeItem);
                    row++;
                }
            }

            // var firstTank = vehiclesTree.First(v => v.Tier == 1);
            // TreeItems.AddRange(BuildTree(firstTank, 0, vehiclesTree));
            
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
                if (vehicleFromDictionary.NexTanksInTree.Count == 1)
                {
                    nextRowsMap.Add(new TankTreeRowMap(vehicleFromDictionary.NexTanksInTree[0], currentRow));
                }
                else
                {
                    // If more than one, sort them AT first, Heavy, Middle and light
                    int nextRow = currentRow;
                    string[] tankTypes = { "AT-SPG", "heavyTank", "mediumTank", "lightTank" };
                    var nextTanksTypes = VehiclesLibrary
                        .Where(v => vehicleFromDictionary.NexTanksInTree.Contains(v.TankId))
                        .Select(v => new { v.TankId, TankType = v.TypeId })
                        .ToList();
                    foreach (var tankType in tankTypes)
                    {
                        foreach (var nextTierTank in nextTanksTypes.Where(t => t.TankType == tankType))
                        {
                            nextRowsMap.Add(new TankTreeRowMap(nextTierTank.TankId, nextRow));
                            nextRow++;
                        }
                    }
                }
            }

            return nextRowsMap;
        }

        private int FindRowFromPreviousTierMapping(IDictionary_Vehicles vehicleFromDictionary, int currentRow)
        {
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

        [Obsolete]
        private List<TankTreeItem> BuildTree(IDictionary_Vehicles firstTank, int rowNumber, List<IDictionary_Vehicles> vehiclesTree)
        {
            var result = new List<TankTreeItem>();
            result.Add(BuildNonPremTreeItem(firstTank, rowNumber));

            var nextTierTanks = vehiclesTree.Where(
                v => firstTank.NexTanksInTree != null && firstTank.NexTanksInTree.Contains(v.TankId)).ToList();

            if (nextTierTanks.Count == 1)
            {
                result.AddRange(BuildTree(nextTierTanks[0], rowNumber, vehiclesTree));
                return result;
            }

            // If more than one, sort them AT first, Heavy, Middle and light
            int nextRow = rowNumber;
            string[] tankTypes = { "AT-SPG", "heavyTank", "mediumTank", "lightTank" };
            foreach (var tankType in tankTypes)
            {
                foreach (var nextTierTank in nextTierTanks.Where(t => t.TypeId == tankType))
                {
                    var branch = BuildTree(nextTierTank, nextRow, vehiclesTree);
                    result.AddRange(branch);
                    nextRow += GetMaxRowNumber(branch);
                }
            }
            
            return result;
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
    }
}
