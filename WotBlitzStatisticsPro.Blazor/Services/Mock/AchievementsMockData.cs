using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Services.Mock
{
    public static class AchievementsMockData
    {
        public static Player_AccountMedals_AccountAchievementsResponse GetStaticAchievements()
        {
            var jObject = JObject.Parse(_json);
            var accountId = jObject["accountId"]?.Value<long>();
            var sectionTokens = jObject["sections"];

            var sections = new List<IPlayer_AccountMedals_Sections>();
            if (sectionTokens != null)
            {
                foreach (var sectionToken in sectionTokens)
                {
                    var medalTokens = sectionToken?["medals"];
                    var medals = new List<IPlayer_AccountMedals_Sections_Medals>();
                    if (medalTokens != null)
                    {
                        foreach (var medalToken in medalTokens)
                        {
                            medals.Add(new Player_AccountMedals_Sections_Medals_Achievement(
                                medalToken["id"].Value<string>(),
                                medalToken["name"]?.Value<string>(),
                                medalToken["medalType"]?.Value<string>(),
                                medalToken["condition"]?.Value<string>(),
                                medalToken["description"]?.Value<string>(),
                                medalToken["achievementValue"].Value<int>(),
                                medalToken["maxSeriesValue"]?.Value<int?>(),
                                medalToken["image"]?.Value<string>(),
                                medalToken["imageBig"]?.Value<string>(),
                                medalToken["order"]?.Value<long?>(),
                                medalToken["sectionId"]?.Value<string>()
                                ));
                        }
                        sections.Add(new Player_AccountMedals_Sections_AchievementSection(
                            sectionToken["sectionId"].Value<string>(),
                            sectionToken["order"].Value<int>(),
                            sectionToken["name"].Value<string>(),
                            medals
                            ));
                    }
                }
            }

            return new Player_AccountMedals_AccountAchievementsResponse(accountId!.Value, sections);
        }

        private static string _json = @"
{
""accountId"": 90277267,
""sections"": [
    {
    ""sectionId"": ""platoon"",
    ""order"": 5,
    ""name"": ""ВЗВОДНЫЕ НАГРАДЫ"",
    ""medals"": [
        {
        ""id"": ""punisher"",
        ""name"": ""«Мститель»"",
        ""medalType"": null,
        ""condition"": ""• IV степени – 1\n• III степени – 10\n• II степени – 100\n• I степени – 1 000"",
        ""description"": ""Ликвидировать противника, уничтожившего игрока вашего взвода."",
        ""achievementValue"": 4,
        ""maxSeriesValue"": 1,
        ""image"": null,
        ""imageBig"": null,
        ""order"": 1057,
        ""sectionId"": ""platoon""
        },
        {
        ""id"": ""jointVictory"",
        ""name"": ""«Совместная победа»"",
        ""medalType"": null,
        ""condition"": ""• IV степени – 1\n• III степени – 10\n• II степени – 100\n• I степени – 1 000"",
        ""description"": ""За количество победных боёв в составе взвода."",
        ""achievementValue"": 3,
        ""maxSeriesValue"": 23,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/jointVictory3.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/jointVictory3.png"",
        ""order"": 1055,
        ""sectionId"": ""platoon""
        },
        {
        ""id"": ""medalCrucialContribution"",
        ""name"": ""«Решающий вклад» (medalCrucialContribution)"",
        ""medalType"": null,
        ""condition"": ""• Выдаётся обоим игрокам взвода."",
        ""description"": ""Взвод должен уничтожить не менее 6 танков противника."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalCrucialContribution.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalCrucialContribution.png"",
        ""order"": 400,
        ""sectionId"": ""platoon""
        },
        {
        ""id"": ""medalBrothersInArms"",
        ""name"": ""«Братья по оружию» (medalBrothersInArms)"",
        ""medalType"": null,
        ""condition"": ""• Взвод должен выжить в бою.\n• Выдаётся обоим игрокам взвода."",
        ""description"": ""Каждый игрок взвода должен уничтожить не менее 2 танков противника."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalBrothersInArms.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalBrothersInArms.png"",
        ""order"": 401,
        ""sectionId"": ""platoon""
        }
    ]
    },
    {
    ""sectionId"": ""title"",
    ""order"": 1,
    ""name"": ""ПОЧЁТНЫЕ ЗВАНИЯ"",
    ""medals"": [
        {
        ""id"": ""armorPiercer"",
        ""name"": ""«Бронебойщик» (armorPiercer)"",
        ""medalType"": null,
        ""condition"": ""• Серия прерывается непробитием, рикошетом или промахом.\n• Серия ведётся для каждого танка отдельно и может продолжиться в следующем бою на этом же танке.\n• В общий зачёт идёт максимальная серия."",
        ""description"": ""Пробить броню противника не менее 10 раз подряд."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": 61,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/armorPiercer.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/armorPiercer.png"",
        ""order"": 1014,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""mechanicEngineer6"",
        ""name"": ""«Инженер-механик: Япония» (mechanicEngineer6)"",
        ""medalType"": null,
        ""condition"": ""• Неисследованные модули не являются препятствием."",
        ""description"": ""Исследовать все танки в Дереве танков Японии."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/mechanicEngineer6.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/mechanicEngineer6.png"",
        ""order"": 1206,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""kamikaze"",
        ""name"": ""«Камикадзе» (kamikaze)"",
        ""medalType"": null,
        ""condition"": ""• Танк противника должен быть выше уровнем.\n• Не более одной награды на игрока за бой."",
        ""description"": ""Уничтожить противника тараном."",
        ""achievementValue"": 24,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/kamikaze.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/kamikaze.png"",
        ""order"": 703,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""sinai"",
        ""name"": ""«Лев Синая» (sinai)"",
        ""medalType"": null,
        ""condition"": ""\t• ИС\n\t• ИС-3\n\t• ИС-3 Защитник\n\t• ИС-4\n\t• ИС-6\n\t• ИС-6 Бесстрашный\n\t• ИС-7\n\t• ИС-8\n\t• ИСУ-152\n\t• Объект 252У\n\t• Объект 263\n\t• Объект 268\n\t• Объект 704\n\t• ИСУ-122С\n\t• ИС-2 (1945)\n\t• ИС-2Ш\n\t• ИС-5\n\t• ИСУ-130\n\t• IS-2 Pravda SP\n\t• IS-2\n\n• Засчитывается сумма результатов по всем танкам.\n• В общем зачёте повторно полученные награды суммируются."",
        ""description"": ""Уничтожить 100 танков ИС или танков на их базе.\nЗасчитываются:"",
        ""achievementValue"": 11,
        ""maxSeriesValue"": 1188,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/sinai.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/sinai.png"",
        ""order"": 1013,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""titleSniper"",
        ""name"": ""«Стрелок» (titleSniper)"",
        ""medalType"": null,
        ""condition"": ""• Серия прерывается промахом.\n• Серия ведётся для каждого танка отдельно и может продолжиться в следующем бою на этом же танке.\n• В общий зачёт идёт максимальная серия."",
        ""description"": ""Попасть в противника не менее 10 раз подряд."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": 96,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/titleSniper.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/titleSniper.png"",
        ""order"": 1015,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""beasthunter"",
        ""name"": ""«Зверобой» (beasthunter)"",
        ""medalType"": null,
        ""condition"": ""\t• Tiger II\n\t• Panther\n\t• Panther II\n\t• Panther/M10\n\t• Panther 8,8\n\t• Jagdpanther\n\t• Jagdpanther II\n\t• Tiger (P)\n\t• Tiger I\n\t• Jagdtiger\n\t• Jagdtiger 8,8\n\t• Новогодний Jagdtiger 8,8\n\t• Leopard Prototyp A\n\t• Leopard 1\n\t• Löwe\n\t• Tiger Kuromorimine SP\n\t• VK 16.02 Leopard\n\t• Tiger 131\n\n• Засчитывается сумма результатов по всем танкам.\n• В общем зачёте повторно полученные награды суммируются."",
        ""description"": ""Уничтожить 100 танков «семейства кошачьих».\nЗасчитываются:"",
        ""achievementValue"": 7,
        ""maxSeriesValue"": 781,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/beasthunter.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/beasthunter.png"",
        ""order"": 1012,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""tankExpert3"",
        ""name"": ""«Эксперт: Китай» (tankExpert3)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Уничтожить все танки из Дерева танков Китая, исключая премиум и коллекционные."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert3.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert3.png"",
        ""order"": 1303,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""tankExpert2"",
        ""name"": ""«Эксперт: США» (tankExpert2)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Уничтожить все танки из Дерева танков США, исключая премиум и коллекционные."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert2.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert2.png"",
        ""order"": 1302,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""tankExpert1"",
        ""name"": ""«Эксперт: Германия» (tankExpert1)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Уничтожить все танки из Дерева танков Германии, исключая премиум и коллекционные."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert1.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert1.png"",
        ""order"": 1301,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""tankExpert0"",
        ""name"": ""«Эксперт: СССР» (tankExpert0)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Уничтожить все танки из Дерева танков СССР, исключая премиум и коллекционные."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert0.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert0.png"",
        ""order"": 1300,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""tankExpert6"",
        ""name"": ""«Эксперт: Япония» (tankExpert6)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Уничтожить все танки из Дерева танков Японии, исключая премиум и коллекционные."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert6.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert6.png"",
        ""order"": 1306,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""tankExpert5"",
        ""name"": ""«Эксперт: Великобритания» (tankExpert5)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Уничтожить все танки из Дерева танков Великобритании, исключая премиум и коллекционные."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert5.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert5.png"",
        ""order"": 1305,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""tankExpert4"",
        ""name"": ""«Эксперт: Франция» (tankExpert4)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Уничтожить все танки из Дерева танков Франции, исключая премиум и коллекционные."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert4.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert4.png"",
        ""order"": 1304,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""handOfDeath"",
        ""name"": ""«Коса Смерти» (handOfDeath)"",
        ""medalType"": null,
        ""condition"": ""• Серия ведётся для каждого танка отдельно и может продолжиться в следующем бою на этом же танке.\n• В общий зачёт идёт максимальная серия.\n• Выдаётся в момент окончания очередной рекордной серии."",
        ""description"": ""Уничтожить подряд не менее 3 танков противника, затратив на вторую и последующие по одному снаряду."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": 5,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/handOfDeath.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/handOfDeath.png"",
        ""order"": 1002,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""invincible"",
        ""name"": ""«Неуязвимый» (invincible)"",
        ""medalType"": null,
        ""condition"": ""• Серия ведётся для каждого танка отдельно и может продолжиться в следующем бою на этом же танке.\n• В общий зачёт идёт максимальная серия."",
        ""description"": ""Не получить урона в 5 боях подряд."",
        ""achievementValue"": 0,
        ""maxSeriesValue"": 4,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/invincible.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/invincible.png"",
        ""order"": 702,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""tankExpert"",
        ""name"": ""«Эксперт» (tankExpert)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Уничтожить все танки из Дерева танков каждой нации, исключая премиум и коллекционные."",
        ""achievementValue"": 0,
        ""maxSeriesValue"": 255,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert.png"",
        ""order"": 1101,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""diehard"",
        ""name"": ""«Живучий» (diehard)"",
        ""medalType"": null,
        ""condition"": ""• Серия ведётся для каждого танка отдельно и может продолжиться в следующем бою на этом же танке.\n• В общий зачёт идёт максимальная серия."",
        ""description"": ""Выжить в 10 боях подряд на одном танке."",
        ""achievementValue"": 0,
        ""maxSeriesValue"": 8,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/diehard.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/diehard.png"",
        ""order"": 106,
        ""sectionId"": ""title""
        },
        {
        ""id"": ""pattonValley"",
        ""name"": ""«Долина Паттонов» (pattonValley)"",
        ""medalType"": null,
        ""condition"": ""\t• M46 Patton\n\t• M48 Patton\n\t• M60\n\n• Засчитывается сумма результатов по всем танкам.\n• В общем зачёте повторно полученные награды суммируются."",
        ""description"": ""Уничтожить 100 танков Patton.\nЗасчитываются:"",
        ""achievementValue"": 0,
        ""maxSeriesValue"": 25,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/pattonValley.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/pattonValley.png"",
        ""order"": 1011,
        ""sectionId"": ""title""
        }
    ]
    },
    {
    ""sectionId"": ""commemorative"",
    ""order"": 3,
    ""name"": ""ПАМЯТНЫЕ ЗНАКИ"",
    ""medals"": [
        {
        ""id"": ""cadet"",
        ""name"": ""«Кадет» (cadet)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Пройти боевое обучение."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/cadet.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/cadet.png"",
        ""order"": 1051,
        ""sectionId"": ""commemorative""
        },
        {
        ""id"": ""firstBlood"",
        ""name"": ""«Первая кровь» (firstBlood)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Уничтожить 1 танк противника."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/firstBlood.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/firstBlood.png"",
        ""order"": 1052,
        ""sectionId"": ""commemorative""
        },
        {
        ""id"": ""firstVictory"",
        ""name"": ""«Первая победа» (firstVictory)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Победить в первом обычном бою с другими игроками."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/firstVictory.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/firstVictory.png"",
        ""order"": 1053,
        ""sectionId"": ""commemorative""
        },
        {
        ""id"": ""huntsman"",
        ""name"": ""«Егерь» (huntsman)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Уничтожить все лёгкие танки противника в одном бою, но не менее 3."",
        ""achievementValue"": 4,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/huntsman.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/huntsman.png"",
        ""order"": 300,
        ""sectionId"": ""commemorative""
        },
        {
        ""id"": ""ironMan"",
        ""name"": ""«Невозмутимый» (ironMan)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Получить подряд не менее 10 рикошетов и непробитий от противника."",
        ""achievementValue"": 24,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/ironMan.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/ironMan.png"",
        ""order"": 1007,
        ""sectionId"": ""commemorative""
        },
        {
        ""id"": ""sturdy"",
        ""name"": ""«Спартанец» (sturdy)"",
        ""medalType"": null,
        ""condition"": ""• Выжить в бою."",
        ""description"": ""Получить рикошет или непробитие от противника при прочности танка менее 10%."",
        ""achievementValue"": 82,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/sturdy.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/sturdy.png"",
        ""order"": 1008,
        ""sectionId"": ""commemorative""
        }
    ]
    },
    {
    ""sectionId"": ""step"",
    ""order"": 4,
    ""name"": ""ЭТАПНЫЕ НАГРАДЫ"",
    ""medals"": [
        {
        ""id"": ""medalCarius"",
        ""name"": ""Медаль Кариуса"",
        ""medalType"": null,
        ""condition"": ""• IV степени – 10\n• III степени – 100\n• II степени – 1 000\n• I степени – 10 000"",
        ""description"": ""За количество уничтоженных танков противника."",
        ""achievementValue"": 2,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalCarius2.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalCarius2.png"",
        ""order"": 1401,
        ""sectionId"": ""step""
        },
        {
        ""id"": ""medalEkins"",
        ""name"": ""Медаль Экинса"",
        ""medalType"": null,
        ""condition"": ""• IV степени – 3\n• III степени – 30\n• II степени – 300\n• I степени – 3 000"",
        ""description"": ""За количество уничтоженных танков противника VIII–X уровней."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalEkins1.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalEkins1.png"",
        ""order"": 1402,
        ""sectionId"": ""step""
        },
        {
        ""id"": ""medalKay"",
        ""name"": ""Медаль Кея"",
        ""medalType"": null,
        ""condition"": ""• IV степени – 1\n• III степени – 10\n• II степени – 100\n• I степени – 1 000"",
        ""description"": ""За получение статуса «Герой битвы»."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": 1700,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalKay1.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalKay1.png"",
        ""order"": 1400,
        ""sectionId"": ""step""
        },
        {
        ""id"": ""medalLeClerc"",
        ""name"": ""Медаль Леклерка"",
        ""medalType"": null,
        ""condition"": ""• Победить в бою.\n• Засчитываются все очки захвата, набранные за один бой, за исключением очков захвата, полученных в Превосходстве.\n\n• IV степени – 30\n• III степени – 300\n• II степени – 3 000\n• I степени – 30 000"",
        ""description"": ""За суммарное количество очков захвата базы."",
        ""achievementValue"": 2,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalLeClerc2.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalLeClerc2.png"",
        ""order"": 1406,
        ""sectionId"": ""step""
        },
        {
        ""id"": ""medalAbrams"",
        ""name"": ""Медаль Абрамса"",
        ""medalType"": null,
        ""condition"": ""• IV степени – 10\n• III степени – 100\n• II степени – 1 000\n• I степени – 10 000"",
        ""description"": ""За количество победных боёв, в которых игрок остался жив."",
        ""achievementValue"": 2,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalAbrams2.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalAbrams2.png"",
        ""order"": 1405,
        ""sectionId"": ""step""
        },
        {
        ""id"": ""medalPoppel"",
        ""name"": ""Медаль Попеля"",
        ""medalType"": null,
        ""condition"": ""• IV степени – 20\n• III степени – 200\n• II степени – 2 000\n• I степени – 20 000"",
        ""description"": ""За количество обнаруженных танков противника."",
        ""achievementValue"": 2,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalPoppel2.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalPoppel2.png"",
        ""order"": 1404,
        ""sectionId"": ""step""
        },
        {
        ""id"": ""medalSupremacy"",
        ""name"": ""Медаль Превосходство"",
        ""medalType"": null,
        ""condition"": ""• Накопительная медаль.\n• Засчитываются все очки победы, набранные в Превосходстве.\n\n• IV степени – 10 000\n• III степени – 100 000\n• II степени – 1 000 000\n• I степени – 10 000 000"",
        ""description"": ""За очки победы в Превосходстве."",
        ""achievementValue"": 3,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalSupremacy3.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalSupremacy3.png"",
        ""order"": 1408,
        ""sectionId"": ""step""
        },
        {
        ""id"": ""medalLavrinenko"",
        ""name"": ""Медаль Лавриненко"",
        ""medalType"": null,
        ""condition"": ""• Засчитывается не более 100 очков за бой.\n• Не засчитываются сбитые очки захвата точек, заработанные в Превосходстве\n\n• IV степени – 30\n• III степени – 300\n• II степени – 3 000\n• I степени – 30 000"",
        ""description"": ""За суммарное количество сбитых очков захвата базы."",
        ""achievementValue"": 2,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalLavrinenko2.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalLavrinenko2.png"",
        ""order"": 1407,
        ""sectionId"": ""step""
        },
        {
        ""id"": ""medalKnispel"",
        ""name"": ""Медаль Книспеля"",
        ""medalType"": null,
        ""condition"": ""• IV степени – 10 000\n• III степени – 100 000\n• II степени – 1 000 000\n• I степени – 10 000 000"",
        ""description"": ""За суммарное количество нанесённого и полученного урона."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalKnispel1.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalKnispel1.png"",
        ""order"": 1403,
        ""sectionId"": ""step""
        }
    ]
    },
    {
    ""sectionId"": ""battle"",
    ""order"": 0,
    ""name"": ""«ГЕРОЙ БИТВЫ»"",
    ""medals"": [
        {
        ""id"": ""invader"",
        ""name"": ""«Захватчик» (invader)"",
        ""medalType"": null,
        ""condition"": ""• Выиграть бой захватом базы.\n• Засчитываются только очки, обеспечившие захват.\n• Не засчитываются очки захвата точек, полученные в Превосходстве."",
        ""description"": ""Получить наибольшее количество очков захвата базы, но не менее 80."",
        ""achievementValue"": 6,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/invader.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/invader.png"",
        ""order"": 203,
        ""sectionId"": ""battle""
        },
        {
        ""id"": ""markOfMasteryII"",
        ""name"": ""Знак классности \n«2 степень» (markOfMasteryII)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Присваивается игроку за мастерство владения танком. Для получения награды необходимо заработать больше опыта за бой, чем средний максимальный опыт за неделю у 80% игроков на данном танке."",
        ""achievementValue"": 853,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/markOfMasteryII.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/markOfMasteryII.png"",
        ""order"": 2,
        ""sectionId"": ""battle""
        },
        {
        ""id"": ""markOfMasteryI"",
        ""name"": ""Знак классности \n«1 степень» (markOfMasteryI)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Присваивается игроку за мастерство владения танком. Для получения награды необходимо заработать больше опыта за бой, чем средний максимальный опыт за неделю у 95% игроков на данном танке."",
        ""achievementValue"": 203,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/markOfMasteryI.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/markOfMasteryI.png"",
        ""order"": 1,
        ""sectionId"": ""battle""
        },
        {
        ""id"": ""defender"",
        ""name"": ""«Защитник» (defender)"",
        ""medalType"": null,
        ""condition"": ""• При равном количестве сбитых очков награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой.\n• Не засчитываются очки захвата точек, полученные в Превосходстве."",
        ""description"": ""Защитить базу, сбив наибольшее количество очков захвата, но не менее 70."",
        ""achievementValue"": 23,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/defender.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/defender.png"",
        ""order"": 202,
        ""sectionId"": ""battle""
        },
        {
        ""id"": ""markOfMasteryIII"",
        ""name"": ""Знак классности \n«3 степень» (markOfMasteryIII)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Присваивается игроку за мастерство владения танком. Для получения награды необходимо заработать больше опыта за бой, чем средний максимальный опыт за неделю у 50% игроков на данном танке."",
        ""achievementValue"": 1783,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/markOfMasteryIII.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/markOfMasteryIII.png"",
        ""order"": 3,
        ""sectionId"": ""battle""
        },
        {
        ""id"": ""supporter"",
        ""name"": ""«Поддержка» (supporter)"",
        ""medalType"": null,
        ""condition"": ""• Засчитываются цели, которые впоследствии были уничтожены другими игроками или самоуничтожились.\n• Рикошеты и непробития не учитываются.\n• При равном количестве повреждённых танков награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой."",
        ""description"": ""Нанести урон или сбить гусеницу наибольшему количеству танков противника, но не менее чем 4."",
        ""achievementValue"": 823,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/supporter.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/supporter.png"",
        ""order"": 6,
        ""sectionId"": ""battle""
        },
        {
        ""id"": ""steelwall"",
        ""name"": ""«Стальная cтена» (steelwall)"",
        ""medalType"": null,
        ""condition"": ""• Выжить в бою.\n• При равном количестве полученного потенциального урона награждается игрок, получивший больше попаданий.\n• При равном количестве полученного потенциального урона и попаданий награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой."",
        ""description"": ""Получить не менее 1 000 единиц потенциального урона и не менее 11 попаданий."",
        ""achievementValue"": 129,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/steelwall.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/steelwall.png"",
        ""order"": 201,
        ""sectionId"": ""battle""
        },
        {
        ""id"": ""mainGun"",
        ""name"": ""«Основной калибр» (mainGun)"",
        ""medalType"": null,
        ""condition"": ""• Нанесённый урон должен составлять не менее 35% от суммарной прочности танков противника и не менее 1000 единиц.\n• При равном количестве нанесённого урона награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой."",
        ""description"": ""Нанести наибольшее количество урона за бой."",
        ""achievementValue"": 255,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/mainGun.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/mainGun.png"",
        ""order"": 5,
        ""sectionId"": ""battle""
        },
        {
        ""id"": ""warrior"",
        ""name"": ""«Воин» (warrior)"",
        ""medalType"": null,
        ""condition"": ""• При равном счёте награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой."",
        ""description"": ""Уничтожить наибольшее количество танков противника, но не менее 4."",
        ""achievementValue"": 236,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/warrior.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/warrior.png"",
        ""order"": 4,
        ""sectionId"": ""battle""
        },
        {
        ""id"": ""camper"",
        ""name"": ""«Танкист-снайпер» (camper)"",
        ""medalType"": null,
        ""condition"": ""• Произвести не менее 8 выстрелов.\n• Не менее 80% попаданий должны быть с нанесением урона.\n• Учитывается урон танкам противника и повреждения модулей.\n• Общая точность стрельбы за бой должна быть не менее 85%.\n• Нанесённый урон должен превышать количество очков прочности танка игрока и быть не менее 1000 единиц.\n• При равном количестве нанесённого урона награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой."",
        ""description"": ""Нанести наибольшее количество урона за бой с дистанции не менее 250 м."",
        ""achievementValue"": 7,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/camper.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/camper.png"",
        ""order"": 7,
        ""sectionId"": ""battle""
        },
        {
        ""id"": ""markOfMastery"",
        ""name"": ""Знак классности \n«Мастер» (markOfMastery)"",
        ""medalType"": null,
        ""condition"": null,
        ""description"": ""Присваивается игроку за мастерство владения танком. Для получения награды необходимо заработать больше опыта за бой, чем средний максимальный опыт за неделю у 99% игроков на данном танке."",
        ""achievementValue"": 76,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/markOfMastery.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/markOfMastery.png"",
        ""order"": 0,
        ""sectionId"": ""battle""
        },
        {
        ""id"": ""scout"",
        ""name"": ""«Разведчик» (scout)"",
        ""medalType"": null,
        ""condition"": ""• Победить в бою.\n• Выдаётся только одна награда за бой."",
        ""description"": ""Обнаружить наибольшее количество танков противника, но не менее 5."",
        ""achievementValue"": 151,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/scout.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/scout.png"",
        ""order"": 204,
        ""sectionId"": ""battle""
        },
        {
        ""id"": ""evileye"",
        ""name"": ""«Дозорный» (evileye)"",
        ""medalType"": null,
        ""condition"": ""• Засчитываются цели, разведданные по которым в момент их повреждения передавал только один игрок.\n• При равном количестве повреждённых танков награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой."",
        ""description"": ""Предоставить разведданные, по которым союзники повредят не менее 3 танков противника."",
        ""achievementValue"": 70,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/evileye.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/evileye.png"",
        ""order"": 200,
        ""sectionId"": ""battle""
        }
    ]
    },
    {
    ""sectionId"": ""epic"",
    ""order"": 2,
    ""name"": ""ЭПИЧЕСКИЕ МЕДАЛИ"",
    ""medals"": [
        {
        ""id"": ""medalHalonen"",
        ""name"": ""Медаль Халонена (medalHalonen)"",
        ""medalType"": null,
        ""condition"": ""• Уничтоженные танки должны превосходить ПТ-САУ игрока как минимум на 1 уровень."",
        ""description"": ""Уничтожить не менее 3 танков противника в одном бою, управляя ПТ-САУ."",
        ""achievementValue"": 3,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalHalonen.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalHalonen.png"",
        ""order"": 606,
        ""sectionId"": ""epic""
        },
        {
        ""id"": ""medalOskin"",
        ""name"": ""Медаль Оськина (medalOskin)"",
        ""medalType"": null,
        ""condition"": ""• Уничтоженные танки должны превосходить танк игрока как минимум на 1 уровень."",
        ""description"": ""Уничтожить 3 танка противника в одном бою, управляя средним танком."",
        ""achievementValue"": 6,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalOskin.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalOskin.png"",
        ""order"": 603,
        ""sectionId"": ""epic""
        },
        {
        ""id"": ""medalRadleyWalters"",
        ""name"": ""Медаль Рэдли-Уолтерса (medalRadleyWalters)"",
        ""medalType"": null,
        ""condition"": ""• Управлять танком V уровня и выше."",
        ""description"": ""Уничтожить 5 танков противника в одном бою."",
        ""achievementValue"": 35,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalRadleyWalters.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalRadleyWalters.png"",
        ""order"": 102,
        ""sectionId"": ""epic""
        },
        {
        ""id"": ""medalLehvaslaiho"",
        ""name"": ""Медаль Лехвеслайхо (medalLehvaslaiho)"",
        ""medalType"": null,
        ""condition"": ""• Уничтоженные танки должны превосходить танк игрока как минимум на 1 уровень."",
        ""description"": ""Уничтожить 2 танка противника в одном бою, управляя средним танком."",
        ""achievementValue"": 50,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalLehvaslaiho.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalLehvaslaiho.png"",
        ""order"": 604,
        ""sectionId"": ""epic""
        },
        {
        ""id"": ""medalOrlik"",
        ""name"": ""Медаль Орлика (medalOrlik)"",
        ""medalType"": null,
        ""condition"": ""• Уничтоженные танки должны превосходить танк игрока как минимум на 1 уровень."",
        ""description"": ""Уничтожить не менее 3 танков противника в одном бою, управляя лёгким танком."",
        ""achievementValue"": 4,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalOrlik.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalOrlik.png"",
        ""order"": 605,
        ""sectionId"": ""epic""
        },
        {
        ""id"": ""medalNikolas"",
        ""name"": ""Медаль Николса (medalNikolas)"",
        ""medalType"": null,
        ""condition"": ""• Уничтоженные танки должны превосходить танк игрока как минимум на 1 уровень."",
        ""description"": ""Уничтожить не менее 4 танков противника в одном бою, управляя средним танком."",
        ""achievementValue"": 1,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalNikolas.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalNikolas.png"",
        ""order"": 602,
        ""sectionId"": ""epic""
        },
        {
        ""id"": ""medalKolobanov"",
        ""name"": ""Медаль Колобанова (medalKolobanov)"",
        ""medalType"": null,
        ""condition"": ""• Выжить в бою."",
        ""description"": ""Победить в бою, оставшись в одиночку против 3 и более танков."",
        ""achievementValue"": 7,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalKolobanov.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalKolobanov.png"",
        ""order"": 600,
        ""sectionId"": ""epic""
        },
        {
        ""id"": ""medalLafayettePool"",
        ""name"": ""Медаль Пула (medalLafayettePool)"",
        ""medalType"": null,
        ""condition"": ""• Управлять танком V уровня и выше."",
        ""description"": ""Уничтожить 6 танков противника в одном бою."",
        ""achievementValue"": 7,
        ""maxSeriesValue"": null,
        ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalLafayettePool.png"",
        ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalLafayettePool.png"",
        ""order"": 101,
        ""sectionId"": ""epic""
        }
    ]
    }
  ]
}
";
    }
}