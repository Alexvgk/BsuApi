using DbConect;
using Microsoft.EntityFrameworkCore;
using Model;
using Repositories.Implimentations;
using Repositories.Interfaces;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
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
builder.Services.AddTransient<IBaseRepository<UID>, BaseRepository<UID>>();
builder.Services.AddTransient<IBaseRepository<RegCode>, BaseRepository<RegCode>>();
builder.Services.AddTransient<IBaseRepository<User>, BaseRepository<User>>();
builder.Services.AddTransient<IBaseRepository<CourseGroup>, BaseRepository<CourseGroup>>();
builder.Services.AddTransient<IBaseRepository<UserRole>, BaseRepository<UserRole>>();
builder.Services.AddTransient<IBaseRepository<Schedule>, BaseRepository<Schedule>>();
builder.Services.AddTransient<IBaseRepository<DayTime>, BaseRepository<DayTime>>();
builder.Services.AddTransient<IBaseRepository<LessonForm>, BaseRepository<LessonForm>>();

var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

app.Run();
