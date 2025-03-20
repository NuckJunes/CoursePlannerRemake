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
builder.Services.AddTransient<ICampusService, CampusServiceImpl>();
builder.Services.AddTransient<ICampusRepository, CampusRepositoryImpl>();
builder.Services.AddTransient<IFeatureService, FeatureServiceImpl>();
builder.Services.AddTransient<IFeatureRepository, FeatureRepositoryImpl>();
builder.Services.AddTransient<IAccountService, AccountServiceImpl>();
builder.Services.AddTransient<IAccountRepository, AccountRepositoryImpl>();
builder.Services.AddTransient<IScheduleService, ScheduleServiceImpl>();
builder.Services.AddTransient<IScheduleRepository, ScheduleRepositoryImpl>();
builder.Services.AddTransient<IClassRepository, ClassRepositoryImpl>();
builder.Services.AddTransient<IMajorService, MajorServiceImpl>();
builder.Services.AddTransient<IMajorRepository, MajorRepositoryImpl>();


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
