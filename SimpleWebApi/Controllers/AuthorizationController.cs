using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Domain.Entities;
using SimpleWebApi.Services.Interfaces;
using SimpleWebApi.Shared.Models.Request;
using System.Security.Claims;

namespace SimpleWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorization;   
        public AuthorizationController(IAuthorizationService authorization)
        {
            _authorization = authorization;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            return !await _authorization.ValidateUserAsync(model)
                ? Unauthorized()
                : Ok(new { Token = await _authorization.CreateTokenAsync(model.Username)});

        }


    }
}
