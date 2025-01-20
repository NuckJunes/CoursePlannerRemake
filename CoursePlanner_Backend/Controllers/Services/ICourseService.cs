using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services
{
    public interface ICourseService
    {
        Task<ActionResult<IEnumerable<Course>>> GetCourses();
    }
}
