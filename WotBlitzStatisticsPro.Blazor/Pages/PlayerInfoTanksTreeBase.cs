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

            FrameHeigth = screenHeight + 390;
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
                foreach (var vehicleFromDictionary in vehiclesByTier)
                {
                    var treeItem = new TankTreeItem
                    {
                        Tier = tier,
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

                    TreeItems.Add(treeItem);
                    row++;
                }
            }
            // TODO: build matrix and connections
            
            // Adding prem tanks
            foreach (var prem in TanksList.Where(t => t.IsPremium && t.TankNationId == SelectedNation))
            {
                int row = TreeItems.Count(i => i.Tier == prem.Tier) + 1;
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
            }
        }
    }
}
