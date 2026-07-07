#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.XlsIO;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using System.IO;

namespace syncfusion.markdowndemos.wpf
{
    /// <summary>
    /// Interaction logic for ExcelToMarkdown.xaml
    /// </summary>
    public partial class ExcelToMarkdown : DemoControl
    {
        #region Private Members
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private string fullPath;
        #endregion

        #region Constructor
        /// <summary>
        /// ExcelToMarkdown constructor
        /// </summary>
        public ExcelToMarkdown()
        {
            InitializeComponent();
            string path = @"Assets\Markdown\";
            fullPath = @"Assets\Markdown\";
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            openFileDialog1.Filter = "Excel Files (*.xls *.xlsx *.xlsm)|*.xls;*.xlsx;*.xlsm";
            this.textBox1.Text = "ExcelToMarkdownTemplate.xlsx";
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            fullPath = null;
            openFileDialog1 = null;
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Browse document to export to Markdown
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                this.textBox1.IsReadOnly = true;
                fullPath = openFileDialog1.FileName;
            }
        }
        #endregion Browse document to export to Markdown

        #region Events
        /// <summary>
        /// Convert To Markdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcelToMarkdown_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text != String.Empty && fullPath != string.Empty)
            {
                if (!this.textBox1.Text.EndsWith(".xls") && !this.textBox1.Text.EndsWith(".xlsx") &&
                    !this.textBox1.Text.EndsWith(".xlsm") && !this.textBox1.Text.EndsWith(".xltm") &&
                    !this.textBox1.Text.EndsWith(".xltx") && !this.textBox1.Text.EndsWith(".tsv"))
                {
                    MessageBox.Show("Browse an Excel to convert to Markdown", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (fullPath.EndsWith("\\"))
                    fullPath += this.textBox1.Text;
                if (File.Exists(fullPath))
                {
                    try
                    {
                        ExcelEngine excelEngine = new ExcelEngine();
                        IWorkbook workbook = excelEngine.Excel.Workbooks.Open(fullPath, ExcelOpenType.Automatic);
                        string fileName = "ExcelToMarkdown.md";
                        workbook.SaveAs(fileName, ExcelSaveType.Markdown);
                        workbook.Close();
                        excelEngine.Dispose();

                        //Message box confirmation to view the created spreadsheet.
                        if (MessageBox.Show("Do you want to view the Markdown file?", "Markdown file has been created",
                            MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the Markdown file using the default Application
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName) { UseShellExecute = true };
                                process.Start();
                            }
                            catch (Win32Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("File doesn’t exist");
                }
            }
            else
                MessageBox.Show("Browse a Excel to convert to Markdown", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion
    }
}