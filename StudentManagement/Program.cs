using Microsoft.OpenApi.Models;
using StudentManagement.Helpers;
using StudentManagement.Controllers;
using StudentManagement.Models;
using StudentManagement.Operations;
using StudentManagement.Repository;
using StudentManagement.Operations.Interface;
using StudentManagement.Repository.Interface;
using StudentManagement.Repository.Helpers.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddCors();
    services.AddControllers();

    services.AddScoped<IStudentops, Studentops>();
    services.AddSingleton<IStudentRepo, StudentRepo>();
    services.AddScoped<IAPIResponseHelper, APIResponseHelper>();

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentManagement", Version = "v1" });
    });

}


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();