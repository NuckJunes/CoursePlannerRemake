using CoursePlanner_Backend.Data;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner_Backend.Controllers.Repositories.RepositoriesImpl
{
    public class ScheduleRepositoryImpl : IScheduleRepository
    {
        public ApplicationDbContext appDbContext;

        public ScheduleRepositoryImpl(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ActionResult<Schedule>> CreateSchedule(Schedule newSchedule)
        {
            appDbContext.Schedules.Add(newSchedule);
            await appDbContext.SaveChangesAsync();
            return new ActionResult<Schedule>(newSchedule);
        }

        public async Task<ActionResult<Schedule>> DeleteSchedule(int scheduleId)
        {
            Schedule scheduleToDelete = appDbContext.Schedules
                .Include(i => i.classes)
                .ThenInclude(c => c.course)
                .FirstOrDefault(i => i.Id == scheduleId);
            appDbContext.Remove(scheduleToDelete);
            await appDbContext.SaveChangesAsync();
            return new ActionResult<Schedule>(scheduleToDelete);
        }

        public async Task<ActionResult<Schedule>> GetSchedule(int scheduleId)
        {
            return await appDbContext.Schedules
                .Include(schedule => schedule.classes)
                .ThenInclude(c => c.course)
                .FirstOrDefaultAsync(i => i.Id == scheduleId);
        }

        public async Task<ActionResult<Schedule>> UpdateSchedule(Schedule schedule)
        {
            //appDbContext.Schedules.Attach(schedule);
            //appDbContext.Entry(schedule).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return new ActionResult<Schedule>(schedule);
        }
    }
}
