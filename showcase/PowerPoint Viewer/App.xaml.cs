using syncfusion.powerpointviewer.wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Syncfusion.SfSkinManager;
using syncfusion.demoscommon.wpf;

namespace syncfusion.powerpointviewer.wpf.app
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
            SfSkinManager.ApplyThemeAsDefaultStyle = true;
            var window = Activator.CreateInstance(typeof(PowerPointViewerDemo)) as Window;
            window.Show();
            base.OnStartup(e);
        }

    }
}
