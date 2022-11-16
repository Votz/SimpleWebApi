using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebApi.Domain.Context;
using SimpleWebApi.MappingProfiles;
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

//IOC - Input Output Container
//builder.Services.AddScoped<IGradeService, GradeService>();
//builder.Services.AddSingleton<IGradeService, GradeService>();

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));

//var apiRoute = builder.Configuration["MovieApiRoute"];

builder.Services.AddHttpClient();



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

//API - Application Programming interface


//MVC - Model View Controller



