using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Syncfusion.Presentation;
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.presentationdemos.wpf
{
    /// <summary>
    /// Interaction logic for MarkdownToPPTX.xaml
    /// </summary>
    public partial class MarkdownToPPTX : DemoControl
    {
        public MarkdownToPPTX()
        {
            InitializeComponent();
            this.txtFile.Text = "MarkdownToPPTX.md";
            this.txtFile.Tag = @"Assets\Presentation\MarkdownToPPTX.md";
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
            openFileDialog1.InitialDirectory = Path.GetFullPath(@"Assets\Presentation\");
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "MarkdownToPPTX files (*.md)|*.md;";
            Nullable<bool> result = openFileDialog1.ShowDialog();

            //Get the selected file name and display in a TextBox
            if (result == true)
            {
                this.txtFile.Text = openFileDialog1.SafeFileName;
                this.txtFile.Tag = openFileDialog1.FileName;
            }
        }

        private void btnMarkdownToPres_Click(object sender, EventArgs e)
        {
            //Open the Markdown document.
            using (IPresentation presentation = Presentation.Open(txtFile.Tag.ToString()))
            {
                //Saves the presentation
                presentation.Save("MarkdownToPPTX.pptx");
            }
            if (System.Windows.MessageBox.Show("Do you want to view the generated Presentation?", "Presentation Created",
                  MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("MarkdownToPPTX.pptx") { UseShellExecute = true };
                process.Start();
            }
        }
    }
}

