using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Repositories
{
    public interface ICourseRepository
    {
        Task<ActionResult<IEnumerable<Course>>> GetAllCourses();
    }
}
