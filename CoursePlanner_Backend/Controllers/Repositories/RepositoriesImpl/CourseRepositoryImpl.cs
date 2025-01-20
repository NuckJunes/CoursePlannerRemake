using CoursePlanner_Backend.Data;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner_Backend.Controllers.Repositories.RepositoriesImpl
{
    public class CourseRepositoryImpl : CourseRepository
    {
        private readonly ApplicationDbContext appDbContext;

        public CourseRepositoryImpl(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await appDbContext.Courses.ToListAsync();
        }
    }
}
