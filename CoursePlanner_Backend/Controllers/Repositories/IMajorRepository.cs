using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Repositories
{
    public interface IMajorRepository
    {
        Task<ActionResult<IEnumerable<Major>>> GetMajors();
        Task<ActionResult<Section>> GetSection(int id);
    }
}
