using CoursePlanner_Backend.Controllers.Repositories;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services.ServicesImpl
{
    public class CourseServiceImpl : ICourseService
    {
        private ICourseRepository courseRepository;

        public CourseServiceImpl(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await courseRepository.GetAllCourses();
        }
    }
}
