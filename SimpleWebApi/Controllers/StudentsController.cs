using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Services.Interfaces;
using SimpleWebApi.Shared.Models.Request;
using SimpleWebApi.Shared.Models.Response;

namespace SimpleWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private IValidator<StudentRequest> _validation;
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService, IValidator<StudentRequest> validation)
        {
            _studentService = studentService;
            _validation = validation;
        }

        [HttpGet("[action]")]
        public IEnumerable<StudentResponse> GetAll()
        {
            return _studentService.GetAll();
        }

        [HttpPost("[action]")]
        public StudentResponse Create([FromBody] StudentRequest model)
        {
            var result = _validation.Validate(model);

            if(result.IsValid)
                return _studentService.Create(model);
            else
            {
                return _studentService.Create(model);
            }
        }

        [HttpGet("[action]")]
        public bool Delete(int id)
        {
            return _studentService.Delete(id);
        }

        [HttpPost("[action]")]
        public StudentResponse Update(int id, [FromBody] StudentRequest model)
        {
            return _studentService.Update(id, model);
        }

        [HttpGet("[action]")]
        public StudentResponse GetById(int id)
        {
            return _studentService.GetById(id);
        }
    }
}
