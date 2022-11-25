using Microsoft.AspNetCore.Identity;
using SimpleWebApi.Shared.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterRequest registerRequest);
        Task<bool> ValidateUserAsync(LoginRequest loginRequest);
        Task<string> CreateTokenAsync(string username);


    }
}
