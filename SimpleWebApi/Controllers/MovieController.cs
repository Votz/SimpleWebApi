using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Services.Interfaces;
using SimpleWebApi.Shared.Models;
using SimpleWebApi.Shared.Models.Response;

namespace SimpleWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public MovieController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
    }
}
