using syncfusion.demoscommon.wpf;
using syncfusion.presentationdemos.wpf;
using System.Windows;

namespace syncfusion.presentationdemos.wpf
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
            var window = new MainWindow(new PresentationDemosViewModel());
            window.Show();
            base.OnStartup(e);
        }
    }
}
