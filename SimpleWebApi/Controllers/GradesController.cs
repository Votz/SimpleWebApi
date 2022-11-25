using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Services.Interfaces;
using SimpleWebApi.Shared.Models;
using SimpleWebApi.Shared.Models.Request;
using SimpleWebApi.Shared.Models.Response;

namespace SimpleWebApi.Controllers
{
    //[Authorize(AuthenticationSchemes = "Identity.Application")]
    
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        
        [HttpPost("[action]")]
        public ApiResponse<GradeResponse> CreateGrade([FromBody] GradeRequest model)
        {
            return _gradeService.Create(model);
        }

        
        [HttpGet("[action]")]
        public ApiResponse<List<GradeResponse>> GetAllGrades()
        {
            return _gradeService.GetAll();
        }

        //[AllowAnonymous]
        [HttpGet("[action]")]
        public ApiResponse<bool> DeleteGrade(int id)
        {
            return _gradeService.Delete(id);
        }
        
        [HttpPost("[action]")]
        public ApiResponse<GradeResponse> UpdateGrade(int id,[FromBody] GradeRequest model)
        {
            return _gradeService.Update(id,model);
        }

        [HttpGet("[action]")]
        public ApiResponse<GradeResponse> GetGradeById(int id)
        {
            return _gradeService.GetById(id);
        }
    }
}
