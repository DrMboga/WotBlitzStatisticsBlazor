using System;
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

        public event Action OpenJsonFolderClick;

        public event Action<string[]> AddFilesAsAccountsInfoList;

        public event Action<string[]> AddFilesAsTanksInfoList;

        public event Action StartJsonConvert;

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
    }
}
