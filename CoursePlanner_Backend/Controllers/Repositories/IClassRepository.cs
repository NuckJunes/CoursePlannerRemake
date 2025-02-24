using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Repositories
{
    public interface IClassRepository
    {
        Task<ActionResult<Class>> AddClass(Class newClass);
        Task<ActionResult<Class>> DeleteClass(Class c);
    }
}
