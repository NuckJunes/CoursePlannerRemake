using CoursePlanner_Backend.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services
{
    public interface ICampusService
    {
        Task<ActionResult<IEnumerable<CampusDTO>>> GetAllCampuses();
    }
}
