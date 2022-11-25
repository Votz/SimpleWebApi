using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimpleWebApi.Domain.Entities;
using SimpleWebApi.Services.Interfaces;
using SimpleWebApi.Shared.Models.Request;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebApi.Services.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthorizationService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterRequest registerRequest)
        {
            var user = _mapper.Map<ApplicationUser>(registerRequest);

            var result = await _userManager.CreateAsync(user, registerRequest.Password);

            return result;
        }

        public async Task<bool> ValidateUserAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Username);
            var result = user != null && await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            return result;
        }

        public async Task<string> CreateTokenAsync(string username)
        {
            //ლოგინის შედეგად შეგროვებული მომხმარებლის ინფორმაცია +
            //Claims რომელიც აღწერს მომხმარებლის ინფორმაციას
            //ტოკენის გენერაცია

            var signInCredentials = GetSigningCredentials();
            var claims = await GetClaims(username);
            var tokenOptions = GenerateTokenOptions(signInCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _configuration.GetSection("JwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
                                                      List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}
