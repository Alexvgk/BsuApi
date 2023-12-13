using BsuApi.Repositories.Implementations;
using DbConect;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Model;
using Repositories.Implimentations;
using Repositories.Interfaces;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
WebHost.CreateDefaultBuilder(args).UseUrls("http://127.0.0.1:5000");
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var serverVersion = ServerVersion.Parse("8.0.28");
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options =>
       options.UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion));
builder.Services.AddScoped<BaseRepository<UID>, UIDRepository>();
builder.Services.AddScoped<BaseRepository<User>, UserRepository>();
builder.Services.AddScoped<BaseRepository<CourseGroup>, CourseGroupRepository>();
builder.Services.AddScoped<BaseRepository<Role>, RoleRepository>();
builder.Services.AddScoped<BaseRepository<Schedule>, ScheduleRepository>();
builder.Services.AddScoped<BaseRepository<DayTime>, DayTimeRepository>();
builder.Services.AddScoped<BaseRepository<LessonForm>, LessonFormRepository>();

// свагер
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});

var app = builder.Build();



// Используйте Swagger UI и Swagger JSON в режиме дебага
if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
