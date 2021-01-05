using System;
using System.IO;
using System.Linq;
using System.Text;
using DataImporterTool.Dialogs;
using DataImporterTool.Importer;

namespace DataImporterTool
{
    public class MainFormPresenter
    {
        private readonly IDialogService _dialogService;
        private readonly JsonFilesImporter _jsonFilesImporter;
        private readonly SqlImporter _sqlImporter;

        private string[] _selectedFileAsAccounts = null;
        private string[] _selectedFileAsTanks = null;

        public MainFormPresenter(
            IMainFormView view,
            IDialogService dialogService,
            JsonFilesImporter jsonFilesImporter,
            SqlImporter sqlImporter)
        {
            _dialogService = dialogService;
            _jsonFilesImporter = jsonFilesImporter;
            _sqlImporter = sqlImporter;
            View = view;
            View.OpenJsonFolderClick += OpenJsonFolder;
            View.AddFilesAsAccountsInfoList += AddFilesAsAccountsInfoList;
            View.AddFilesAsTanksInfoList += AddFilesAsTanksInfoList;
            View.StartJsonConvert += StartJsonConvert;
            View.FetchSqlAccounts += FetchSqlAccounts;
            View.StartSqlImport += StartSqlImport;
        }

        public IMainFormView View { get; }

        private void OpenJsonFolder()
        {
            View.JsonFolderPath = _dialogService.ChooseFolder() ?? string.Empty;
            if (!string.IsNullOrEmpty(View.JsonFolderPath))
            {
                var files = Directory.GetFiles(View.JsonFolderPath, "*.json").Select(Path.GetFileName).ToArray();
                View.ShowJsonFiles(files);
            }

        }

        private void AddFilesAsAccountsInfoList(string[] files)
        {
            _selectedFileAsAccounts = files;
            View.ShowJsonAccountFiles(files);
            UpdateStatusInformation();
        }

        private void AddFilesAsTanksInfoList(string[] files)
        {
            _selectedFileAsTanks = files;
            View.ShowJsonTankFiles(files);
            UpdateStatusInformation();
        }


        private void UpdateStatusInformation()
        {
            var text = new StringBuilder();
            if (_selectedFileAsAccounts != null)
            {
                text.Append($"{_selectedFileAsAccounts.Length} accounts json files selected");
            }

            if (_selectedFileAsTanks != null)
            {
                text.Append($"; {_selectedFileAsTanks.Length} tanks json files selected");
            }

            View.StatusInformation = text.ToString();
        }

        private async void StartJsonConvert()
        {
            if (string.IsNullOrEmpty(View.MongoDbConnectionString))
            {
                _dialogService.ShowWarning("MongoDB connection string is empty!");
                return;
            }

            if (_selectedFileAsAccounts == null || _selectedFileAsAccounts.Length == 0
                                                || _selectedFileAsTanks == null || _selectedFileAsTanks.Length == 0)
            {
                _dialogService.ShowWarning("Should be selected some account and tank json files");
                return;
            }

            if (_selectedFileAsTanks != null && _selectedFileAsAccounts != null &&
                _selectedFileAsAccounts.Length != _selectedFileAsTanks.Length)
            {
                _dialogService.ShowWarning("Account files count should be equal to tank files count");
                return;
            }

            View.ClearLog();
            View.SetProcessPercentage(0);

            var progress = new Progress<FileImportProgress>();
            progress.ProgressChanged += FileImportProgressChanged;

            await _jsonFilesImporter.Import(View.MongoDbConnectionString,
                View.JsonFolderPath,
                _selectedFileAsAccounts,
                _selectedFileAsTanks,
                progress);
        }

        private void FileImportProgressChanged(object sender, FileImportProgress e)
        {
            View.StatusInformation = $"{e.FilesConverted} files converted ({e.Progress}%)";
            View.AppendLogRow($"Converted: '{e.AccountFileConverted}' - '{e.TankFileConverted}': '{e.AccountName}', {e.BattlesCount} battles, '{e.LastBattle.ToShortDateString()}', {e.TanksCount} tanks");
            View.SetProcessPercentage(e.Progress);
        }

        private async void FetchSqlAccounts()
        {
            if (string.IsNullOrWhiteSpace(View.SqlConnectionString))
            {
                _dialogService.ShowWarning("Empty SQL connection string!");
                return;
            }

            View.ClearLog();
            View.AppendLogRow("Start fetching account from SQL...");

            var accounts = await _sqlImporter.FetchAllAccounts(View.SqlConnectionString);
            if(accounts != null)
            {
                View.ShowSqlAccounts(accounts);
            }
            View.AppendLogRow($"Found {accounts?.Count ?? 0} accounts");
        }

        private async void StartSqlImport(long[] accounts)
        {
            if (accounts == null || accounts.Length == 0)
            {
                _dialogService.ShowWarning("Please select at least one account");
                return;
            }
            if (string.IsNullOrEmpty(View.MongoDbConnectionString))
            {
                _dialogService.ShowWarning("MongoDB connection string is empty!");
                return;
            }
            if (string.IsNullOrWhiteSpace(View.SqlConnectionString))
            {
                _dialogService.ShowWarning("Empty SQL connection string!");
                return;
            }

            var progress = new Progress<ImportProgress>();
            progress.ProgressChanged += SqlImport_ProgressChanged;

            View.ClearLog();
            View.SetProcessPercentage(0);

            await _sqlImporter.StartImport(View.MongoDbConnectionString, View.SqlConnectionString, accounts, progress);
        }

        private void SqlImport_ProgressChanged(object sender, ImportProgress e)
        {
            View.StatusInformation = $"{e.Progress}% Converted";
            View.AppendLogRow($"Imported: '{e.AccountName}', {e.BattlesCount} battles, '{e.LastBattle.ToShortDateString()}', {e.TanksCount} tanks");
            View.SetProcessPercentage(e.Progress);
        }
    }
}