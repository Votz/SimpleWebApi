using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Filters;
using SimpleWebApi.Services.Interfaces;
using SimpleWebApi.Shared.Models;
using SimpleWebApi.Shared.Models.Response;
using System.Security.Claims;

namespace SimpleWebApi.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        //[Authorize(Policy = "RequireAdministratorRole")]        
        //[Authorize(Policy = "EmployeeOnly")]        
        //[Authorize(Policy = "HumanResources")]
        [CustomAuthorize("Admin")]
        [HttpGet("[action]")]
        public ApiResponse<MovieResponse> GetMovie(string movieTitle)
        {
            return _movieService.GetMovie(movieTitle);
        }

    }
}
