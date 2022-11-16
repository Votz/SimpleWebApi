using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Shared.Models.Response
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        public GradeResponse Grade { get; set; }

    }
}
