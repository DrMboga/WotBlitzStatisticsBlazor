using System;

namespace DataImporterTool.Importer
{
    public class ImportProgress
    {
        public int FilesConverted { get; set; }

        public int Progress { get; set; }

        public string AccountFileConverted { get; set; }

        public string TankFileConverted { get; set; }

        public string AccountName { get; set; }

        public DateTime LastBattle { get; set; }

        public long BattlesCount { get; set; }

        public int TanksCount { get; set; }
    }
}