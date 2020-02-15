using Newtonsoft.Json;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Common.Model;
using WotBlitzStatisticsPro.WgApiClient;

namespace WotBlitzStatistics.GraphQl.Query
{
	public class WotBlitzStatisticsQuery
	{
        private readonly IWargamingApiClient _wargamingApiClient;

        public WotBlitzStatisticsQuery(IWargamingApiClient wargamingApiClient)
        {
            _wargamingApiClient = wargamingApiClient;
        }

        public async Task<PlayerAccountInfo> GetPlayerInfo(long accountId)
        {
            var account = await _wargamingApiClient.GetPlayerAccountInfo(accountId);
            // ToDo: think abount mappers or resolvers
            var accountStub = JsonConvert.DeserializeObject<PlayerAccountInfo>(AccountJson);
            accountStub.AccountId = accountId;
            return accountStub;
        }


        private const string AccountJson =
@"
{
  ""AccountId"": 90277267,
  ""NickName"": ""Mboga [XXX_L]"",
  ""AccountCreatedAt"": ""2018-01-20T11:17:35+03:00"",
  ""LastBattleTime"": ""2020-02-07T20:03:34+03:00"",
  ""Battles"": 10842,
  ""Wn7"": 1283.4155297487303,
  ""AvgTier"": 7.364785095000922,
  ""Winrate"": 54.75926950747095,
  ""AvgDamage"": 1266.5282235749862,
  ""AvgXp"": 663.4533296439771,
  ""Achievements"": [
    {
      ""AchievementId"": ""medalHalonen"",
      ""Section"": ""epic"",
      ""Name"": ""Halonen's Medal (medalHalonen)\r\nDestroy at least 3 enemy vehicles with a tank destroyer in one battle."",
      ""Image"": ""http://glossary-ru-static.gcdn.co/icons/wotb/current/achievements/medalHalonen.png"",
      ""Count"": 3
    },
    {
      ""AchievementId"": ""medalLehvaslaiho"",
      ""Section"": ""epic"",
      ""Name"": ""Lehväslaiho's Medal (medalLehvaslaiho)\r\nDestroy 2 enemy vehicles with a medium tank in one battle."",
      ""Image"": ""http://glossary-ru-static.gcdn.co/icons/wotb/current/achievements/medalLehvaslaiho.png"",
      ""Count"": 47
    },
    {
      ""AchievementId"": ""markOfMastery"",
      ""Section"": ""battle"",
      ""Name"": ""Mastery badge: \nAce Tanker (markOfMastery)\r\nProve your mastery in controlling a vehicle. Earn more XP in a battle than the average highest XP of 99% of players who have fought in this vehicle for the previous 7 days."",
      ""Image"": ""http://glossary-ru-static.gcdn.co/icons/wotb/current/achievements/markOfMastery.png"",
      ""Count"": 73
    },
    {
      ""AchievementId"": ""medalKolobanov"",
      ""Section"": ""epic"",
      ""Name"": ""Kolobanov's Medal (medalKolobanov)\r\nStand alone against 3 enemy vehicles and win."",
      ""Image"": ""http://glossary-ru-static.gcdn.co/icons/wotb/current/achievements/medalKolobanov.png"",
      ""Count"": 6
    },
    {
      ""AchievementId"": ""medalLafayettePool"",
      ""Section"": ""epic"",
      ""Name"": ""Pool's Medal (medalLafayettePool)\r\nDestroy 6 enemy vehicles in one battle."",
      ""Image"": ""http://glossary-ru-static.gcdn.co/icons/wotb/current/achievements/medalLafayettePool.png"",
      ""Count"": 7
    },
    {
      ""AchievementId"": ""medalOrlik"",
      ""Section"": ""epic"",
      ""Name"": ""Orlik's Medal (medalOrlik)\r\nDestroy at least 3 enemy vehicles with a light tank in one battle."",
      ""Image"": ""http://glossary-ru-static.gcdn.co/icons/wotb/current/achievements/medalOrlik.png"",
      ""Count"": 4
    },
    {
      ""AchievementId"": ""medalRadleyWalters"",
      ""Section"": ""epic"",
      ""Name"": ""Radley-Walters's Medal (medalRadleyWalters)\r\nDestroy 5 enemy vehicles in one battle."",
      ""Image"": ""http://glossary-ru-static.gcdn.co/icons/wotb/current/achievements/medalRadleyWalters.png"",
      ""Count"": 33
    },
    {
      ""AchievementId"": ""medalOskin"",
      ""Section"": ""epic"",
      ""Name"": ""Oskin's Medal (medalOskin)\r\nDestroy 3 enemy vehicles with a medium tank in one battle."",
      ""Image"": ""http://glossary-ru-static.gcdn.co/icons/wotb/current/achievements/medalOskin.png"",
      ""Count"": 6
    },
    {
      ""AchievementId"": ""medalNikolas"",
      ""Section"": ""epic"",
      ""Name"": ""Nicols's Medal (medalNikolas)\r\nDestroy at least 4 enemy vehicles with a medium tank in one battle."",
      ""Image"": ""http://glossary-ru-static.gcdn.co/icons/wotb/current/achievements/medalNikolas.png"",
      ""Count"": 1
    }
  ],
  ""TopTanks"": [
    {
      ""TankId"": 59905,
      ""MarkOfMastery"": 4,
      ""Battles"": 769,
      ""WinRate"": 57.737321196358907672301690507,
      ""AvgDamage"": 1378.6579973992197659297789337,
      ""AvgXp"": 764.92847854356306892067620286,
      ""Name"": ""T-54 first prototype"",
      ""Tier"": 8,
      ""TierRoman"": ""VIII"",
      ""Nation"": ""ussr"",
      ""Type"": ""mediumTank"",
      ""IsPremium"": true,
      ""PreviewImageUrl"": ""http://glossary-ru-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/R112_T54_45.png""
    },
    {
      ""TankId"": 13345,
      ""MarkOfMastery"": 4,
      ""Battles"": 662,
      ""WinRate"": 55.287009063444108761329305136,
      ""AvgDamage"": 1344.1555891238670694864048338,
      ""AvgXp"": 776.1495468277945619335347432,
      ""Name"": ""T26E4 SuperPershing"",
      ""Tier"": 8,
      ""TierRoman"": ""VIII"",
      ""Nation"": ""usa"",
      ""Type"": ""mediumTank"",
      ""IsPremium"": true,
      ""PreviewImageUrl"": ""http://glossary-ru-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/T26_E4_SuperPershing.png""
    },
    {
      ""TankId"": 9217,
      ""MarkOfMastery"": 4,
      ""Battles"": 439,
      ""WinRate"": 55.808656036446469248291571754,
      ""AvgDamage"": 1493.7220956719817767653758542,
      ""AvgXp"": 737.12072892938496583143507973,
      ""Name"": ""IS-6"",
      ""Tier"": 8,
      ""TierRoman"": ""VIII"",
      ""Nation"": ""ussr"",
      ""Type"": ""heavyTank"",
      ""IsPremium"": true,
      ""PreviewImageUrl"": ""http://glossary-ru-static.gcdn.co/icons/wotb/current/uploaded/vehicles/hd_thumbnail/Object252.png""
    }
  ]
}
";
    }
}
