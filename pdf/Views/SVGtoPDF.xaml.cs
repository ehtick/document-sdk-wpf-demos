#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Shapes;
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Windows.Shared;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SVGtoPDF : DemoControl
    {
        # region Private Members
        private string m_fullPath;
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public SVGtoPDF()
        {
		   
            InitializeComponent();

            m_fullPath = @"Assets\PDF\SVGtoPDF.svg";
            textBox1.Text = "SVGtoPDF.svg";
        }
        #endregion
        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        # endregion
        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTopdf_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                System.Windows.MessageBox.Show("Please select a SVG Image");
                textBox1.Focus();
            }
            else
            {
                // Validate the SVG file size (maximum 10 MB).
                if (System.IO.File.Exists(m_fullPath))
                {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(m_fullPath);
                    if (fileInfo.Length > 10 * 1024 * 1024)
                    {
                        System.Windows.MessageBox.Show("The selected SVG file exceeds the maximum allowed size of 10 MB.", "File Size Limit Exceeded",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("The SVG file could not be found. Please select a valid SVG Image.", "File Not Found",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    textBox1.Focus();
                    return;
                }

                // Initialize SVG converter.
                SvgConverter converter = new SvgConverter();

                //Convert the SVG file to PDF template.
                PdfTemplate temp = converter.Convert(m_fullPath);

                //Create a new PDF document and draw the PDF template to the page.
                PdfDocument document = new PdfDocument();
                document.PageSettings.Margins.All = 0;
                document.PageSettings.Size = new SizeF(temp.Width, temp.Height);
                PdfPage page = document.Pages.Add();

                //Draw the PDF template to the page.
                page.Graphics.DrawPdfTemplate(temp, new PointF(0, 0), new SizeF(temp.Width, temp.Height));

                // Save & close the pdf file.
                document.Save("SVGtoPDF.pdf");
                document.Close(true);

                //Message box confirmation to view the created PDF document.
                if (System.Windows.MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("SVGtoPDF.pdf") { UseShellExecute = true };
                    process.Start();
                }

            }
        }

        /// <summary>
        /// Gets the source document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog();
            file.Filter = "SVG Images (*.svg)|*.SVG";
            file.Title = "Choose SVG Image";

            if (file.ShowDialog().Value)
            {
                textBox1.Text = file.SafeFileName;
                m_fullPath = file.FileName;
            }
        }

        # endregion
    }
}
