using CoursePlanner_Backend.Model.DTOs;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Repositories
{
    public interface ICourseRepository
    {
        Task<ActionResult<Course>> AddCourse(Course course);
        Task<ActionResult<Course>> DeleteCourse(int id);
        Task<ActionResult<IEnumerable<Course>>> GetAllCourses();
        Task<ActionResult<Course>> GetById(int id);
        Task<ActionResult<IEnumerable<string>>> GetSubjects();
        Task<ActionResult<Course>> UpdateCourse(Course course);
    }
}
