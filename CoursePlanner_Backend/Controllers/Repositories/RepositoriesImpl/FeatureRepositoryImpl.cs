using CoursePlanner_Backend.Data;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner_Backend.Controllers.Repositories.RepositoriesImpl
{
    public class FeatureRepositoryImpl : IFeatureRepository
    {
        private ApplicationDbContext appDbContext;

        public FeatureRepositoryImpl(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ActionResult<IEnumerable<Feature>>> GetAllFeatures()
        {
            return await this.appDbContext.Features.ToListAsync();
        }

        public async Task<ActionResult<Feature>> GetById(int id)
        {
            return await this.appDbContext.Features.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
