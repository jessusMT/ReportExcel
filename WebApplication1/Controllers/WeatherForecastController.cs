using jsreport.AspNetCore;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        public IJsReportMVCService JsReportMVCService { get; }


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IJsReportMVCService jsReportMVCService)
        {
            _logger = logger;
            JsReportMVCService = jsReportMVCService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
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
        //    var contentDisposition = "attachment; filename=\"myReport.pdf\"";

        //    var file = HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf)
        //                    .OnAfterRender((r) => HttpContext.Response.Headers["Content-Disposition"] = contentDisposition);


        //    return File(report.Content, contentDisposition);
        //}


    }
}
