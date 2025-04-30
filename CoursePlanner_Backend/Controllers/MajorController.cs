using CoursePlanner_Backend.Controllers.Services;
using CoursePlanner_Backend.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        public IMajorService majorService;

        public MajorController(IMajorService majorService)
        {
            this.majorService = majorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MajorResponseDTO>>> GetMajors()
        {
            return await this.majorService.GetMajors();
        }
    }
}
