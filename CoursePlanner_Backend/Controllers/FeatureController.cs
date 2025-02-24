using CoursePlanner_Backend.Controllers.Services;
using CoursePlanner_Backend.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        public IFeatureService featureService;

        public FeatureController(IFeatureService featureService)
        {
            this.featureService = featureService;
        }

        [HttpGet("/Features")]
        public async Task<ActionResult<IEnumerable<FeatureDTO>>> GetAllFeatures()
        {
            return await featureService.GetAllFeatures();
        }
    }
}
