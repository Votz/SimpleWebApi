using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SimpleWebApi.Domain.Context;
using SimpleWebApi.Domain.Entities;
using SimpleWebApi.MappingProfiles;
using SimpleWebApi.RequirementHandler;
using SimpleWebApi.Services.Interfaces;
using SimpleWebApi.Services.Services;
using SimpleWebApi.Shared.Models.Request;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var connection = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<ApplicationContext>(x => x.UseSqlServer(connection));
//services.Add{LIFETIME}<{SERVICE}>
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IGradeService, GradeService>();
builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddTransient<SimpleWebApi.Services.Interfaces.IAuthorizationService, AuthorizationService>();

//Fluent Validator Validation mappings

//builder.Services.AddScoped<IValidator<StudentRequest>, StudentRequestValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<StudentRequestValidator>();

builder.Services.AddAutoMapper(typeof(MappingProfiles));
 
builder.Services.AddHttpClient();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationContext>()
.AddDefaultTokenProviders();

var jwtConfig = builder.Configuration.GetSection("jwtConfig");
var secretKey = jwtConfig["secret"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidIssuer = jwtConfig["validIssuer"],
        ValidAudience = jwtConfig["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});
builder.Services.AddAuthorization();

#region AddAuthentication / AddPolicy / addCookie Example
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
//        options => builder.Configuration.Bind("JwtSettings", options));
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddUserStore<ApplicationContext>();

//builder.Services.AddAuthorization(option =>
//{
//    option.AddPolicy("RequireAdministratorRole",
//        policy => policy.RequireRole("Administrator", "User", "BackUpAdministrator"));
//});

//builder.Services.AddAuthorization(option =>
//{
//    option.AddPolicy("EmployeeOnly",
//        policy => policy.RequireClaim("EmployeeNumber", "12", "23", "3", "4"));
//});

//builder.Services.AddAuthorization(option =>
//{
//    option.AddPolicy("HumanResources",
//        policy => policy.RequireClaim("HumanResourceNumber", "120", "2312", "311", "422"));
//});

//builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();


//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("AtLeast21", policy =>
//        policy.Requirements.Add(new MinimumAgeRequirement(21)));
//});



//.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
//    options => builder.Configuration.Bind("CookieSettings", options));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});