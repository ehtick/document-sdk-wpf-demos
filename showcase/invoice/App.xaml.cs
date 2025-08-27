using System;
using System.Windows;

namespace syncfusion.invoice.wpf.app
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = Activator.CreateInstance(typeof(InvoiceDemo)) as Window;
            window.Show();
            base.OnStartup(e);
        }
    }
}
