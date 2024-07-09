using Microsoft.AspNetCore.Mvc;
using System;

namespace SDA_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<WeatherForecast> WeatherForecasts()
        {
            var list = new List<WeatherForecast>
            {
                new WeatherForecast
                { 
                    Id = 1,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), 
                    Summary = "Hot", 
                    TemperatureC = 32 
                },
                new WeatherForecast
                {
                    Id = 2,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                    Summary = "Very hot",
                    TemperatureC = 37
                },
                new WeatherForecast
                {
                    Id = 3,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                    Summary = "Hot",
                    TemperatureC = 31
                }
                ,
                new WeatherForecast
                {
                    Id = 4,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(4)),
                    Summary = "Warm",
                    TemperatureC = 30
                },
                new WeatherForecast
                {
                    Id = 5,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                    Summary = "Warm",
                    TemperatureC = 27
                }
            };
            return list;
        }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        public IEnumerable<WeatherForecast> Get()
        {
            var list = WeatherForecasts();
            return list;
        }

        [HttpGet("BySummary/{summary}")]
        public ActionResult GetWeatherForecastBySummary(string summary)
        {
            var list = WeatherForecasts()
                .Where(x => string.Equals(x.Summary, summary, StringComparison.OrdinalIgnoreCase));
            if (list?.Count() > 0)
            {
                return new OkObjectResult(list);
            }
            else return new NoContentResult();           
        }

        [HttpGet("BySummary")]
        public IEnumerable<WeatherForecast> GetWeatherForecastBySummary2([FromQuery] string summary)
        {
            var list = WeatherForecasts()
                .Where(x => string.Equals(x.Summary, summary, StringComparison.OrdinalIgnoreCase));
            return list;
        }


        [HttpGet("{id}")]
        public ActionResult GetWeatherForecastById(int id)
        {
            var item = WeatherForecasts().FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                return new OkObjectResult(item);
            }
            else return new NotFoundResult();
        }
    }
}
