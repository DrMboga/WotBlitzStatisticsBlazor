namespace WotBlitzStatisticsPro.Blazor.Services.Mock
{
    public class AchievementsMockData
    {


        private string _json = @"
{
    ""data"": {
      ""accountAchievements"": {
        ""accountId"": 90277267,
        ""achievementSections"": [
          {
            ""sectionId"": ""platoon"",
            ""name"": ""ВЗВОДНЫЕ НАГРАДЫ"",
            ""order"": 5,
            ""achievements"": [
              {
                ""id"": ""punisher"",
                ""sectionId"": ""platoon"",
                ""name"": ""«Мститель»"",
                ""condition"": ""• IV степени – 1\n• III степени – 10\n• II степени – 100\n• I степени – 1 000"",
                ""description"": ""Ликвидировать противника, уничтожившего игрока вашего взвода."",
                ""achievementValue"": 4,
                ""maxSeriesValue"": 1,
                ""image"": null,
                ""imageBig"": null,
                ""order"": 1057
              },
              {
                ""id"": ""jointVictory"",
                ""sectionId"": ""platoon"",
                ""name"": ""«Совместная победа»"",
                ""condition"": ""• IV степени – 1\n• III степени – 10\n• II степени – 100\n• I степени – 1 000"",
                ""description"": ""За количество победных боёв в составе взвода."",
                ""achievementValue"": 3,
                ""maxSeriesValue"": 23,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/jointVictory3.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/jointVictory3.png"",
                ""order"": 1055
              },
              {
                ""id"": ""medalCrucialContribution"",
                ""sectionId"": ""platoon"",
                ""name"": ""«Решающий вклад» (medalCrucialContribution)"",
                ""condition"": ""• Выдаётся обоим игрокам взвода."",
                ""description"": ""Взвод должен уничтожить не менее 6 танков противника."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalCrucialContribution.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalCrucialContribution.png"",
                ""order"": 400
              },
              {
                ""id"": ""medalBrothersInArms"",
                ""sectionId"": ""platoon"",
                ""name"": ""«Братья по оружию» (medalBrothersInArms)"",
                ""condition"": ""• Взвод должен выжить в бою.\n• Выдаётся обоим игрокам взвода."",
                ""description"": ""Каждый игрок взвода должен уничтожить не менее 2 танков противника."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalBrothersInArms.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalBrothersInArms.png"",
                ""order"": 401
              }
            ]
          },
          {
            ""sectionId"": ""title"",
            ""name"": ""ПОЧЁТНЫЕ ЗВАНИЯ"",
            ""order"": 1,
            ""achievements"": [
              {
                ""id"": ""armorPiercer"",
                ""sectionId"": ""title"",
                ""name"": ""«Бронебойщик» (armorPiercer)"",
                ""condition"": ""• Серия прерывается непробитием, рикошетом или промахом.\n• Серия ведётся для каждого танка отдельно и может продолжиться в следующем бою на этом же танке.\n• В общий зачёт идёт максимальная серия."",
                ""description"": ""Пробить броню противника не менее 10 раз подряд."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": 61,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/armorPiercer.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/armorPiercer.png"",
                ""order"": 1014
              },
              {
                ""id"": ""mechanicEngineer6"",
                ""sectionId"": ""title"",
                ""name"": ""«Инженер-механик: Япония» (mechanicEngineer6)"",
                ""condition"": ""• Неисследованные модули не являются препятствием."",
                ""description"": ""Исследовать все танки в Дереве танков Японии."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/mechanicEngineer6.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/mechanicEngineer6.png"",
                ""order"": 1206
              },
              {
                ""id"": ""kamikaze"",
                ""sectionId"": ""title"",
                ""name"": ""«Камикадзе» (kamikaze)"",
                ""condition"": ""• Танк противника должен быть выше уровнем.\n• Не более одной награды на игрока за бой."",
                ""description"": ""Уничтожить противника тараном."",
                ""achievementValue"": 24,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/kamikaze.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/kamikaze.png"",
                ""order"": 703
              },
              {
                ""id"": ""sinai"",
                ""sectionId"": ""title"",
                ""name"": ""«Лев Синая» (sinai)"",
                ""condition"": ""\t• ИС\n\t• ИС-3\n\t• ИС-3 Защитник\n\t• ИС-4\n\t• ИС-6\n\t• ИС-6 Бесстрашный\n\t• ИС-7\n\t• ИС-8\n\t• ИСУ-152\n\t• Объект 252У\n\t• Объект 263\n\t• Объект 268\n\t• Объект 704\n\t• ИСУ-122С\n\t• ИС-2 (1945)\n\t• ИС-2Ш\n\t• ИС-5\n\t• ИСУ-130\n\t• IS-2 Pravda SP\n\t• IS-2\n\n• Засчитывается сумма результатов по всем танкам.\n• В общем зачёте повторно полученные награды суммируются."",
                ""description"": ""Уничтожить 100 танков ИС или танков на их базе.\nЗасчитываются:"",
                ""achievementValue"": 11,
                ""maxSeriesValue"": 1188,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/sinai.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/sinai.png"",
                ""order"": 1013
              },
              {
                ""id"": ""titleSniper"",
                ""sectionId"": ""title"",
                ""name"": ""«Стрелок» (titleSniper)"",
                ""condition"": ""• Серия прерывается промахом.\n• Серия ведётся для каждого танка отдельно и может продолжиться в следующем бою на этом же танке.\n• В общий зачёт идёт максимальная серия."",
                ""description"": ""Попасть в противника не менее 10 раз подряд."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": 96,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/titleSniper.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/titleSniper.png"",
                ""order"": 1015
              },
              {
                ""id"": ""beasthunter"",
                ""sectionId"": ""title"",
                ""name"": ""«Зверобой» (beasthunter)"",
                ""condition"": ""\t• Tiger II\n\t• Panther\n\t• Panther II\n\t• Panther/M10\n\t• Panther 8,8\n\t• Jagdpanther\n\t• Jagdpanther II\n\t• Tiger (P)\n\t• Tiger I\n\t• Jagdtiger\n\t• Jagdtiger 8,8\n\t• Новогодний Jagdtiger 8,8\n\t• Leopard Prototyp A\n\t• Leopard 1\n\t• Löwe\n\t• Tiger Kuromorimine SP\n\t• VK 16.02 Leopard\n\t• Tiger 131\n\n• Засчитывается сумма результатов по всем танкам.\n• В общем зачёте повторно полученные награды суммируются."",
                ""description"": ""Уничтожить 100 танков «семейства кошачьих».\nЗасчитываются:"",
                ""achievementValue"": 7,
                ""maxSeriesValue"": 781,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/beasthunter.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/beasthunter.png"",
                ""order"": 1012
              },
              {
                ""id"": ""tankExpert3"",
                ""sectionId"": ""title"",
                ""name"": ""«Эксперт: Китай» (tankExpert3)"",
                ""condition"": null,
                ""description"": ""Уничтожить все танки из Дерева танков Китая, исключая премиум и коллекционные."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert3.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert3.png"",
                ""order"": 1303
              },
              {
                ""id"": ""tankExpert2"",
                ""sectionId"": ""title"",
                ""name"": ""«Эксперт: США» (tankExpert2)"",
                ""condition"": null,
                ""description"": ""Уничтожить все танки из Дерева танков США, исключая премиум и коллекционные."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert2.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert2.png"",
                ""order"": 1302
              },
              {
                ""id"": ""tankExpert1"",
                ""sectionId"": ""title"",
                ""name"": ""«Эксперт: Германия» (tankExpert1)"",
                ""condition"": null,
                ""description"": ""Уничтожить все танки из Дерева танков Германии, исключая премиум и коллекционные."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert1.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert1.png"",
                ""order"": 1301
              },
              {
                ""id"": ""tankExpert0"",
                ""sectionId"": ""title"",
                ""name"": ""«Эксперт: СССР» (tankExpert0)"",
                ""condition"": null,
                ""description"": ""Уничтожить все танки из Дерева танков СССР, исключая премиум и коллекционные."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert0.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert0.png"",
                ""order"": 1300
              },
              {
                ""id"": ""tankExpert6"",
                ""sectionId"": ""title"",
                ""name"": ""«Эксперт: Япония» (tankExpert6)"",
                ""condition"": null,
                ""description"": ""Уничтожить все танки из Дерева танков Японии, исключая премиум и коллекционные."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert6.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert6.png"",
                ""order"": 1306
              },
              {
                ""id"": ""tankExpert5"",
                ""sectionId"": ""title"",
                ""name"": ""«Эксперт: Великобритания» (tankExpert5)"",
                ""condition"": null,
                ""description"": ""Уничтожить все танки из Дерева танков Великобритании, исключая премиум и коллекционные."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert5.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert5.png"",
                ""order"": 1305
              },
              {
                ""id"": ""tankExpert4"",
                ""sectionId"": ""title"",
                ""name"": ""«Эксперт: Франция» (tankExpert4)"",
                ""condition"": null,
                ""description"": ""Уничтожить все танки из Дерева танков Франции, исключая премиум и коллекционные."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert4.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert4.png"",
                ""order"": 1304
              },
              {
                ""id"": ""handOfDeath"",
                ""sectionId"": ""title"",
                ""name"": ""«Коса Смерти» (handOfDeath)"",
                ""condition"": ""• Серия ведётся для каждого танка отдельно и может продолжиться в следующем бою на этом же танке.\n• В общий зачёт идёт максимальная серия.\n• Выдаётся в момент окончания очередной рекордной серии."",
                ""description"": ""Уничтожить подряд не менее 3 танков противника, затратив на вторую и последующие по одному снаряду."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": 5,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/handOfDeath.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/handOfDeath.png"",
                ""order"": 1002
              },
              {
                ""id"": ""invincible"",
                ""sectionId"": ""title"",
                ""name"": ""«Неуязвимый» (invincible)"",
                ""condition"": ""• Серия ведётся для каждого танка отдельно и может продолжиться в следующем бою на этом же танке.\n• В общий зачёт идёт максимальная серия."",
                ""description"": ""Не получить урона в 5 боях подряд."",
                ""achievementValue"": 0,
                ""maxSeriesValue"": 4,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/invincible.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/invincible.png"",
                ""order"": 702
              },
              {
                ""id"": ""tankExpert"",
                ""sectionId"": ""title"",
                ""name"": ""«Эксперт» (tankExpert)"",
                ""condition"": null,
                ""description"": ""Уничтожить все танки из Дерева танков каждой нации, исключая премиум и коллекционные."",
                ""achievementValue"": 0,
                ""maxSeriesValue"": 255,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/tankExpert.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/tankExpert.png"",
                ""order"": 1101
              },
              {
                ""id"": ""diehard"",
                ""sectionId"": ""title"",
                ""name"": ""«Живучий» (diehard)"",
                ""condition"": ""• Серия ведётся для каждого танка отдельно и может продолжиться в следующем бою на этом же танке.\n• В общий зачёт идёт максимальная серия."",
                ""description"": ""Выжить в 10 боях подряд на одном танке."",
                ""achievementValue"": 0,
                ""maxSeriesValue"": 8,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/diehard.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/diehard.png"",
                ""order"": 106
              },
              {
                ""id"": ""pattonValley"",
                ""sectionId"": ""title"",
                ""name"": ""«Долина Паттонов» (pattonValley)"",
                ""condition"": ""\t• M46 Patton\n\t• M48 Patton\n\t• M60\n\n• Засчитывается сумма результатов по всем танкам.\n• В общем зачёте повторно полученные награды суммируются."",
                ""description"": ""Уничтожить 100 танков Patton.\nЗасчитываются:"",
                ""achievementValue"": 0,
                ""maxSeriesValue"": 25,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/pattonValley.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/pattonValley.png"",
                ""order"": 1011
              }
            ]
          },
          {
            ""sectionId"": ""commemorative"",
            ""name"": ""ПАМЯТНЫЕ ЗНАКИ"",
            ""order"": 3,
            ""achievements"": [
              {
                ""id"": ""cadet"",
                ""sectionId"": ""commemorative"",
                ""name"": ""«Кадет» (cadet)"",
                ""condition"": null,
                ""description"": ""Пройти боевое обучение."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/cadet.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/cadet.png"",
                ""order"": 1051
              },
              {
                ""id"": ""firstBlood"",
                ""sectionId"": ""commemorative"",
                ""name"": ""«Первая кровь» (firstBlood)"",
                ""condition"": null,
                ""description"": ""Уничтожить 1 танк противника."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/firstBlood.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/firstBlood.png"",
                ""order"": 1052
              },
              {
                ""id"": ""firstVictory"",
                ""sectionId"": ""commemorative"",
                ""name"": ""«Первая победа» (firstVictory)"",
                ""condition"": null,
                ""description"": ""Победить в первом обычном бою с другими игроками."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/firstVictory.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/firstVictory.png"",
                ""order"": 1053
              },
              {
                ""id"": ""huntsman"",
                ""sectionId"": ""commemorative"",
                ""name"": ""«Егерь» (huntsman)"",
                ""condition"": null,
                ""description"": ""Уничтожить все лёгкие танки противника в одном бою, но не менее 3."",
                ""achievementValue"": 4,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/huntsman.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/huntsman.png"",
                ""order"": 300
              },
              {
                ""id"": ""ironMan"",
                ""sectionId"": ""commemorative"",
                ""name"": ""«Невозмутимый» (ironMan)"",
                ""condition"": null,
                ""description"": ""Получить подряд не менее 10 рикошетов и непробитий от противника."",
                ""achievementValue"": 24,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/ironMan.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/ironMan.png"",
                ""order"": 1007
              },
              {
                ""id"": ""sturdy"",
                ""sectionId"": ""commemorative"",
                ""name"": ""«Спартанец» (sturdy)"",
                ""condition"": ""• Выжить в бою."",
                ""description"": ""Получить рикошет или непробитие от противника при прочности танка менее 10%."",
                ""achievementValue"": 82,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/sturdy.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/sturdy.png"",
                ""order"": 1008
              }
            ]
          },
          {
            ""sectionId"": ""step"",
            ""name"": ""ЭТАПНЫЕ НАГРАДЫ"",
            ""order"": 4,
            ""achievements"": [
              {
                ""id"": ""medalCarius"",
                ""sectionId"": ""step"",
                ""name"": ""Медаль Кариуса"",
                ""condition"": ""• IV степени – 10\n• III степени – 100\n• II степени – 1 000\n• I степени – 10 000"",
                ""description"": ""За количество уничтоженных танков противника."",
                ""achievementValue"": 2,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalCarius2.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalCarius2.png"",
                ""order"": 1401
              },
              {
                ""id"": ""medalEkins"",
                ""sectionId"": ""step"",
                ""name"": ""Медаль Экинса"",
                ""condition"": ""• IV степени – 3\n• III степени – 30\n• II степени – 300\n• I степени – 3 000"",
                ""description"": ""За количество уничтоженных танков противника VIII–X уровней."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalEkins1.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalEkins1.png"",
                ""order"": 1402
              },
              {
                ""id"": ""medalKay"",
                ""sectionId"": ""step"",
                ""name"": ""Медаль Кея"",
                ""condition"": ""• IV степени – 1\n• III степени – 10\n• II степени – 100\n• I степени – 1 000"",
                ""description"": ""За получение статуса «Герой битвы»."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": 1700,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalKay1.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalKay1.png"",
                ""order"": 1400
              },
              {
                ""id"": ""medalLeClerc"",
                ""sectionId"": ""step"",
                ""name"": ""Медаль Леклерка"",
                ""condition"": ""• Победить в бою.\n• Засчитываются все очки захвата, набранные за один бой, за исключением очков захвата, полученных в Превосходстве.\n\n• IV степени – 30\n• III степени – 300\n• II степени – 3 000\n• I степени – 30 000"",
                ""description"": ""За суммарное количество очков захвата базы."",
                ""achievementValue"": 2,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalLeClerc2.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalLeClerc2.png"",
                ""order"": 1406
              },
              {
                ""id"": ""medalAbrams"",
                ""sectionId"": ""step"",
                ""name"": ""Медаль Абрамса"",
                ""condition"": ""• IV степени – 10\n• III степени – 100\n• II степени – 1 000\n• I степени – 10 000"",
                ""description"": ""За количество победных боёв, в которых игрок остался жив."",
                ""achievementValue"": 2,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalAbrams2.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalAbrams2.png"",
                ""order"": 1405
              },
              {
                ""id"": ""medalPoppel"",
                ""sectionId"": ""step"",
                ""name"": ""Медаль Попеля"",
                ""condition"": ""• IV степени – 20\n• III степени – 200\n• II степени – 2 000\n• I степени – 20 000"",
                ""description"": ""За количество обнаруженных танков противника."",
                ""achievementValue"": 2,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalPoppel2.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalPoppel2.png"",
                ""order"": 1404
              },
              {
                ""id"": ""medalSupremacy"",
                ""sectionId"": ""step"",
                ""name"": ""Медаль Превосходство"",
                ""condition"": ""• Накопительная медаль.\n• Засчитываются все очки победы, набранные в Превосходстве.\n\n• IV степени – 10 000\n• III степени – 100 000\n• II степени – 1 000 000\n• I степени – 10 000 000"",
                ""description"": ""За очки победы в Превосходстве."",
                ""achievementValue"": 3,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalSupremacy3.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalSupremacy3.png"",
                ""order"": 1408
              },
              {
                ""id"": ""medalLavrinenko"",
                ""sectionId"": ""step"",
                ""name"": ""Медаль Лавриненко"",
                ""condition"": ""• Засчитывается не более 100 очков за бой.\n• Не засчитываются сбитые очки захвата точек, заработанные в Превосходстве\n\n• IV степени – 30\n• III степени – 300\n• II степени – 3 000\n• I степени – 30 000"",
                ""description"": ""За суммарное количество сбитых очков захвата базы."",
                ""achievementValue"": 2,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalLavrinenko2.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalLavrinenko2.png"",
                ""order"": 1407
              },
              {
                ""id"": ""medalKnispel"",
                ""sectionId"": ""step"",
                ""name"": ""Медаль Книспеля"",
                ""condition"": ""• IV степени – 10 000\n• III степени – 100 000\n• II степени – 1 000 000\n• I степени – 10 000 000"",
                ""description"": ""За суммарное количество нанесённого и полученного урона."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalKnispel1.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalKnispel1.png"",
                ""order"": 1403
              }
            ]
          },
          {
            ""sectionId"": ""battle"",
            ""name"": ""«ГЕРОЙ БИТВЫ»"",
            ""order"": 0,
            ""achievements"": [
              {
                ""id"": ""invader"",
                ""sectionId"": ""battle"",
                ""name"": ""«Захватчик» (invader)"",
                ""condition"": ""• Выиграть бой захватом базы.\n• Засчитываются только очки, обеспечившие захват.\n• Не засчитываются очки захвата точек, полученные в Превосходстве."",
                ""description"": ""Получить наибольшее количество очков захвата базы, но не менее 80."",
                ""achievementValue"": 6,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/invader.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/invader.png"",
                ""order"": 203
              },
              {
                ""id"": ""markOfMasteryII"",
                ""sectionId"": ""battle"",
                ""name"": ""Знак классности \n«2 степень» (markOfMasteryII)"",
                ""condition"": null,
                ""description"": ""Присваивается игроку за мастерство владения танком. Для получения награды необходимо заработать больше опыта за бой, чем средний максимальный опыт за неделю у 80% игроков на данном танке."",
                ""achievementValue"": 853,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/markOfMasteryII.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/markOfMasteryII.png"",
                ""order"": 2
              },
              {
                ""id"": ""markOfMasteryI"",
                ""sectionId"": ""battle"",
                ""name"": ""Знак классности \n«1 степень» (markOfMasteryI)"",
                ""condition"": null,
                ""description"": ""Присваивается игроку за мастерство владения танком. Для получения награды необходимо заработать больше опыта за бой, чем средний максимальный опыт за неделю у 95% игроков на данном танке."",
                ""achievementValue"": 203,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/markOfMasteryI.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/markOfMasteryI.png"",
                ""order"": 1
              },
              {
                ""id"": ""defender"",
                ""sectionId"": ""battle"",
                ""name"": ""«Защитник» (defender)"",
                ""condition"": ""• При равном количестве сбитых очков награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой.\n• Не засчитываются очки захвата точек, полученные в Превосходстве."",
                ""description"": ""Защитить базу, сбив наибольшее количество очков захвата, но не менее 70."",
                ""achievementValue"": 23,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/defender.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/defender.png"",
                ""order"": 202
              },
              {
                ""id"": ""markOfMasteryIII"",
                ""sectionId"": ""battle"",
                ""name"": ""Знак классности \n«3 степень» (markOfMasteryIII)"",
                ""condition"": null,
                ""description"": ""Присваивается игроку за мастерство владения танком. Для получения награды необходимо заработать больше опыта за бой, чем средний максимальный опыт за неделю у 50% игроков на данном танке."",
                ""achievementValue"": 1783,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/markOfMasteryIII.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/markOfMasteryIII.png"",
                ""order"": 3
              },
              {
                ""id"": ""supporter"",
                ""sectionId"": ""battle"",
                ""name"": ""«Поддержка» (supporter)"",
                ""condition"": ""• Засчитываются цели, которые впоследствии были уничтожены другими игроками или самоуничтожились.\n• Рикошеты и непробития не учитываются.\n• При равном количестве повреждённых танков награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой."",
                ""description"": ""Нанести урон или сбить гусеницу наибольшему количеству танков противника, но не менее чем 4."",
                ""achievementValue"": 823,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/supporter.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/supporter.png"",
                ""order"": 6
              },
              {
                ""id"": ""steelwall"",
                ""sectionId"": ""battle"",
                ""name"": ""«Стальная cтена» (steelwall)"",
                ""condition"": ""• Выжить в бою.\n• При равном количестве полученного потенциального урона награждается игрок, получивший больше попаданий.\n• При равном количестве полученного потенциального урона и попаданий награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой."",
                ""description"": ""Получить не менее 1 000 единиц потенциального урона и не менее 11 попаданий."",
                ""achievementValue"": 129,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/steelwall.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/steelwall.png"",
                ""order"": 201
              },
              {
                ""id"": ""mainGun"",
                ""sectionId"": ""battle"",
                ""name"": ""«Основной калибр» (mainGun)"",
                ""condition"": ""• Нанесённый урон должен составлять не менее 35% от суммарной прочности танков противника и не менее 1000 единиц.\n• При равном количестве нанесённого урона награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой."",
                ""description"": ""Нанести наибольшее количество урона за бой."",
                ""achievementValue"": 255,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/mainGun.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/mainGun.png"",
                ""order"": 5
              },
              {
                ""id"": ""warrior"",
                ""sectionId"": ""battle"",
                ""name"": ""«Воин» (warrior)"",
                ""condition"": ""• При равном счёте награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой."",
                ""description"": ""Уничтожить наибольшее количество танков противника, но не менее 4."",
                ""achievementValue"": 236,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/warrior.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/warrior.png"",
                ""order"": 4
              },
              {
                ""id"": ""camper"",
                ""sectionId"": ""battle"",
                ""name"": ""«Танкист-снайпер» (camper)"",
                ""condition"": ""• Произвести не менее 8 выстрелов.\n• Не менее 80% попаданий должны быть с нанесением урона.\n• Учитывается урон танкам противника и повреждения модулей.\n• Общая точность стрельбы за бой должна быть не менее 85%.\n• Нанесённый урон должен превышать количество очков прочности танка игрока и быть не менее 1000 единиц.\n• При равном количестве нанесённого урона награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой."",
                ""description"": ""Нанести наибольшее количество урона за бой с дистанции не менее 250 м."",
                ""achievementValue"": 7,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/camper.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/camper.png"",
                ""order"": 7
              },
              {
                ""id"": ""markOfMastery"",
                ""sectionId"": ""battle"",
                ""name"": ""Знак классности \n«Мастер» (markOfMastery)"",
                ""condition"": null,
                ""description"": ""Присваивается игроку за мастерство владения танком. Для получения награды необходимо заработать больше опыта за бой, чем средний максимальный опыт за неделю у 99% игроков на данном танке."",
                ""achievementValue"": 76,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/markOfMastery.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/markOfMastery.png"",
                ""order"": 0
              },
              {
                ""id"": ""scout"",
                ""sectionId"": ""battle"",
                ""name"": ""«Разведчик» (scout)"",
                ""condition"": ""• Победить в бою.\n• Выдаётся только одна награда за бой."",
                ""description"": ""Обнаружить наибольшее количество танков противника, но не менее 5."",
                ""achievementValue"": 151,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/scout.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/scout.png"",
                ""order"": 204
              },
              {
                ""id"": ""evileye"",
                ""sectionId"": ""battle"",
                ""name"": ""«Дозорный» (evileye)"",
                ""condition"": ""• Засчитываются цели, разведданные по которым в момент их повреждения передавал только один игрок.\n• При равном количестве повреждённых танков награждается игрок, получивший наибольшее количество очков опыта за бой.\n• Выдаётся только одна награда за бой."",
                ""description"": ""Предоставить разведданные, по которым союзники повредят не менее 3 танков противника."",
                ""achievementValue"": 70,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/evileye.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/evileye.png"",
                ""order"": 200
              }
            ]
          },
          {
            ""sectionId"": ""epic"",
            ""name"": ""ЭПИЧЕСКИЕ МЕДАЛИ"",
            ""order"": 2,
            ""achievements"": [
              {
                ""id"": ""medalHalonen"",
                ""sectionId"": ""epic"",
                ""name"": ""Медаль Халонена (medalHalonen)"",
                ""condition"": ""• Уничтоженные танки должны превосходить ПТ-САУ игрока как минимум на 1 уровень."",
                ""description"": ""Уничтожить не менее 3 танков противника в одном бою, управляя ПТ-САУ."",
                ""achievementValue"": 3,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalHalonen.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalHalonen.png"",
                ""order"": 606
              },
              {
                ""id"": ""medalOskin"",
                ""sectionId"": ""epic"",
                ""name"": ""Медаль Оськина (medalOskin)"",
                ""condition"": ""• Уничтоженные танки должны превосходить танк игрока как минимум на 1 уровень."",
                ""description"": ""Уничтожить 3 танка противника в одном бою, управляя средним танком."",
                ""achievementValue"": 6,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalOskin.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalOskin.png"",
                ""order"": 603
              },
              {
                ""id"": ""medalRadleyWalters"",
                ""sectionId"": ""epic"",
                ""name"": ""Медаль Рэдли-Уолтерса (medalRadleyWalters)"",
                ""condition"": ""• Управлять танком V уровня и выше."",
                ""description"": ""Уничтожить 5 танков противника в одном бою."",
                ""achievementValue"": 35,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalRadleyWalters.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalRadleyWalters.png"",
                ""order"": 102
              },
              {
                ""id"": ""medalLehvaslaiho"",
                ""sectionId"": ""epic"",
                ""name"": ""Медаль Лехвеслайхо (medalLehvaslaiho)"",
                ""condition"": ""• Уничтоженные танки должны превосходить танк игрока как минимум на 1 уровень."",
                ""description"": ""Уничтожить 2 танка противника в одном бою, управляя средним танком."",
                ""achievementValue"": 50,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalLehvaslaiho.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalLehvaslaiho.png"",
                ""order"": 604
              },
              {
                ""id"": ""medalOrlik"",
                ""sectionId"": ""epic"",
                ""name"": ""Медаль Орлика (medalOrlik)"",
                ""condition"": ""• Уничтоженные танки должны превосходить танк игрока как минимум на 1 уровень."",
                ""description"": ""Уничтожить не менее 3 танков противника в одном бою, управляя лёгким танком."",
                ""achievementValue"": 4,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalOrlik.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalOrlik.png"",
                ""order"": 605
              },
              {
                ""id"": ""medalNikolas"",
                ""sectionId"": ""epic"",
                ""name"": ""Медаль Николса (medalNikolas)"",
                ""condition"": ""• Уничтоженные танки должны превосходить танк игрока как минимум на 1 уровень."",
                ""description"": ""Уничтожить не менее 4 танков противника в одном бою, управляя средним танком."",
                ""achievementValue"": 1,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalNikolas.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalNikolas.png"",
                ""order"": 602
              },
              {
                ""id"": ""medalKolobanov"",
                ""sectionId"": ""epic"",
                ""name"": ""Медаль Колобанова (medalKolobanov)"",
                ""condition"": ""• Выжить в бою."",
                ""description"": ""Победить в бою, оставшись в одиночку против 3 и более танков."",
                ""achievementValue"": 7,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalKolobanov.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalKolobanov.png"",
                ""order"": 600
              },
              {
                ""id"": ""medalLafayettePool"",
                ""sectionId"": ""epic"",
                ""name"": ""Медаль Пула (medalLafayettePool)"",
                ""condition"": ""• Управлять танком V уровня и выше."",
                ""description"": ""Уничтожить 6 танков противника в одном бою."",
                ""achievementValue"": 7,
                ""maxSeriesValue"": null,
                ""image"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/medalLafayettePool.png"",
                ""imageBig"": ""http://glossary-eu-static.gcdn.co/icons/wotb/current/achievements/big/medalLafayettePool.png"",
                ""order"": 101
              }
            ]
          }
        ]
      }
    }
  }
";
    }
}