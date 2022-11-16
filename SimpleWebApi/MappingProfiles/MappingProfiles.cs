using AutoMapper;
using SimpleWebApi.Domain.Entities;
using SimpleWebApi.Shared.Models.Request;
using SimpleWebApi.Shared.Models.Response;

namespace SimpleWebApi.MappingProfiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<GradeRequest, Grade>();

            CreateMap<Grade, GradeResponse>();

            CreateMap<StudentRequest, Student>();
            CreateMap<Student, StudentResponse>();

            CreateMap<GradeRequest, GradeResponse>();
        }

    }
}
