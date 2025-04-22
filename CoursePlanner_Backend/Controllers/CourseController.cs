using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoursePlanner_Backend.Controllers.Services;
using CoursePlanner_Backend.Model.Entities;
using CoursePlanner_Backend.Model.DTOs;

namespace CoursePlanner_Backend.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet("/Courses")]
        public async Task<ActionResult<IEnumerable<CourseResponseDTO>>> GetCourses()
        {
            return await courseService.GetCourses();
        }

        [HttpPost("/Course")]
        public async Task<ActionResult<CourseResponseDTO>> AddCourse(CourseRequestDTO courseRequestDTO)
        {
            return await courseService.AddCourse(courseRequestDTO);
        }

        [HttpPatch("/Course/{id}")]
        public async Task<ActionResult<CourseResponseDTO>> UpdateCourse(CourseRequestDTO courseRequestDTO, int id)
        {
            return await courseService.UpdateCourse(courseRequestDTO, id);
        }

        [HttpDelete("/Course/{id}")]
        public async Task<ActionResult<CourseResponseDTO>> DeleteCourse(int id)
        {
            return await courseService.DeleteCourse(id);
        }

        [HttpGet("/Course/Subjects")]
        public async Task<ActionResult<IEnumerable<String>>> GetSubjects()
        {
            return await courseService.GetSubjects();
        }
    }
}
