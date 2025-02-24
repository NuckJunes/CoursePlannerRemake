using CoursePlanner_Backend.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services
{
    public interface IFeatureService
    {
        Task<ActionResult<IEnumerable<FeatureDTO>>> GetAllFeatures();
    }
}
