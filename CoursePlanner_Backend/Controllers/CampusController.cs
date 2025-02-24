using CoursePlanner_Backend.Controllers.Services;
using CoursePlanner_Backend.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CampusController : ControllerBase
    {
        public ICampusService campusService;
        public CampusController(ICampusService campusService) 
        {
            this.campusService = campusService;
        }

        [HttpGet("/Campuses")]
        public async Task<ActionResult<IEnumerable<CampusDTO>>> GetAllCampuses()
        {
            return await campusService.GetAllCampuses();
        }
    }
}
