using CoursePlanner_Backend.Model.DTOs;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services
{
    public interface ICourseService
    {
        Task<ActionResult<Course>> AddCourse(CourseRequestDTO courseRequestDto);
        Task<ActionResult<IEnumerable<Course>>> GetCourses();
        Task<ActionResult<Course>> UpdateCourse(CourseRequestDTO courseRequestDTO, int id);
    }
}
