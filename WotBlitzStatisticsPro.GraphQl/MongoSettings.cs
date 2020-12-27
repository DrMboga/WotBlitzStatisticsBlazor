using WotBlitzStatisticsPro.Common;

namespace WotBlitzStatisticsPro.GraphQl
{
    public class MongoSettings : IMongoSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}