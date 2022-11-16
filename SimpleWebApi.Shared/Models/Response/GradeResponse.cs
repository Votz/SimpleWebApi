using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Shared.Models.Response
{
    public class GradeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public IEnumerable<StudentResponse> Students { get; set; }

    }
}
