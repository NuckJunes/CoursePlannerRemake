using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoursePlanner_Backend.Controllers.Services;
using CoursePlanner_Backend.Model.Entities;
using CoursePlanner_Backend.Model.DTOs;

namespace CoursePlanner_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await courseService.GetCourses();
        }

        [HttpPost("/add")]
        public async Task<ActionResult<Course>> AddCourse(CourseRequestDTO courseRequestDTO)
        {
            return await courseService.AddCourse(courseRequestDTO);
        }

        [HttpPatch("/update/{id}")]
        public async Task<ActionResult<Course>> UpdateCourse(CourseRequestDTO courseRequestDTO, int id)
        {
            return await courseService.UpdateCourse(courseRequestDTO, id);
        }
    }
}
