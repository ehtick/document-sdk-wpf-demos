using System;
using System.Windows;
using Syncfusion.SfSkinManager;
using syncfusion.demoscommon.wpf;

namespace syncfusion.invoice.wpf.app
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Telemetry.Telemetry.Disable();
            LicenseKeyLocator.FindandRegisterLicenseKey();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            SfSkinManager.ApplyThemeAsDefaultStyle = true;
            var window = Activator.CreateInstance(typeof(InvoiceDemo)) as Window;
            window.Show();
            base.OnStartup(e);
        }
    }
}
