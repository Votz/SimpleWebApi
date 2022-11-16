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
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.y)) bla bla bla;

            CreateMap<Grade, GradeResponse>();

            CreateMap<StudentRequest, Student>();
            CreateMap<Student, StudentResponse>();

            CreateMap<GradeRequest, GradeResponse>();
        }

    }
}
