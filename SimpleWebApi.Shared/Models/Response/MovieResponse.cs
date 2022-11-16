using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Shared.Models.Response
{
    public class MovieResponse
    {
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Released { get; set; }
        public string Genre { get; set; }

    }
}
