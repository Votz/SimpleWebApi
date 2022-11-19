using Microsoft.AspNetCore.Identity;

namespace SimpleWebApi.Domain.Entities
{
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        //დავამატო Custom თვისებები, ან გამოვიყენო იმპლემენტაცია რაც მხვდება IdentityUserRole
    }
}
