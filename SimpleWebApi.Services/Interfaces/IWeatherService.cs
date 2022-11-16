using SimpleWebApi.Shared.Models;
using SimpleWebApi.Shared.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Services.Interfaces
{
    public interface IWeatherService
    {
        ApiResponse<WeatherResponse> GetCurrent(double latitude, double longitude);
        ApiResponse<WeatherResponse> GetThirtyDayWeather(double latitude, double longitude);

    }
}
