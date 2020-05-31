namespace WotBlitzStatisticsPro.Common
{
    /// <summary>
    /// MongoDB connection settings
    /// </summary>
    public interface IMongoSettings
    {
        /// <summary>
        /// Connection string
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Database name
        /// </summary>
        string DatabaseName { get; set; }
    }
}