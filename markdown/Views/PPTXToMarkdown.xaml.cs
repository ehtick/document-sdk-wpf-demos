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

namespace syncfusion.markdowndemos.wpf
{
    /// <summary>
    /// Interaction logic for PPTXToMarkdown.xaml
    /// </summary>
    public partial class PPTXToMarkdown : DemoControl
    {
        public PPTXToMarkdown()
        {
            InitializeComponent();
            this.txtFile.Text = "PPTXToMarkdown.pptx";
            this.txtFile.Tag = @"Assets\Markdown\PPTXToMarkdown.pptx";
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
            openFileDialog1.InitialDirectory = Path.GetFullPath(@"Assets\Markdown\");
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "PowerPoint Presentations|*.pptx";
            Nullable<bool> result = openFileDialog1.ShowDialog();

            //Get the selected file name and display in a TextBox
            if (result == true)
            {
                this.txtFile.Text = openFileDialog1.SafeFileName;
                this.txtFile.Tag = openFileDialog1.FileName;
            }
        }

        private void btnPresToMarkdown_Click(object sender, EventArgs e)
        {
            //New Instance of PowerPoint is Created.[Equivalent to launching MS PowerPoint with no slides].
            using (IPresentation presentation = Presentation.Open(txtFile.Tag.ToString()))
            {
                //Saves the presentation as Markdown.
                presentation.Save("PPTXToMarkdown.md");
            }
            if (System.Windows.MessageBox.Show("Do you want to view the generated Markdown Document?", "Markdown document Created",
                  MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("PPTXToMarkdown.md") { UseShellExecute = true };
                process.Start();
            }
        }
    }
}

