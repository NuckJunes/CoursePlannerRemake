using CoursePlanner_Backend.Data;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner_Backend.Controllers.Repositories.RepositoriesImpl
{
    public class MajorRepository : IMajorRepository
    {
        public ApplicationDbContext appDbContext;

        public MajorRepository(ApplicationDbContext dbContext)
        {
            appDbContext = dbContext;
        }

        public async Task<ActionResult<IEnumerable<Major>>> GetMajors()
        {
            return await this.appDbContext.Majors
                .Include(i => i.Sections)
                .ThenInclude(i => i.Courses)
                .ToListAsync();
        }
    }
}
