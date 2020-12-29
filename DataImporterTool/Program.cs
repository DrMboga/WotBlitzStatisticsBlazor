using System;
using System.Windows.Forms;
using DataImporterTool.Dialogs;
using DataImporterTool.Importer;
using Microsoft.Extensions.DependencyInjection;

namespace DataImporterTool
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceProvider = new ServiceCollection()
                .AddSingleton<JsonFilesImporter>()
                .AddSingleton<IDialogService, DialogService>()
                .AddSingleton<IMainFormView, MainForm>()
                .AddSingleton<MainFormPresenter>()
                .BuildServiceProvider();

            var mainFormPresenter = serviceProvider.GetService<MainFormPresenter>();

            var form = mainFormPresenter.View as Form;

            Application.Run(form);
        }

    }
}
