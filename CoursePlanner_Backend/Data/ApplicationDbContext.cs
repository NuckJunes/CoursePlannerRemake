using CoursePlanner_Backend.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public IConfiguration _config { get; set; }

        public ApplicationDbContext(IConfiguration config)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Campus> Campuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.schedules)
                .WithOne(e => e.user);

            modelBuilder.Entity<Class>()
                .HasOne(e => e.schedule)
                .WithMany(e => e.classes);

            modelBuilder.Entity<Class>()
                .HasOne(e => e.course)
                .WithMany(e => e.Classes);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Features)
                .WithMany(e => e.Courses);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Campuses)
                .WithMany(e => e.Courses);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Prerequisites)
                .WithMany(e => e.Requirements);

            modelBuilder.Entity<Course>().HasData(
                new Course {Id = 1,  Name = "Computer Science Entry", Description = "A entry level course", Credit_Hours = 1.0, Subject = "CSE", Course_Number = 102, Classes = new List<Class>(), Campuses = new List<Campus>(), Features = new List<Feature>(), Prerequisites = new List<Course>() } );

            modelBuilder.Entity<User>().HasData(
                new User {Id = 1, Username = "Username", Password = "Password", Email = "Email@Email.com", schedules = new List<Schedule>()});

            modelBuilder.Entity<Campus>().HasData(
                new Campus { Id = 1, Name = "Hamilton", Courses = new List<Course>() },
                new Campus { Id = 2, Name = "Luxembourg", Courses = new List<Course>()},
                new Campus { Id = 3, Name = "Middletown", Courses = new List<Course>()},
                new Campus { Id = 4, Name = "Oxford", Courses = new List<Course>()},
                new Campus { Id = 5, Name = "West Chester", Courses = new List<Course>()});

            modelBuilder.Entity<Feature>().HasData(
                new Feature { Id = 1, Name = "Advanced Writing", Short_Name = "PA", Courses = new List<Course>() });

            
        }
    }
}
