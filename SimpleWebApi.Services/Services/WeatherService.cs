using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SimpleWebApi.Services.Interfaces;
using SimpleWebApi.Shared.Constants;
using SimpleWebApi.Shared.Models;
using SimpleWebApi.Shared.Models.Movie;
using SimpleWebApi.Shared.Models.Response;
using System.Net;

namespace SimpleWebApi.Services.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _client;
        private readonly IConfiguration _config;


        public WeatherService(IHttpClientFactory client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        

        public ApiResponse<WeatherResponse> GetCurrent(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///  Gets the Thirty Day Weather information From third-party API
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns> ApiResponse<WeatherResponse> </returns>
        /// <exception cref="NotImplementedException"></exception>
        public ApiResponse<WeatherResponse> GetThirtyDayWeather(double latitude, double longitude)
        {
            throw new NotImplementedException();
            #region 
            //if (latitude != 0 && longitude != 0)
            //{
            //    var apiKey = _config.GetSection("WeatherApiConfig").GetSection("ApiKey").Value;
            //    var fullPath = _config.GetSection("WeatherApiConfig").GetSection("BaseApiRoute").Value +
            //                   _config.GetSection("WeatherApiConfig").GetSection("CurrentWeatherRoute").Value +
            //                   $"?lat={latitude}&lon={longitude}&exclude=hourly,daily&appid={apiKey}";

            //    var client = _client.CreateClient("WeatherClient");

            //    using var request = new HttpRequestMessage(HttpMethod.Get, fullPath);

            //    var response = client.Send(request);
            //} 
            #endregion
        }
    }
}
