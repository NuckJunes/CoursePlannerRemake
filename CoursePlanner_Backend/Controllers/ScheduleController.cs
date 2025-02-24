using CoursePlanner_Backend.Controllers.Services;
using CoursePlanner_Backend.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers
{
    public class ScheduleController : ControllerBase
    {
        public IScheduleService scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        [HttpGet("/{scheduleId}")]
        public async Task<ActionResult<ScheduleResponseDTO>> GetSchedule(int scheduleId)
        {
            return await scheduleService.GetSchedule(scheduleId);
        }

        [HttpPost("/{userId}")]
        public async Task<ActionResult<ScheduleResponseDTO>> CreateSchedule(ScheduleRequestDTO scheduleRequestDTO, int userId)
        {
            return await scheduleService.CreateSchedule(scheduleRequestDTO, userId);
        }

        [HttpPatch("/{scheduleId}")]
        public async Task<ActionResult<ScheduleResponseDTO>> UpdateSchedule(ScheduleRequestDTO scheduleRequestDTO, int scheduleId)
        {
            return await scheduleService.UpdateSchedule(scheduleRequestDTO, scheduleId);
        }

        [HttpDelete("/{scheduleId}")]
        public async Task<ActionResult<ScheduleResponseDTO>> DeleteSchedule(int scheduleId)
        {
            return await scheduleService.DeleteSchedule(scheduleId);
        }
    }
}
