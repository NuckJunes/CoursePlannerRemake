using CoursePlanner_Backend.Controllers.Repositories;
using CoursePlanner_Backend.Controllers.Repositories.RepositoriesImpl;
using CoursePlanner_Backend.Controllers.Services;
using CoursePlanner_Backend.Controllers.Services.ServicesImpl;
using CoursePlanner_Backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<ICourseService, CourseServiceImpl>();
builder.Services.AddTransient<ICourseRepository, CourseRepositoryImpl>();


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
