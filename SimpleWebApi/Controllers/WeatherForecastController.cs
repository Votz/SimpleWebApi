using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Services.Interfaces;

namespace SimpleWebApi.Controllers
{
    //SRP - Single Responsibility Principle
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //Connect to DB - Domain
            //Get Data from DB - Services
            //Process DB Info - Services
            //Return info to user - Api

            _weatherService.GetThirtyDayWeather(13,13);

            var guid = new Guid();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index++,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        }

        [HttpPost(Name = "PostWeatherForecast")]
        public IEnumerable<WeatherForecast> Post()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpDelete(Name = "DeleteWeatherForecast")]
        public IEnumerable<WeatherForecast> Delete()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPut(Name = "PutWeatherForecast")]
        public IEnumerable<WeatherForecast> Put()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

//CRUD - Create, Read, Update, Delete