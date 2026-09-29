#region Copyright Syncfusion Inc. 2001 - 2017
//
//  Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion
using System;
using System.Windows;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using System.IO;
using Syncfusion.Office;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.Drawing;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditInk : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public EditInk()
        {
            InitializeComponent();
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        # region Events
        /// <summary>
        /// Creates word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get XML file path.
                string dataPath = @"Assets\DocIO\";

                //Opens an existing Word document
                using (WordDocument document = new WordDocument(dataPath + "EditInkInput.docx"))
                {
                    // Access the first section of the document.
                    WSection section = document.Sections[0];

                    // Access the first ink and customize its trace points.
                    WInk firstInk = section.Paragraphs[0].ChildEntities[0] as WInk;
                    // Move the ink vertically.
                    firstInk.VerticalPosition = 25f;
                    // Copy existing points into the new array.
                    int oldTracePointsLength = firstInk.Traces[0].Points.Length;
                    int newTracePointsLength = oldTracePointsLength + 3;
                    PointF[] newTracePoints = new PointF[newTracePointsLength];
                    PointF[] oldTracePoints = firstInk.Traces[0].Points;
                    Array.Copy(oldTracePoints, newTracePoints, oldTracePointsLength);
                    newTracePoints[newTracePoints.Length - 3] = new PointF(oldTracePoints[3].X, 0);
                    newTracePoints[newTracePoints.Length - 2] = new PointF(oldTracePoints[0].X, 0);
                    newTracePoints[newTracePoints.Length - 1] = new PointF(oldTracePoints[0].X, oldTracePoints[0].Y);
                    // Update the trace points of the first ink with the new array.
                    firstInk.Traces[0].Points = newTracePoints;

                    // Access the second ink and customize its brush effect.
                    WInk secondInk = section.Paragraphs[1].ChildEntities[0] as WInk;
                    IOfficeInkTrace secondInkTrace = secondInk.Traces[0];
                    // Set the ink size (thickness) to 1 point.
                    secondInkTrace.Brush.Size = new SizeF(1f, 1f);

                    // Access the third ink and customize its container width.
                    WInk thirdInk = section.Paragraphs[2].ChildEntities[0] as WInk;
                    // Set the width of the ink container to 130 points.
                    thirdInk.Width = 130f;

                    // Access the fourth ink and customize its brush color.
                    WParagraph paragraph = section.Tables[0].Rows[0].Cells[0].ChildEntities[0] as WParagraph;
                    WInk fourthInk = paragraph.ChildEntities[0] as WInk;
                    IOfficeInkTrace fourthInkTrace = fourthInk.Traces[0];
                    // Set the color of the ink stroke to Yellow.
                    fourthInkTrace.Brush.Color = Color.Yellow;

                    //Save as docx format
                    if (worddocx.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document as .docx
                            document.Save("EditInk.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("EditInk.docx") { UseShellExecute = true };
                                    process.Start();
                                }
                                catch (Win32Exception ex)
                                {
                                    MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\EditInk.docx" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //Save as pdf format
                    else if (pdf.IsChecked.Value)
                    {
                        try
                        {
                            DocToPDFConverter converter = new DocToPDFConverter();
                            //Convert word document into PDF document
                            PdfDocument pdfDoc = converter.ConvertToPDF(document);
                            //Save the pdf file
                            pdfDoc.Save("EditInk.pdf");
                            converter.Dispose();
                            pdfDoc.Close();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("EditInk.pdf") { UseShellExecute = true };
                                    process.Start();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("PDF Viewer is not installed in this system");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\EditInk.pdf" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Opens the template document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to view the template document?", "Template document", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Opens the template document.
                string path = System.IO.Path.Combine(@"Assets\DocIO\EditInkInput.docx");
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true };
                process.Start();
            }
        }
#endregion
    }
}