using Microsoft.OpenApi.Models;
using StudentManagement.Helpers;
using StudentManagement.Controllers;
using StudentManagement.Models;
using StudentManagement.Operations;
using StudentManagement.Repository;
using StudentManagement.Operations.Interface;
using StudentManagement.Repository.Interface;
using StudentManagement.Repository.Helpers.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using StudentManagement.Authentication;
using System.Configuration;
using Microsoft.Extensions.Logging;

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
    services.AddScoped<IUserops,Userops>();
    services.AddSingleton<IUserRepo, userRepo>();

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentManagement", Version = "v1" });
    });

}


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var key = "LectureTest1234$$$";

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


builder.Services.AddSingleton<JWTAuth>(new JWTAuth(key));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();