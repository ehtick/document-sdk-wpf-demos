using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.markdowndemos.wpf
{
    public class MarkdownDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new MarkdownProductDemos());
            return productdemos;
        }
    }
    public class MarkdownProductDemos : ProductDemo
    {
        public MarkdownProductDemos()
        {
            this.Product = "Markdown";
            this.ProductCategory = "FILE FORMAT";
			Tag = Tag.New;
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M3.10254 0.00488281C3.60667 0.0562144 4 0.482323 4 1H12C12 0.447715 12.4477 0 13 0H15L15.1025 0.00488281C15.6067 0.0562144 16 0.482323 16 1V3L15.9951 3.10254C15.9438 3.60667 15.5177 4 15 4V12L15.1025 12.0049C15.6067 12.0562 16 12.4823 16 13V15L15.9951 15.1025C15.9438 15.6067 15.5177 16 15 16H13C12.4477 16 12 15.5523 12 15H4L3.99512 15.1025C3.94379 15.6067 3.51768 16 3 16H1C0.447715 16 0 15.5523 0 15V13C0 12.4477 0.447715 12 1 12V4C0.447715 4 0 3.55228 0 3V1C0 0.447715 0.447715 0 1 0H3L3.10254 0.00488281ZM1 15H3V13H1V15ZM13 15H15V13H13V15ZM4 3L3.99512 3.10254C3.94379 3.60667 3.51768 4 3 4H2V12H3L3.10254 12.0049C3.60667 12.0562 4 12.4823 4 13V14H12V13C12 12.4477 12.4477 12 13 12H14V4H13C12.4477 4 12 3.55228 12 3V2H4V3ZM5.74023 8.70703C5.823 8.94829 5.88305 9.19095 5.9209 9.43457H5.94238C6.00627 9.153 6.07355 8.90744 6.14453 8.69922L7.18457 5.69043H8.82129V10.7793H7.68848V7.73438C7.68848 7.40549 7.70305 7.04204 7.73145 6.64453H7.70312C7.64397 6.95686 7.59029 7.1821 7.54297 7.31934L6.35059 10.7793H5.41406L4.2002 7.35449C4.16707 7.26221 4.11339 7.02548 4.04004 6.64453H4.00781C4.03857 7.14608 4.05468 7.5863 4.05469 7.96484V10.7793H3.02148V5.69043H4.7002L5.74023 8.70703ZM11.3271 5.39453C11.6617 5.39453 11.9326 5.66547 11.9326 6V8.03027H12.6924C13.2317 8.03065 13.5016 8.68298 13.1201 9.06445L11.8662 10.3184C11.8053 10.4398 11.7062 10.5369 11.583 10.5947C11.4339 10.7183 11.2202 10.7187 11.0713 10.5947C10.9472 10.5364 10.8468 10.4382 10.7861 10.3154L9.53516 9.06445C9.15383 8.68297 9.42361 8.03066 9.96289 8.03027H10.7217V6C10.7217 5.66562 10.9928 5.39478 11.3271 5.39453ZM1 3H3V1H1V3ZM13 3H15V1H13V3Z"),
                Width = 16,
                Height = 16,
            };
            this.IsHighlighted = true;
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/FileFormat.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "A .NET Markdown library to create, read, and edit Markdown documents programmatically.";
            this.Demos = new List<DemoInfo>();
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Markdown Viewer.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Create Markdown",
                GroupName = "GETTING STARTED",
				Tag = Tag.New,
                Description = "This sample demonstrates how to create a Markdown document with various elements such as headings, text, images, lists, tables, hyperlinks, and code blocks using .NET Markdown library.",
                DemoViewType = typeof(CreateMarkdown)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Word To Markdown",
                GroupName = "CONVERSIONS",
				Tag = Tag.New,
                Description = "This sample demonstrates how to convert the Word document to Markdown using .NET Word (DocIO) and .NET Markdown libraries.",
	        DemoViewType = typeof(WordToMarkdown)
            });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Markdown To Word",
                GroupName = "CONVERSIONS",
				Tag = Tag.New,
                Description = "This sample demonstrates how to convert a Markdown file to a Word document using .NET Word (DocIO) and .NET Markdown libraries.",
	        DemoViewType = typeof(MarkdownToWord)
            });
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Markdown To HTML",
                GroupName = "CONVERSIONS",
				Tag = Tag.New,
                Description = "This sample demonstrates how to convert a Markdown file to HTML using .NET Word (DocIO) and .NET Markdown libraries.",
	        DemoViewType = typeof(MarkdownToHTML)
            });
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Markdown To PDF",
                GroupName = "CONVERSIONS",
				Tag = Tag.New,
                Description = "This sample demonstrates how to convert a Markdown file to PDF using .NET Word (DocIO), .NET Markdown, and .NET PDF libraries.",
	        DemoViewType = typeof(MarkdownToPDF)
            });
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "PPTX To Markdown",
                GroupName = "CONVERSIONS",
				Tag = Tag.New,
                Description = "This sample demonstrates how to convert the PowerPoint presentation to Markdown using .NET PowerPoint (Presentation) and .NET Markdown libraries.",
	        DemoViewType = typeof(PPTXToMarkdown)
            });
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Markdown To PPTX",
                GroupName = "CONVERSIONS",
				Tag = Tag.New,
                Description = "This sample demonstrates how to convert the Markdown file to PowerPoint presentation using .NET PowerPoint (Presentation) and .NET Markdown libraries.",
	        DemoViewType = typeof(MarkdownToPPTX)
            });
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Excel To Markdown",
                GroupName = "CONVERSIONS",
				Tag = Tag.New,
                Description = "This sample demonstrates how to convert an Excel file to a Markdown file using .NET Excel (XlsIO) and .NET Markdown libraries.",
	        DemoViewType = typeof(ExcelToMarkdown)
            });
			this.Demos.Add(new DemoInfo()
            {
                SampleName = "Markdown To Excel",
                GroupName = "CONVERSIONS",
				Tag = Tag.New,
                Description = "This sample demonstrates how to convert a Markdown file to an Excel worksheet using .NET Excel (XlsIO) and .NET Markdown libraries.",
	        DemoViewType = typeof(MarkdownToExcel)
            });
        }
    }
}

