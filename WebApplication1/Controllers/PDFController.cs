using jsreport.AspNetCore;
using jsreport.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PDFController : ControllerBase
    {
        public readonly IJsReportMVCService JsReportMVCService;

        private readonly ILogger<PDFController> _logger;

        public PDFController(ILogger<PDFController> logger, IJsReportMVCService jsReportMVCService)
        {
            _logger = logger;
            JsReportMVCService = jsReportMVCService;
        }


        //[HttpGet]
        //public async Task<IActionResult> GetPDF()
        //{
        //    var report = await JsReportMVCService.RenderAsync(new RenderRequest()
        //    {
        //        Template = new Template
        //        {
        //            Content = "<h1>Hello world</h1>",
        //            Engine = Engine.None,
        //            Recipe = Recipe.ChromePdf
        //        }
        //    });

        //    if (report is null)
        //    {
        //        return BadRequest();
        //    }

        //    return File(report.Content, "application/pdf", "SalesReport.pdf");
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetPDFChart()
        //{
        //    var path = "C:/Users/dotad/OneDrive/Documentos/Repositories/WebApplication1/WebApplication1/Views/ChartJs.cshtml";
        //    var filePDFRead = Convert.ToString(System.IO.File.ReadAllText(path));
        //    var report = await JsReportMVCService.RenderAsync(new RenderRequest()
        //    {
        //        Template = new Template
        //        {
        //            Content = filePDFRead.ToString(),
        //            Engine = Engine.None,
        //            Recipe = Recipe.ChromePdf
        //        }
        //    });

        //    if (report is null)
        //    {
        //        return BadRequest();
        //    }

        //    return File(report.Content, "application/pdf", "SalesReport.pdf");
        //}
        [HttpGet]
        public async Task<IActionResult> GetPDFChart()
        {
            var path = "C:/Users/dotad/OneDrive/Documentos/Repositories/WebApplication1/WebApplication1/Views/ChartJs.cshtml";
            var filePDFRead = Convert.ToString(System.IO.File.ReadAllText(path));
            var report = await JsReportMVCService.RenderAsync(new RenderRequest()
            {
                Template = new Template
                {
                    Content = filePDFRead.ToString(),
                    Engine = Engine.None,
                    Recipe = Recipe.ChromePdf

                }
            });
            //var algo = HttpContext.JsReportFeature()
            //     .Recipe(Recipe.ChromePdf)
            //     //.OnAfterRender((r) => HttpContext.Response.b)
            //     .Configure(cfg =>
            //     {
            //         cfg.Template = new Template { Content = filePDFRead.ToString() };
            //         cfg.Template.Chrome = new Chrome
            //         {
            //             WaitForJS = true
            //         };
            //     });
           
            //var algo = HttpContext.JsReportFeature()
            //    .Recipe(Recipe.ChromePdf)
            //    .Configure(cfg =>
            //    {
            //        cfg.Template = new Template { Content = filePDFRead.ToString() };
            //        cfg.Template.Chrome = new Chrome
            //        {
            //            WaitForJS = true
            //        };
            //    });

            //if (report is null)
            //{
            //    return BadRequest();
            //}

            return File(report.Content, "application/pdf", "SalesReport.pdf");
        }
    }
}
