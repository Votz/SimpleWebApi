using Microsoft.AspNetCore.Identity;

namespace SimpleWebApi.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid> 
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
