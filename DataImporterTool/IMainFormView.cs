using System;

namespace DataImporterTool
{
    public interface IMainFormView
    {
        string MongoDbConnectionString { get; set; }

        string JsonFolderPath { get; set; }

        string StatusInformation { get; set; }

        void ShowJsonFiles(string[] allJsonFiles);

        void ShowJsonAccountFiles(string[] accountJsonFiles);

        void ShowJsonTankFiles(string[] tankJsonFiles);

        void ClearLog();

        void AppendLogRow(string logInfo);

        void SetProcessPercentage(int percentage);

        event Action OpenJsonFolderClick;

        event Action<string[]> AddFilesAsAccountsInfoList;

        event Action<string[]> AddFilesAsTanksInfoList;

        event Action StartJsonConvert;
    }
}