using System;
using System.Collections.Generic;

namespace DataImporterTool
{
    public interface IMainFormView
    {
        string MongoDbConnectionString { get; set; }

        string JsonFolderPath { get; set; }

        string StatusInformation { get; set; }

        public string SqlConnectionString { get; set; }

        void ShowJsonFiles(string[] allJsonFiles);

        void ShowJsonAccountFiles(string[] accountJsonFiles);

        void ShowJsonTankFiles(string[] tankJsonFiles);

        void ClearLog();

        void AppendLogRow(string logInfo);

        void SetProcessPercentage(int percentage);

        void ShowSqlAccounts(Dictionary<long, string> accounts);

        event Action OpenJsonFolderClick;

        event Action<string[]> AddFilesAsAccountsInfoList;

        event Action<string[]> AddFilesAsTanksInfoList;

        event Action StartJsonConvert;

        event Action FetchSqlAccounts;

        event Action<long[]> StartSqlImport;
    }
}