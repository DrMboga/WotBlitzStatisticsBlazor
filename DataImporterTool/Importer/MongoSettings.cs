using WotBlitzStatisticsPro.Common;

namespace DataImporterTool.Importer
{
    public class MongoSettings : IMongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}