using SimpleWebApi.Shared.Models;
using SimpleWebApi.Shared.Models.Request;
using SimpleWebApi.Shared.Models.Response;

namespace SimpleWebApi.Services.Interfaces
{
    public interface IGradeService
    {
        ApiResponse<IEnumerable<GradeResponse>> GetAll();

        ApiResponse<GradeResponse> GetById(int id);

        ApiResponse<GradeResponse> Update(int id, GradeRequest model);

        ApiResponse<GradeResponse> Create(GradeRequest model);

        ApiResponse<bool> Delete(int id);
    }
}
