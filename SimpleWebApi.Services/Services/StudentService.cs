using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Domain.Context;
using SimpleWebApi.Services.Interfaces;
using SimpleWebApi.Shared.Models.Request;
using SimpleWebApi.Shared.Models.Response;

namespace SimpleWebApi.Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationContext _context;
        

        //var apiRoute = builder.Configuration["ApiRoute"];
        //System.Net.Http
        public StudentService(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentResponse> GetAll()
        {
            var studentList = _context.Students
                                      .Include(x => x.Grade)
                                      .Select(x => new StudentResponse()
                                      {
                                          Id = x.Id,
                                          Email = x.Email,
                                          Name = x.Name,
                                          Lastname = x.Lastname,
                                          Height = x.Height,
                                          PhoneNumber = x.PhoneNumber,
                                          Grade = new GradeResponse()
                                          {
                                              Name = x.Grade.Name,
                                              Id = x.Grade.Id,
                                              Score = x.Grade.Score
                                          }
                                      })
                                      .ToList();

            throw new NotImplementedException();

            if(studentList != null)
            {
                return studentList;
            }

            return new List<StudentResponse>();
        }
       
        public StudentResponse Update(int id, StudentRequest model)
        {
            throw new NotImplementedException();
        }

        public StudentResponse Create(StudentRequest model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public StudentResponse GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
