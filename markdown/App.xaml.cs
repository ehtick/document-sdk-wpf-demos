using syncfusion.demoscommon.wpf;
using syncfusion.markdowndemos.wpf;
using System.Windows;

namespace syncfusion.markdowndemos.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LicenseKeyLocator.FindandRegisterLicenseKey();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new MainWindow(new MarkdownDemosViewModel());
            window.Show();
            base.OnStartup(e);
        }
    }
}
