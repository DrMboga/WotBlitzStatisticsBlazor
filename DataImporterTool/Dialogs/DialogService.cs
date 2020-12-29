using System.Windows.Forms;

#nullable enable
namespace DataImporterTool.Dialogs
{
    public class DialogService : IDialogService
    {
        public string? ChooseFolder()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    return fbd.SelectedPath;
                }
            }

            return null;
        }

        public void ShowWarning(string warningMessage)
        {
            MessageBox.Show(warningMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}