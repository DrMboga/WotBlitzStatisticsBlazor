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

        private string[] _selectedFileAsAccounts = null;
        private string[] _selectedFileAsTanks = null;

        public MainFormPresenter(
            IMainFormView view,
            IDialogService dialogService,
            JsonFilesImporter jsonFilesImporter)
        {
            _dialogService = dialogService;
            _jsonFilesImporter = jsonFilesImporter;
            View = view;
            View.OpenJsonFolderClick += OpenJsonFolder;
            View.AddFilesAsAccountsInfoList += AddFilesAsAccountsInfoList;
            View.AddFilesAsTanksInfoList += AddFilesAsTanksInfoList;
            View.StartJsonConvert += StartJsonConvert;
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

            var progress = new Progress<ImportProgress>();
            progress.ProgressChanged += ProgressChanged;

            await _jsonFilesImporter.Import(View.MongoDbConnectionString,
                View.JsonFolderPath,
                _selectedFileAsAccounts,
                _selectedFileAsTanks,
                progress);
        }

        private void ProgressChanged(object sender, ImportProgress e)
        {
            View.StatusInformation = $"{e.FilesConverted} files converted ({e.Progress}%)";
            View.AppendLogRow($"Converted: '{e.AccountFileConverted}' - '{e.TankFileConverted}': '{e.AccountName}', {e.BattlesCount} battles, '{e.LastBattle.ToShortDateString()}', {e.TanksCount} tanks");
            View.SetProcessPercentage(e.Progress);
        }
    }
}