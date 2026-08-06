using syncfusion.demoscommon.wpf;
using syncfusion.dociodemos.wpf;
using System.Windows;

namespace syncfusion.dociodemos.wpf
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
            var window = new MainWindow(new DocIODemosViewModel());
            window.Show();
            base.OnStartup(e);
        }
    }
}
