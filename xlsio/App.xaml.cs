using syncfusion.demoscommon.wpf;
using syncfusion.xlsiodemos.wpf;
using System.Windows;

namespace syncfusion.xlsiodemos.wpf
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
            var window = new MainWindow(new XlsIODemosViewModel());
            window.Show();
            base.OnStartup(e);
        }
    }
}
