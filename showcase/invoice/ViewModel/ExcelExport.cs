﻿using Syncfusion.XlsIO;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;

namespace syncfusion.invoice.wpf
{
    public class ExportToExcel
    {
        public  void GenerateReport(IList<InvoiceItem> items, BillingInformation billInfo)
        {
            Assembly assembly = typeof(ExportToExcel).Assembly;
            Stream inputStream = assembly.GetManifestResourceStream("syncfusion.invoice.wpf.Assets.InvoiceTemplate.xlsx");
            ExcelEngine excelEngine = new ExcelEngine();
            IWorkbook book = excelEngine.Excel.Workbooks.Open(inputStream);
            inputStream.Dispose();

            //Create Template Marker Processor
            ITemplateMarkersProcessor marker = book.CreateTemplateMarkersProcessor();
            //Binding the business object with the marker.
            marker.AddVariable("InvoiceItem", items);
            marker.AddVariable("BillInfo", billInfo);
            marker.AddVariable("Company", billInfo);
            //Applies the marker.
            marker.ApplyMarkers(UnknownVariableAction.Skip);

            book.SaveAs("Invoice.xlsx");

            //Save as Docx format
            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the Excel file?", "Excel Document  Created",
                 MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Invoice.xlsx") { UseShellExecute = true };
                process.Start();
            }
            book.Close();
            excelEngine.Dispose();

            

        }
    }
}
