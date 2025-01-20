using CoursePlanner_Backend.Controllers.Repositories;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services.ServicesImpl
{
    public class CourseServiceImpl : CourseService
    {
        private CourseRepository courseRepository;

        public CourseServiceImpl(CourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await courseRepository.GetAllCourses();
        }
    }
}
