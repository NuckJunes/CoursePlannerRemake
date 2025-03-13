using CoursePlanner_Backend.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services
{
    public interface IMajorService
    {
        Task<ActionResult<IEnumerable<MajorResponseDTO>>> GetMajors();
    }
}
