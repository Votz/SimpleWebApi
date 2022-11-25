using System.ComponentModel.DataAnnotations;

namespace SimpleWebApi.Shared.Models.Request
{
    public class RegisterRequest
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? PhoneNumber { get; init; }

    }
}
