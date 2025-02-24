using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Repositories
{
    public interface IScheduleRepository
    {
        Task<ActionResult<Schedule>> CreateSchedule(Schedule newSchedule);
        Task<ActionResult<Schedule>> DeleteSchedule(int scheduleId);
        Task<ActionResult<Schedule>> GetSchedule(int scheduleId);
        Task<ActionResult<Schedule>> UpdateSchedule(Schedule schedule);
    }
}
