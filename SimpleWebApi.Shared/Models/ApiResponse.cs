using System.Net;
using FluentValidation.Results;

namespace SimpleWebApi.Shared.Models
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string StatusMessage { get; set; }
        public ApiError Error { get; set; }

    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Model { get; set; }

        public static ApiResponse<T> Success(T model)
        {
            return new ApiResponse<T>()
            {
                Status = (int)HttpStatusCode.OK,
                Model = model
            };
        }

        public static ApiResponse<T> ValidationError(IEnumerable<ValidationFailure> errors, T model)
        {
            return new ApiResponse<T>()
            {
                Status = (int)HttpStatusCode.BadRequest,
                Error = new ApiError(errors),
                Model = model
            };
        }

        public static ApiResponse<T> Exception(string exception)
        {
            return new ApiResponse<T>()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Error = new ApiError(exception)
            };
        }

        public static ApiResponse<T> Failed(string failedMessage)
        {
            return new ApiResponse<T>()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Error = new ApiError().AddErrorMessage(failedMessage)
            };
        }
    }
}

public class ApiError
{
    public List<string> ErrorMessages { get; set; }
    public string ExceptionMessage { get; set; }
    public ApiError()
    {
        ErrorMessages = new List<string>();
    }

    public ApiError(IEnumerable<ValidationFailure> errors)
    {
        if (errors.Count() > 0)
            ErrorMessages = errors.Select(x => x.ErrorMessage).ToList();
    }

    public ApiError(string exception)
    {
        if (!string.IsNullOrEmpty(exception))
            ExceptionMessage = exception;
    }

    public ApiError AddErrorMessage(string error)
    {
        return new ApiError()
        {
            ErrorMessages = new List<string>() { error }
        };
    }
}
