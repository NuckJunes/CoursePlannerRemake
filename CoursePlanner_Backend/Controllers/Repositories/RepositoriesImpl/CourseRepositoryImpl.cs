using CoursePlanner_Backend.Data;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner_Backend.Controllers.Repositories.RepositoriesImpl
{
    public class CourseRepositoryImpl : ICourseRepository
    {
        private ApplicationDbContext appDbContext;

        public CourseRepositoryImpl(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            return await appDbContext.Courses.ToListAsync();
        }

        public async Task<ActionResult<Course>> AddCourse(Course course)
        {
            appDbContext.Courses.Add(course);
            await appDbContext.SaveChangesAsync();
            return course;
        }

        public async Task<ActionResult<Course>> GetById(int id)
        {
            return await appDbContext.Courses.FirstOrDefaultAsync(i => i.Id == id); 
        }
    }
}
