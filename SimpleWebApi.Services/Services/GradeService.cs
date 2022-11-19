using AutoMapper;
using FluentValidation;
using SimpleWebApi.Domain.Context;
using SimpleWebApi.Domain.Entities;
using SimpleWebApi.Services.Interfaces;
using SimpleWebApi.Shared.Constants;
using SimpleWebApi.Shared.Enumerations;
using SimpleWebApi.Shared.Models;
using SimpleWebApi.Shared.Models.Request;
using SimpleWebApi.Shared.Models.Response;
using System.Net;

namespace SimpleWebApi.Services.Services
{
    public class GradeService : IGradeService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private IValidator<GradeRequest> _validator;

        public GradeService(ApplicationContext context, IMapper mapper, IValidator<GradeRequest> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public ApiResponse<GradeResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<GradeResponse> Create(GradeRequest model)
        {
            var validationResult = _validator.Validate(model);

            if (!validationResult.IsValid)
                return ApiResponse<GradeResponse>.ValidationError(validationResult.Errors, _mapper.Map<GradeResponse>(model));
            try
            {
                var newRecord = _mapper.Map<Grade>(model);

                var result = _context.Grades.Add(newRecord);

                throw new NotImplementedException();

                _context.SaveChanges();

                if (newRecord.Id > 0)
                {
                    return ApiResponse<GradeResponse>.Success(_mapper.Map<GradeResponse>(newRecord));
                }
                return ApiResponse<GradeResponse>.Failed("Could not create object based on your request");

            }
            catch (Exception ex)
            {
                //TODO : Log Information
                return ApiResponse<GradeResponse>.Exception(ex.Message);
            }

            //წარმატებული ოპერაციის შედგად უნდა დაბრუნდეს ახალი APIResponse წარმატებული სტატუსითა და ახალი ობიექტით
            //წარუმატებელი ოპერაციის შედეგად უნდა დაბრუნდეს ხარვეზები თუ დაფიქსირდა რაიმე
            //წარუმატებელი ოპერაცია ვალიდაციის შედეგად მიღებული ხარვეზების დამუშავება
        }

        public ApiResponse<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<List<GradeResponse>> GetAll()
        {
            var grades = _context.Grades.Select(x => new GradeResponse
            {
                Id = x.Id,
                Name = x.Name,
                Score = x.Score
            }).ToList();
            return ApiResponse<List<GradeResponse>>.Success(grades);
            //return ApiResponse<List<GradeResponse>>.Success(_mapper.Map<List<GradeResponse>>(grades));
        }

        public ApiResponse<GradeResponse> Update(int id, GradeRequest model)
        {
            throw new NotImplementedException();
        }


    }
}
