using SimpleWebApi.Shared.Models;
using SimpleWebApi.Shared.Models.Response;

namespace SimpleWebApi.Services.Interfaces
{
    public interface IMovieService
    {
        ApiResponse<MovieResponse> GetMovie(string movieTitle);
    }
}
