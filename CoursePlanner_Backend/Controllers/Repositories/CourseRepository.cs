using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Repositories
{
    public interface CourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
    }
}
