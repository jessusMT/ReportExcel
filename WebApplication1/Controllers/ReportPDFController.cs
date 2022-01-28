using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportPDFController : ControllerBase
    {
        private readonly ILogger<ReportPDFController> _logger;
        public ReportPDFController(ILogger<ReportPDFController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPDFGraph()
        {
            //Workbook wb = new Workbook();
            //Worksheet sheet = wb.Worksheets[0];

            //Chart chart = sheet.Charts.Add();

            //var series = chart.Series.Add();

            //series.EnteredDirectlyValues = new object[] { 10, 20, 30 };
            Workbook workbook = new Workbook();
            workbook.Worksheets.Clear();
            var sheet = workbook.Worksheets.Add("Sheet1");
            
            DataTable dt = CreateTable();
            sheet.InsertDataTable(dt, false, 1, 1);
            Chart chart = sheet.Charts.Add();
            chart.ChartType = ExcelChartType.ColumnClustered;
            chart.DataRange = sheet.AllocatedRange;
            chart.SeriesDataFromRange = false;
            chart.Height = 220;
            chart.Width = 450;
            chart.Left = 0;
            chart.Top = 100;
            chart.ChartTitle = "Sales market by country";
            chart.ChartTitleArea.IsBold = true;
            chart.ChartTitleArea.Size = 12;

            //workbook.Worksheets[1].Remove();
            workbook.SaveToFile("CreateChart.xlsx", ExcelVersion.Version2007);
            workbook.LoadFromFile("CreateChart.xlsx", ExcelVersion.Version2007);            
            workbook.SaveToFile("demo.pdf", Spire.Xls.FileFormat.PDF);
            
            //workbook.SaveToFile("CreateChart.xlsx", ExcelVersion.Version2007);

            //PdfDocument pdfDocument = new PdfDocument();
            //pdfDocument.PageSettings.Orientation = PdfPageOrientation.Landscape;
            //pdfDocument.PageSettings.Width = 970;
            //pdfDocument.PageSettings.Height = 850;

            //PdfConverter pdfConverter = new PdfConverter(workbook);
            //PdfConverterSettings settings = new PdfConverterSettings();
            //settings.TemplateDocument = pdfDocument;
            //pdfDocument = pdfConverter.Convert(settings);


           // workbook.SaveToFile("sample.pdf");


            Stream outStream = new MemoryStream();
            var fileName = "demo.pdf";
            var contentType = "application/pdf";
            workbook.SaveToStream(outStream, Spire.Xls.FileFormat.PDF);
            outStream.Position = 0;

            return File(outStream, contentType, fileName);
        }

        private static DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Month", typeof(string));
            dt.Columns.Add("Count", typeof(int));
            dt.Rows.Add("January", 10);
            dt.Rows.Add("February", 20);
            dt.Rows.Add("March", 30);
            dt.Rows.Add("April", 40);
            dt.Rows.Add("May", 50);
            return dt;
        }
        //public static void CreateChart()
        //{
        //    Workbook workbook = new Workbook();
        //    workbook.Worksheets.Clear();
        //    var sheet = workbook.Worksheets.Add("Sheet1");
        //    DataTable dt = CreateTable();
        //    sheet.InsertDataTable(dt, false, 1, 1);
        //    Chart chart = sheet.Charts.Add();
        //    chart.ChartType = ExcelChartType.ColumnClustered;
        //    chart.DataRange = sheet.AllocatedRange;
        //    chart.SeriesDataFromRange = false;
        //    chart.Height = 220;
        //    chart.Width = 450;
        //    chart.Left = 0;
        //    chart.Top = 100;
        //    workbook.SaveToFile("CreateChart.xlsx", ExcelVersion.Version2007);
        //}



    }
}
