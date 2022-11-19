using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebApi.Domain.Context;
using SimpleWebApi.Domain.Entities;
using SimpleWebApi.MappingProfiles;
using SimpleWebApi.RequirementHandler;
using SimpleWebApi.Services.Interfaces;
using SimpleWebApi.Services.Services;
using SimpleWebApi.Shared.Models.Request;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<ApplicationContext>(x => x.UseSqlServer(connection));
//services.Add{LIFETIME}<{SERVICE}>
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IGradeService, GradeService>();
builder.Services.AddTransient<IWeatherService, WeatherService>();

//Fluent Validator Validation mappings

//builder.Services.AddScoped<IValidator<StudentRequest>, StudentRequestValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<StudentRequestValidator>();

builder.Services.AddAutoMapper(typeof(MappingProfiles));
 
builder.Services.AddHttpClient();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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