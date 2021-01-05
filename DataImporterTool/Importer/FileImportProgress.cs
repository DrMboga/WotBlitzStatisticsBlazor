namespace DataImporterTool.Importer
{
    public class FileImportProgress: ImportProgress
    {
        public int FilesConverted { get; set; }

        public string AccountFileConverted { get; set; }

        public string TankFileConverted { get; set; }

    }
}