using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Shared.Models.Request
{
    public class StudentRequest
    {
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

    }

    public class StudentRequestValidator : AbstractValidator<StudentRequest>
    {
        public StudentRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4);

            RuleFor(x => x.Lastname).NotEmpty().MinimumLength(4);

            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(9);

            RuleFor(x => x.PersonalNumber).NotEmpty().MinimumLength(11).Must(ValidatePersonalNumber);

            RuleFor(x => x.DateOfBirth).NotEmpty();
            
            RuleFor(x => x.Height).NotEmpty();

            RuleFor(x => x.Password).Matches(GetPasswordRegex());
        }

        public bool ValidatePersonalNumber(string personalNumber)
        {
            if(personalNumber.Length > 10 && personalNumber.Length > 12)
            {
                return true;
            }

            return false;
        }

        public string GetPasswordRegex()
        {
            return @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        }
    }
}
