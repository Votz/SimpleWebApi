using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleWebApi.Filters
{
    public class CustomAuthorize : Attribute, IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;
        public CustomAuthorize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly string _role;
        public CustomAuthorize()
        {

        }
        public CustomAuthorize(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            var user = context.HttpContext.User;

            // -------
            var tokenHandler = new JwtSecurityTokenHandler();
            //var jwtConfig = _configuration.GetSection("JwtConfig");
            var key = Encoding.UTF8.GetBytes("A2CNwuvBVe!1232dfwqf");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    //ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                
                //var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
                return;
            }
            catch
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                return;
            }


            // ------------

            //var expires = user.Claims.Where(x => x.Issuer == ClaimTypes.Expiration).FirstOrDefault();
            //var period = new DateTime(long.Parse(expires.Value));
            
            //if(period <= DateTime.Now)
            //{
            //    context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
            //    return;
            //}
            //return;
        }
    }
}
