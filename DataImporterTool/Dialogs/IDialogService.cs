#nullable enable
namespace DataImporterTool.Dialogs
{
    public interface IDialogService
    {
        string? ChooseFolder();

        void ShowWarning(string warningMessage);
    }
}