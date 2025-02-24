using CoursePlanner_Backend.Controllers.Repositories;
using CoursePlanner_Backend.Data;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner_Backend.Controllers.Repositories.RepositoriesImpl
{
    public class CampusRepositoryImpl : ICampusRepository
    {
        private ApplicationDbContext appDbContext;

        public CampusRepositoryImpl(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ActionResult<IEnumerable<Campus>>> GetAllCampuses()
        {
            return await this.appDbContext.Campuses.ToListAsync();
        }

        public async Task<ActionResult<Campus>> GetById(int id)
        {
            return await this.appDbContext.Campuses.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
