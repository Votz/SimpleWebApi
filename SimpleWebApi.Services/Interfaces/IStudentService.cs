using SimpleWebApi.Domain.Entities;
using SimpleWebApi.Shared.Models.Request;
using SimpleWebApi.Shared.Models.Response;

namespace SimpleWebApi.Services.Interfaces
{
    public interface IStudentService
    {
        //CRUD Operations on Student Entity

        IEnumerable<StudentResponse> GetAll();

        StudentResponse GetById(int id);

        StudentResponse Update(int id, StudentRequest model);

        StudentResponse Create(StudentRequest model);

        bool Delete(int id);
    }
}
