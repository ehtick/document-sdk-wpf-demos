using syncfusion.demoscommon.wpf;
using syncfusion.pdfdemos.wpf;
using System.Windows;

namespace syncfusion.pdf.wpf_4._7
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
            var window = new MainWindow(new PdfDemosViewModel());
            window.Show();
            base.OnStartup(e);
        }
    }
}
