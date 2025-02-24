using CoursePlanner_Backend.Data;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner_Backend.Controllers.Repositories.RepositoriesImpl
{
    public class ClassRepositoryImpl : IClassRepository
    {
        public ApplicationDbContext appDbContext;

        public ClassRepositoryImpl(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ActionResult<Class>> AddClass(Class newClass)
        {
            appDbContext.Classes.Add(newClass);
            await appDbContext.SaveChangesAsync();
            return newClass;
        }

        public async Task<ActionResult<Class>> DeleteClass(Class c)
        {
            Class classToDelete = appDbContext.Classes.Include(s => s.schedule)
                .Include(s => s.course)
                .FirstOrDefault(i => i.Id == c.Id);
            appDbContext.Classes.Remove(classToDelete);
            await appDbContext.SaveChangesAsync();
            return c;

        }
    }
}
