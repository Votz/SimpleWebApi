using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Domain.Entities;
using SimpleWebApi.Shared.Models.Request;
using System.Security.Claims;

namespace SimpleWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorizationController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            if(model is null)
                return BadRequest();

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user is null)
                return BadRequest();

            var claims = new List<Claim>
            {
                new Claim("Role","Admin")
            };

            var userIdentity = new ClaimsIdentity(claims);

            var addClaimResult = await _userManager.AddClaimsAsync(user, claims);

            var checkPasswordResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, true);

            var principal = await _signInManager.CreateUserPrincipalAsync(user);
            //var principal = await _signInManager.(user);

            //var signInResult = SignIn(principal, "MyApp");
            //if (signInResult is null)
            //    return BadRequest();

            return SignIn(principal, "Identity.Application");
        }

    }
}
