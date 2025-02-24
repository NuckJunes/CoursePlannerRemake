using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Repositories
{
    public interface ICampusRepository
    {
        Task<ActionResult<IEnumerable<Campus>>> GetAllCampuses();
        Task<ActionResult<Campus>> GetById(int id);
    }
}
