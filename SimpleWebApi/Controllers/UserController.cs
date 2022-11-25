using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Domain.Entities;
using SimpleWebApi.Services.Interfaces;
using SimpleWebApi.Shared.Models.Request;

namespace SimpleWebApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IAuthorizationService _authorization;
        public UserController(IAuthorizationService authorization)
        {
            _authorization = authorization;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                var userResult = await _authorization.RegisterUserAsync(model);
                return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);

            }
            return BadRequest(ModelState);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }

}
