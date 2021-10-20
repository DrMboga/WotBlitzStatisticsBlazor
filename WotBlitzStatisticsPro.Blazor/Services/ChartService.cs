using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Helpers;
using WotBlitzStatisticsPro.Blazor.Model;

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

        public async Task BuildBarChartBattlesByNation(string elementId, IEnumerable<ITank> tanks)
        {
            var battlesCountByNation = new Dictionary<string, long>();

            foreach (var tank in tanks)
            {
                if (string.IsNullOrEmpty(tank.TankNationId))
                {
                    continue;
                }
                if (battlesCountByNation.ContainsKey(tank.TankNationId))
                {
                    battlesCountByNation[tank.TankNationId] += tank.Battles;
                }
                else
                {
                    battlesCountByNation.Add(tank.TankNationId, tank.Battles);
                }
            }

            int chinaData = 0;
            int euData = 0;
            int franceData = 0;
            int germanyData = 0;
            int japanData = 0;
            int otherData = 0;
            int ukData = 0;
            int usaData = 0;
            int ussrData = 0;
            if (battlesCountByNation.ContainsKey(Constants.CountryChina))
            {
                chinaData = Convert.ToInt32(battlesCountByNation[Constants.CountryChina]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryEuropean))
            {
                euData = Convert.ToInt32(battlesCountByNation[Constants.CountryEuropean]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryFrance))
            {
                franceData = Convert.ToInt32(battlesCountByNation[Constants.CountryFrance]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryGermany))
            {
                germanyData = Convert.ToInt32(battlesCountByNation[Constants.CountryGermany]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryJapan))
            {
                japanData = Convert.ToInt32(battlesCountByNation[Constants.CountryJapan]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryOther))
            {
                otherData = Convert.ToInt32(battlesCountByNation[Constants.CountryOther]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryUk))
            {
                ukData = Convert.ToInt32(battlesCountByNation[Constants.CountryUk]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryUsa))
            {
                usaData = Convert.ToInt32(battlesCountByNation[Constants.CountryUsa]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryUssr))
            {
                ussrData = Convert.ToInt32(battlesCountByNation[Constants.CountryUssr]);
            }


            var chartData = new[]
            {
                new {country = Constants.CountryChina, value = chinaData, color = "#9FE3CE"},
                new {country = Constants.CountryEuropean, value = euData, color = "#9FE3CE"},
                new {country = Constants.CountryFrance, value = franceData, color = "#9FE3CE"},
                new {country = Constants.CountryGermany, value = germanyData, color = "#9FE3CE"},
                new {country = Constants.CountryJapan, value = japanData, color = "#9FE3CE"},
                new {country = Constants.CountryOther, value = otherData, color = "#9FE3CE"},
                new {country = Constants.CountryUk, value = ukData, color = "#9FE3CE"},
                new {country = Constants.CountryUsa, value = usaData, color = "#9FE3CE"},
                new {country = Constants.CountryUssr, value = ussrData, color = "#9FE3CE"},
            };

            await _jsRuntime.InvokeVoidAsync("eChartsInterop.BuildBarChartByNation", elementId, _localize.GetString("Battles by nation").Value, chartData);
        }

        public async Task BuildBarChartWinRatesByNation(string elementId, IEnumerable<ITank> tanks)
        {
            var battlesCountByNation = new Dictionary<string, long>();
            var winsCountByNation = new Dictionary<string, long>();

            foreach (var tank in tanks)
            {
                if (string.IsNullOrEmpty(tank.TankNationId))
                {
                    continue;
                }
                if (battlesCountByNation.ContainsKey(tank.TankNationId))
                {
                    battlesCountByNation[tank.TankNationId] += tank.Battles;
                }
                else
                {
                    battlesCountByNation.Add(tank.TankNationId, tank.Battles);
                }
                if (winsCountByNation.ContainsKey(tank.TankNationId))
                {
                    winsCountByNation[tank.TankNationId] += tank.Wins;
                }
                else
                {
                    winsCountByNation.Add(tank.TankNationId, tank.Wins);
                }
            }

            int chinaData = 0;
            int euData = 0;
            int franceData = 0;
            int germanyData = 0;
            int japanData = 0;
            int otherData = 0;
            int ukData = 0;
            int usaData = 0;
            int ussrData = 0;
            if (battlesCountByNation.ContainsKey(Constants.CountryChina))
            {
                chinaData = Convert.ToInt32(100 * winsCountByNation[Constants.CountryChina] /
                                            battlesCountByNation[Constants.CountryChina]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryEuropean))
            {
                euData = Convert.ToInt32(100 * winsCountByNation[Constants.CountryEuropean] /
                                         battlesCountByNation[Constants.CountryEuropean]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryFrance))
            {
                franceData = Convert.ToInt32(100 * winsCountByNation[Constants.CountryFrance] /
                                             battlesCountByNation[Constants.CountryFrance]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryGermany))
            {
                germanyData = Convert.ToInt32(100 * winsCountByNation[Constants.CountryGermany] /
                                              battlesCountByNation[Constants.CountryGermany]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryJapan))
            {
                japanData = Convert.ToInt32(100 * winsCountByNation[Constants.CountryJapan] /
                                            battlesCountByNation[Constants.CountryJapan]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryOther))
            {
                otherData = Convert.ToInt32(100 * winsCountByNation[Constants.CountryOther] /
                                            battlesCountByNation[Constants.CountryOther]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryUk))
            {
                ukData = Convert.ToInt32(100 * winsCountByNation[Constants.CountryUk] /
                                         battlesCountByNation[Constants.CountryUk]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryUsa))
            {
                usaData = Convert.ToInt32(100 * winsCountByNation[Constants.CountryUsa] /
                                          battlesCountByNation[Constants.CountryUsa]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryUssr))
            {
                ussrData = Convert.ToInt32(100 * winsCountByNation[Constants.CountryUssr] /
                                           battlesCountByNation[Constants.CountryUssr]);
            }

            var chartData = new[]
            {
                new {country = Constants.CountryChina, value = chinaData, color = chinaData.ScaleColor()},
                new {country = Constants.CountryEuropean, value = euData, color = euData.ScaleColor()},
                new {country = Constants.CountryFrance, value = franceData, color = franceData.ScaleColor()},
                new {country = Constants.CountryGermany, value = germanyData, color = germanyData.ScaleColor()},
                new {country = Constants.CountryJapan, value = japanData, color = japanData.ScaleColor()},
                new {country = Constants.CountryOther, value = otherData, color = otherData.ScaleColor()},
                new {country = Constants.CountryUk, value = ukData, color = ukData.ScaleColor()},
                new {country = Constants.CountryUsa, value = usaData, color = usaData.ScaleColor()},
                new {country = Constants.CountryUssr, value = ussrData, color = ussrData.ScaleColor()},
            };

            await _jsRuntime.InvokeVoidAsync("eChartsInterop.BuildBarChartByNation", elementId, _localize.GetString("Win rate by nation").Value, chartData);
        }

        public async Task BuildBarChartAvgDmgByNation(string elementId, IEnumerable<ITank> tanks)
        {
            var battlesCountByNation = new Dictionary<string, long>();
            var dmgCountByNation = new Dictionary<string, long>();

            foreach (var tank in tanks)
            {
                if (string.IsNullOrEmpty(tank.TankNationId))
                {
                    continue;
                }
                if (battlesCountByNation.ContainsKey(tank.TankNationId))
                {
                    battlesCountByNation[tank.TankNationId] += tank.Battles;
                }
                else
                {
                    battlesCountByNation.Add(tank.TankNationId, tank.Battles);
                }
                if (dmgCountByNation.ContainsKey(tank.TankNationId))
                {
                    dmgCountByNation[tank.TankNationId] += tank.DamageDealt;
                }
                else
                {
                    dmgCountByNation.Add(tank.TankNationId, tank.DamageDealt);
                }
            }

            int chinaData = 0;
            int euData = 0;
            int franceData = 0;
            int germanyData = 0;
            int japanData = 0;
            int otherData = 0;
            int ukData = 0;
            int usaData = 0;
            int ussrData = 0;
            if (battlesCountByNation.ContainsKey(Constants.CountryChina))
            {
                chinaData = Convert.ToInt32(dmgCountByNation[Constants.CountryChina] /
                                            battlesCountByNation[Constants.CountryChina]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryEuropean))
            {
                euData = Convert.ToInt32(dmgCountByNation[Constants.CountryEuropean] /
                                         battlesCountByNation[Constants.CountryEuropean]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryFrance))
            {
                franceData = Convert.ToInt32(dmgCountByNation[Constants.CountryFrance] /
                                             battlesCountByNation[Constants.CountryFrance]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryGermany))
            {
                germanyData = Convert.ToInt32(dmgCountByNation[Constants.CountryGermany] /
                                              battlesCountByNation[Constants.CountryGermany]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryJapan))
            {
                japanData = Convert.ToInt32(dmgCountByNation[Constants.CountryJapan] /
                                            battlesCountByNation[Constants.CountryJapan]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryOther))
            {
                otherData = Convert.ToInt32(dmgCountByNation[Constants.CountryOther] /
                                            battlesCountByNation[Constants.CountryOther]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryUk))
            {
                ukData = Convert.ToInt32(dmgCountByNation[Constants.CountryUk] /
                                         battlesCountByNation[Constants.CountryUk]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryUsa))
            {
                usaData = Convert.ToInt32(dmgCountByNation[Constants.CountryUsa] /
                                          battlesCountByNation[Constants.CountryUsa]);
            }
            if (battlesCountByNation.ContainsKey(Constants.CountryUssr))
            {
                ussrData = Convert.ToInt32(dmgCountByNation[Constants.CountryUssr] /
                                           battlesCountByNation[Constants.CountryUssr]);
            }

            var chartData = new[]
            {
                new {country = Constants.CountryChina, value = chinaData, color = "#D98D8B"},
                new {country = Constants.CountryEuropean, value = euData, color = "#D98D8B"},
                new {country = Constants.CountryFrance, value = franceData, color = "#D98D8B"},
                new {country = Constants.CountryGermany, value = germanyData, color = "#D98D8B"},
                new {country = Constants.CountryJapan, value = japanData, color = "#D98D8B"},
                new {country = Constants.CountryOther, value = otherData, color = "#D98D8B"},
                new {country = Constants.CountryUk, value = ukData, color = "#D98D8B"},
                new {country = Constants.CountryUsa, value = usaData, color = "#D98D8B"},
                new {country = Constants.CountryUssr, value = ussrData, color = "#D98D8B"},
            };

            await _jsRuntime.InvokeVoidAsync("eChartsInterop.BuildBarChartByNation", elementId, _localize.GetString("Avg damage by nation").Value, chartData);
        }
        public async Task BuildBarChartBattlesByTier(string elementId, IEnumerable<ITank> tanks)
        {
            var battlesCountByTier = new Dictionary<int, long>();

            foreach (var tank in tanks)
            {
                if (tank.Tier == 0)
                {
                    continue;
                }
                if (battlesCountByTier.ContainsKey(tank.Tier))
                {
                    battlesCountByTier[tank.Tier] += tank.Battles;
                }
                else
                {
                    battlesCountByTier.Add(tank.Tier, tank.Battles);
                }
            }

            var values = new int[10];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = 0;
            }

            for (int i = 1; i < 11; i++)
            {
                if(battlesCountByTier.ContainsKey(i))
                {
                    values[i - 1] = Convert.ToInt32(battlesCountByTier[i]);
                }
            }

            var chartData = new List<ChartByTierItem>();
            for (int i = 0; i < values.Length; i++)
            {
                chartData.Add(new ((i + 1).RomanNumber(), values[i], "#9FE3CE"));
            }

            await _jsRuntime.InvokeVoidAsync("eChartsInterop.BuildBarChartByTier", elementId, _localize.GetString("Battles by tier").Value, chartData.ToArray());
        }

        public async Task BuildBarChartWinRatesByTier(string elementId, IEnumerable<ITank> tanks)
        {
            var battlesCountByTier = new Dictionary<int, long>();
            var winsCountByTier = new Dictionary<int, long>();

            foreach (var tank in tanks)
            {
                if (tank.Tier == 0)
                {
                    continue;
                }
                if (battlesCountByTier.ContainsKey(tank.Tier))
                {
                    battlesCountByTier[tank.Tier] += tank.Battles;
                }
                else
                {
                    battlesCountByTier.Add(tank.Tier, tank.Battles);
                }
                if (winsCountByTier.ContainsKey(tank.Tier))
                {
                    winsCountByTier[tank.Tier] += tank.Wins;
                }
                else
                {
                    winsCountByTier.Add(tank.Tier, tank.Wins);
                }
            }

            var values = new int[10];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = 0;
            }

            for (int i = 1; i < 11; i++)
            {
                if (battlesCountByTier.ContainsKey(i))
                {
                    values[i - 1] = Convert.ToInt32(100 * winsCountByTier[i] /
                                            battlesCountByTier[i]);
                }
            }

            var chartData = new List<ChartByTierItem>();
            for (int i = 0; i < values.Length; i++)
            {
                chartData.Add(new((i + 1).RomanNumber(), values[i], values[i].ScaleColor()));
            }

            await _jsRuntime.InvokeVoidAsync("eChartsInterop.BuildBarChartByTier", elementId, _localize.GetString("Win rate by tier").Value, chartData.ToArray());
        }

        public async Task BuildBarChartAvgDmgByTier(string elementId, IEnumerable<ITank> tanks)
        {
            var battlesCountByTier = new Dictionary<int, long>();
            var dmgCountByTier = new Dictionary<int, long>();

            foreach (var tank in tanks)
            {
                if (tank.Tier == 0)
                {
                    continue;
                }
                if (battlesCountByTier.ContainsKey(tank.Tier))
                {
                    battlesCountByTier[tank.Tier] += tank.Battles;
                }
                else
                {
                    battlesCountByTier.Add(tank.Tier, tank.Battles);
                }
                if (dmgCountByTier.ContainsKey(tank.Tier))
                {
                    dmgCountByTier[tank.Tier] += tank.DamageDealt;
                }
                else
                {
                    dmgCountByTier.Add(tank.Tier, tank.DamageDealt);
                }
            }

            var values = new int[10];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = 0;
            }

            for (int i = 1; i < 11; i++)
            {
                if (battlesCountByTier.ContainsKey(i))
                {
                    values[i - 1] = Convert.ToInt32(dmgCountByTier[i] /
                                            battlesCountByTier[i]);
                }
            }

            var chartData = new List<ChartByTierItem>();
            for (int i = 0; i < values.Length; i++)
            {
                chartData.Add(new((i + 1).RomanNumber(), values[i], "#D98D8B"));
            }

            await _jsRuntime.InvokeVoidAsync("eChartsInterop.BuildBarChartByTier", elementId, _localize.GetString("Avg damage by tier").Value, chartData.ToArray());
        }

        public async Task BuildStackedBarChart(string elementId)
        {
            await _jsRuntime.InvokeVoidAsync("eChartsInterop.BuildStackedBarChart", elementId);
        }

    }
}