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
    public class MovieService : IMovieService
    {
        private readonly IHttpClientFactory _client;
        private readonly IConfiguration _config;

        public MovieService(IHttpClientFactory client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        public ApiResponse<MovieResponse> GetMovie(string movieTitle)
        {

            if (!string.IsNullOrWhiteSpace(movieTitle))
            {
                var fullPath = _config.GetSection("MovieApiConfig").GetSection("MovieApiRoute").Value +
                               $"&t={movieTitle}";

                var client = _client.CreateClient("MovieClient");

                using var request = new HttpRequestMessage(HttpMethod.Get, fullPath);

                var response = client.Send(request);

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStream();
                    StreamReader reader = new StreamReader(content);
                    string text = reader.ReadToEnd();

                    if (!string.IsNullOrEmpty(text))
                    {
                        var movieData = JsonConvert.DeserializeObject<Movie>(text);

                        return new ApiResponse<MovieResponse>()
                        {
                            Model = new MovieResponse()
                            {
                                Director = movieData.Director,
                                Genre = movieData.Genre,
                                Released = movieData.Released,
                                Writer = movieData.Writer
                            },
                            Status = (int)HttpStatusCode.OK,
                        };
                    }
                }

            }

            return new ApiResponse<MovieResponse>()
            {
                Status = (int)HttpStatusCode.NotModified,
                StatusMessage = ErrorMessages.ObjectCouldNotBeAdded,
            };

        }

    }
}
