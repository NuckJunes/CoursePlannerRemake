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

        [HttpGet("/Schedule/{scheduleId}")]
        public async Task<ActionResult<ScheduleResponseDTO>> GetSchedule(int scheduleId)
        {
            return await scheduleService.GetSchedule(scheduleId);
        }

        [HttpPost("/Schedule/{userId}")]
        public async Task<ActionResult<ScheduleResponseDTO>> CreateSchedule([FromBody]ScheduleRequestDTO scheduleRequestDTO, int userId)
        {
            return await scheduleService.CreateSchedule(scheduleRequestDTO, userId);
        }

        [HttpPatch("/Schedule/{scheduleId}")]
        public async Task<ActionResult<ScheduleResponseDTO>> UpdateSchedule([FromBody]ScheduleRequestDTO scheduleRequestDTO, int scheduleId)
        {
            return await scheduleService.UpdateSchedule(scheduleRequestDTO, scheduleId);
        }

        [HttpDelete("/Schedule/{scheduleId}")]
        public async Task<ActionResult<ScheduleResponseDTO>> DeleteSchedule(int scheduleId)
        {
            return await scheduleService.DeleteSchedule(scheduleId);
        }
    }
}
