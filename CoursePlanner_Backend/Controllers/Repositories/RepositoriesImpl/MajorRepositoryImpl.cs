using CoursePlanner_Backend.Data;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner_Backend.Controllers.Repositories.RepositoriesImpl
{
    public class MajorRepositoryImpl : IMajorRepository
    {
        public ApplicationDbContext appDbContext;

        public MajorRepositoryImpl(ApplicationDbContext dbContext)
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

        public async Task<ActionResult<Section>> GetSection(int id)
        {
            return await this.appDbContext.Sections.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
