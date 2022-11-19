using Microsoft.AspNetCore.Authorization;
using SimpleWebApi.Requirements;
using System.Security.Claims;

namespace SimpleWebApi.RequirementHandler
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        private readonly ILogger _logger;

        public MinimumAgeHandler(ILogger logger)
        {
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            var dateOfBirthClaim = context.User.FindFirst(
                c => c.Type == ClaimTypes.DateOfBirth && c.Issuer == "MyApp");
                
            if(dateOfBirthClaim is null)
            {
                return Task.CompletedTask;
            }

            var dateOfBirth = Convert.ToDateTime(dateOfBirthClaim.Value);
            int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
            {
                calculatedAge--;
            }

            if (calculatedAge >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
                //context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
