using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Shared.Models.Request
{
    public class GradeRequest
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class GradeRequestValidator : AbstractValidator<GradeRequest>
    {
        public GradeRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4);

            RuleFor(x => x.Score).NotEmpty();

        }
    }
}
