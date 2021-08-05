using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Helpers;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class ChartService: IChartsService
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IStringLocalizer<App> _localize;

        public ChartService(IJSRuntime jsRuntime, IStringLocalizer<App> localize)
        {
            _jsRuntime = jsRuntime;
            _localize = localize;
        }

        public async Task BuildBarChartBattlesByTankType(string elementId, IEnumerable<ITank> tanks)
        {
            var battlesCountByTankType = new Dictionary<string, long>();

            foreach (var tank in tanks)
            {
                if (tank.TankTypeId == null)
                {
                    continue;
                }
                if (battlesCountByTankType.ContainsKey(tank.TankTypeId))
                {
                    battlesCountByTankType[tank.TankTypeId] += tank.Battles;
                }
                else
                {
                    battlesCountByTankType.Add(tank.TankTypeId, tank.Battles);
                }
            }

            int mediumValue = 0;
            int lightValue = 0;
            int heavyValue = 0;
            int atValue = 0;
            if (battlesCountByTankType.ContainsKey(Constants.MediumTank))
            {
                mediumValue = Convert.ToInt32(battlesCountByTankType[Constants.MediumTank]);
            }
            if (battlesCountByTankType.ContainsKey(Constants.LightTank))
            {
                lightValue = Convert.ToInt32(battlesCountByTankType[Constants.LightTank]);
            }
            if (battlesCountByTankType.ContainsKey(Constants.HeavyTank))
            {
                heavyValue = Convert.ToInt32(battlesCountByTankType[Constants.HeavyTank]);
            }
            if (battlesCountByTankType.ContainsKey(Constants.AtSpg))
            {
                atValue = Convert.ToInt32(battlesCountByTankType[Constants.AtSpg]);
            }

            var chartData = new[]
            {
                new {tankType = Constants.MediumTank, value = mediumValue, color = "#9FE3CE"},
                new {tankType = Constants.LightTank, value = lightValue, color = "#9FE3CE"},
                new {tankType = Constants.HeavyTank, value = heavyValue, color = "#9FE3CE"},
                new {tankType = Constants.AtSpg, value = atValue, color = "#9FE3CE"},
            };

            await _jsRuntime.InvokeVoidAsync("eChartsInterop.BuildBarChartByTankType", elementId, _localize.GetString("Battles by tank types").Value, chartData);
        }

        public async Task BuildBarChartWinRatesByTankType(string elementId, IEnumerable<ITank> tanks)
        {
            var battlesCountByTankType = new Dictionary<string, long>();
            var winsCountByTankType = new Dictionary<string, long>();

            foreach (var tank in tanks)
            {
                if(tank.TankTypeId == null)
                {
                    continue;
                }
                if(battlesCountByTankType.ContainsKey(tank.TankTypeId))
                {
                    battlesCountByTankType[tank.TankTypeId] += tank.Battles;
                }
                else
                {
                    battlesCountByTankType.Add(tank.TankTypeId, tank.Battles);
                }
                if(winsCountByTankType.ContainsKey(tank.TankTypeId))
                {
                    winsCountByTankType[tank.TankTypeId] += tank.Wins;
                }
                else
                {
                    winsCountByTankType.Add(tank.TankTypeId, tank.Wins);
                }
            }

            int mediumValue = 0;
            int lightValue = 0;
            int heavyValue = 0;
            int atValue = 0;
            if (battlesCountByTankType.ContainsKey(Constants.MediumTank))
            {
                mediumValue = Convert.ToInt32(100 * winsCountByTankType[Constants.MediumTank] /
                                battlesCountByTankType[Constants.MediumTank]);
            }
            if (battlesCountByTankType.ContainsKey(Constants.LightTank))
            {
                lightValue = Convert.ToInt32(100 * winsCountByTankType[Constants.LightTank] /
                                               battlesCountByTankType[Constants.LightTank]);
            }
            if (battlesCountByTankType.ContainsKey(Constants.HeavyTank))
            {
                heavyValue = Convert.ToInt32(100 * winsCountByTankType[Constants.HeavyTank] /
                                               battlesCountByTankType[Constants.HeavyTank]);
            }
            if (battlesCountByTankType.ContainsKey(Constants.AtSpg))
            {
                atValue = Convert.ToInt32(100 * winsCountByTankType[Constants.AtSpg] /
                                            battlesCountByTankType[Constants.AtSpg]);
            }

            var chartData = new[]
            {
                new {tankType = Constants.MediumTank, value = mediumValue, color = mediumValue.ScaleColor()},
                new {tankType = Constants.LightTank, value = lightValue, color = lightValue.ScaleColor()},
                new {tankType = Constants.HeavyTank, value = heavyValue, color = heavyValue.ScaleColor()},
                new {tankType = Constants.AtSpg, value = atValue, color = atValue.ScaleColor()},
            };

            await _jsRuntime.InvokeVoidAsync("eChartsInterop.BuildBarChartByTankType", elementId, _localize.GetString("Win rate by tank types").Value, chartData);
        }

        public async Task BuildBarChartAvgDmgByTankType(string elementId, IEnumerable<ITank> tanks)
        {
            var battlesCountByTankType = new Dictionary<string, long>();
            var damageSumByTankType = new Dictionary<string, long>();

            foreach (var tank in tanks)
            {
                if (tank.TankTypeId == null)
                {
                    continue;
                }
                if (battlesCountByTankType.ContainsKey(tank.TankTypeId))
                {
                    battlesCountByTankType[tank.TankTypeId] += tank.Battles;
                }
                else
                {
                    battlesCountByTankType.Add(tank.TankTypeId, tank.Battles);
                }
                if (damageSumByTankType.ContainsKey(tank.TankTypeId))
                {
                    damageSumByTankType[tank.TankTypeId] += tank.DamageDealt;
                }
                else
                {
                    damageSumByTankType.Add(tank.TankTypeId, tank.DamageDealt);
                }
            }

            int mediumValue = 0;
            int lightValue = 0;
            int heavyValue = 0;
            int atValue = 0;
            if (battlesCountByTankType.ContainsKey(Constants.MediumTank))
            {
                mediumValue = Convert.ToInt32(damageSumByTankType[Constants.MediumTank] /
                                battlesCountByTankType[Constants.MediumTank]);
            }
            if (battlesCountByTankType.ContainsKey(Constants.LightTank))
            {
                lightValue = Convert.ToInt32(damageSumByTankType[Constants.LightTank] /
                                               battlesCountByTankType[Constants.LightTank]);
            }
            if (battlesCountByTankType.ContainsKey(Constants.HeavyTank))
            {
                heavyValue = Convert.ToInt32(damageSumByTankType[Constants.HeavyTank] /
                                               battlesCountByTankType[Constants.HeavyTank]);
            }
            if (battlesCountByTankType.ContainsKey(Constants.AtSpg))
            {
                atValue = Convert.ToInt32(damageSumByTankType[Constants.AtSpg] /
                                            battlesCountByTankType[Constants.AtSpg]);
            }

            var chartData = new[]
            {
                new {tankType = Constants.MediumTank, value = mediumValue, color = "#D98D8B"},
                new {tankType = Constants.LightTank, value = lightValue, color = "#D98D8B"},
                new {tankType = Constants.HeavyTank, value = heavyValue, color = "#D98D8B"},
                new {tankType = Constants.AtSpg, value = atValue, color = "#D98D8B"},
            };

            await _jsRuntime.InvokeVoidAsync("eChartsInterop.BuildBarChartByTankType", elementId, _localize.GetString("Avg damage by tank types").Value, chartData);
        }

        public async Task BuildStackedBarChart(string elementId)
        {
            await _jsRuntime.InvokeVoidAsync("eChartsInterop.BuildStackedBarChart", elementId);
        }
    }
}