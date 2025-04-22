using CoursePlanner_Backend.Model.DTOs;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services
{
    public interface ICourseService
    {
        Task<ActionResult<CourseResponseDTO>> AddCourse(CourseRequestDTO courseRequestDto);
        Task<ActionResult<CourseResponseDTO>> DeleteCourse(int id);
        Task<ActionResult<IEnumerable<CourseResponseDTO>>> GetCourses();
        Task<ActionResult<IEnumerable<string>>> GetSubjects();
        Task<ActionResult<CourseResponseDTO>> UpdateCourse(CourseRequestDTO courseRequestDTO, int id);
    }
}
