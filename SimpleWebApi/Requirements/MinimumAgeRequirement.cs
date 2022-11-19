using Microsoft.AspNetCore.Authorization;

namespace SimpleWebApi.Requirements
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; }

        public MinimumAgeRequirement(int minimumAge) =>
            MinimumAge = minimumAge;

    }
}
