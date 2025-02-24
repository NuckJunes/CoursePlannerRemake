using CoursePlanner_Backend.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services
{
    public interface IScheduleService
    {
        Task<ActionResult<ScheduleResponseDTO>> CreateSchedule(ScheduleRequestDTO scheduleRequestDTO, int userId);
        Task<ActionResult<ScheduleResponseDTO>> DeleteSchedule(int scheduleId);
        Task<ActionResult<ScheduleResponseDTO>> GetSchedule(int scheduleId);
        Task<ActionResult<ScheduleResponseDTO>> UpdateSchedule(ScheduleRequestDTO scheduleRequestDTO, int scheduleId);
    }
}
