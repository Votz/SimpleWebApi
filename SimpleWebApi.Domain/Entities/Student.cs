using SimpleWebApi.Shared.Enumerations;

namespace SimpleWebApi.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public double Weight { get; set; }

        public Grade Grade { get; set; }
    }
}
