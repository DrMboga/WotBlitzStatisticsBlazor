using WotBlitzStatisticsPro.Common;

namespace WotBlitzStatisticsPro.GraphQl
{
    public class MongoSettings : IMongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}