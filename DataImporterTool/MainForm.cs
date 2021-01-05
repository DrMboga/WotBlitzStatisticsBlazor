using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataImporterTool
{
    public partial class MainForm : Form, IMainFormView
    {
        public MainForm()
        {
            InitializeComponent();

            statusImportProgressBar.Minimum = 0;
            statusImportProgressBar.Maximum = 100;

            btnOpenFolder.Click += BtnOpenFolder_Click;
            btnAddAsAccounts.Click += BtnAddAsAccounts_Click;
            btnAddAsTanks.Click += BtnAddAsTanks_Click;
            btnStartImport.Click += BtnStartImport_Click;

            lstSqlAccounts.ValueMember = "Key";
            lstSqlAccounts.DisplayMember = "Value";
            btnFetchData.Click += BtnFetchData_Click;
            btnImportSqlAccounts.Click += BtnImportSqlAccounts_Click;
        }

        public string MongoDbConnectionString
        {
            get => txtMongoConnectionString.Text;
            set => txtMongoConnectionString.Text = value;
        }

        public string JsonFolderPath
        {
            get => txtJsonFolder.Text;
            set => txtJsonFolder.Text = value;
        }

        public string StatusInformation
        {
            get => statusImportLabel.Text;
            set => statusImportLabel.Text = value;
        }

        public string SqlConnectionString
        {
            get => txtSqlConnectionString.Text;
            set => txtSqlConnectionString.Text = value;
        }

        public event Action OpenJsonFolderClick;

        public event Action<string[]> AddFilesAsAccountsInfoList;

        public event Action<string[]> AddFilesAsTanksInfoList;

        public event Action StartJsonConvert;

        public event Action FetchSqlAccounts;

        public event Action<long[]> StartSqlImport;

        public void ShowJsonFiles(string[] allJsonFiles)
        {
            lstAllFiles.DataSource = allJsonFiles;
        }

        public void ShowJsonAccountFiles(string[] accountJsonFiles)
        {
            lstAccounts.DataSource = accountJsonFiles;
        }

        public void ShowJsonTankFiles(string[] tankJsonFiles)
        {
            lstTanks.DataSource = tankJsonFiles;
        }

        public void ClearLog()
        {
            txtIpmortLog.Text = string.Empty;
        }

        public void AppendLogRow(string logInfo)
        {
            txtIpmortLog.Text = $"{txtIpmortLog.Text}{Environment.NewLine}{logInfo}";
        }

        public void SetProcessPercentage(int percentage)
        {
            statusImportProgressBar.Value = percentage;
        }

        public void ShowSqlAccounts(Dictionary<long, string> accounts)
        {
            lstSqlAccounts.DataSource = new BindingSource(accounts, null);
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            OpenJsonFolderClick?.Invoke();
        }

        private void BtnAddAsAccounts_Click(object sender, EventArgs e)
        {
            var selected = lstAllFiles.SelectedItems.Cast<string>().ToArray();
            if (selected.Length > 0)
            {
                AddFilesAsAccountsInfoList?.Invoke(selected);
            }
        }

        private void BtnAddAsTanks_Click(object sender, EventArgs e)
        {
            var selected = lstAllFiles.SelectedItems.Cast<string>().ToArray();
            if (selected.Length > 0)
            {
                AddFilesAsTanksInfoList?.Invoke(selected);
            }
        }

        private void BtnStartImport_Click(object sender, EventArgs e)
        {
            StartJsonConvert?.Invoke();
        }

        private void BtnFetchData_Click(object sender, EventArgs e)
        {
            FetchSqlAccounts?.Invoke();
        }

        private void BtnImportSqlAccounts_Click(object sender, EventArgs e)
        {
            var selectedAccounts = lstSqlAccounts.SelectedItems.Cast<KeyValuePair<long, string>>().Select(i => i.Key)
                .ToArray();
            StartSqlImport?.Invoke(selectedAccounts);
        }
    }
}
