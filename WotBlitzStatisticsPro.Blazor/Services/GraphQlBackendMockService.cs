using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions;
using WotBlitzStatisticsPro.Blazor.GraphQl;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class GraphQlBackendMockService: IGraphQlBackendService
    {
        public async Task<IReadOnlyList<IFindPlayers_Players>?> FindPlayers(string accountNick, RealmType realmType)
        {
            var result = new List<IFindPlayers_Players>();

            var faker = new Faker(FakerLanguage(GetLanguage()));
            var random = faker.Random.Number(10, 80);

            for (int i = 0; i < random; i++)
            {
                result.Add(new FindPlayers_Players_AccountsSearchResponseItem(
                    faker.Random.Long(100000, 999999),
                    faker.Internet.UserName(),
                    faker.Hacker.Abbreviation().OrNull(faker, 0.6f),
                    faker.Date.Past(),
                    faker.Random.Number(10, 20000),
                    faker.Random.Number(30, 90)));
            }

            await Task.Delay(1000);

            return result;
        }

        public async Task<IReadOnlyList<IFindClans_Clans>?> FindClans(string clanNameOrTag, RealmType realmType)
        {
            var result = new List<IFindClans_Clans>();

            var faker = new Faker(FakerLanguage(GetLanguage()));
            var random = faker.Random.Number(10, 80);

            for (int i = 0; i < random; i++)
            {
                result.Add(new FindClans_Clans_ClanSearchResponseItem(
                    faker.Random.Long(100000, 999999),
                    Convert.ToInt32((faker.Date.Past() - new DateTime(1970, 1, 1)).TotalSeconds),
                    faker.Random.Number(1, 50),
                    faker.Lorem.Word(),
                    faker.Lorem.Letter()));
            }


            await Task.Delay(1000);

            return result;
        }

        private string FakerLanguage(RequestLanguage language)
        {
            switch (language)
            {
                case RequestLanguage.Ru:
                    return "ru";
                case RequestLanguage.De:
                    return "de";
                default:
                    return "en";
            }
        }

        private RequestLanguage GetLanguage()
        {
            var culture = CultureInfo.CurrentCulture;

            switch (culture.Name)
            {
                case "ru-RU":
                    return RequestLanguage.Ru;
                case "de-DE":
                    return RequestLanguage.De;
                default:
                    return RequestLanguage.En;
            }
        }
    }
}