using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoursePlanner_Backend.Controllers.Services;
using CoursePlanner_Backend.Model.Entities;

namespace CoursePlanner_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private CourseService courseService;

        public CourseController(CourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await courseService.GetCourses();
        }
    }
}
