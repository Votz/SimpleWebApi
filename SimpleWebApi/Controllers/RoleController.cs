using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Domain.Entities;
using SimpleWebApi.Shared.Models.Request;

namespace SimpleWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleInManager;
        
        //private readonly SignInManager<ApplicationRole> _roleInManager;
        


        public RoleController(RoleManager<ApplicationRole> roleInManager)
        {
            _roleInManager = roleInManager;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Create(RoleRequest model)
        {
            if (model is null)
                return BadRequest();

            var role = await _roleInManager.FindByNameAsync(model.Name);
            if (role is not null)
                return BadRequest();

            role = new ApplicationRole { Name = model.Name, NormalizedName = model.Name.ToLower() };

            var result = await _roleInManager.CreateAsync(role);
            if (result.Succeeded)
                return Ok();
            return BadRequest();

        }

    }
}
