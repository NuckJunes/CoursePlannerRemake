using CoursePlanner_Backend.Data;
using CoursePlanner_Backend.Model.DTOs;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursePlanner_Backend.Controllers.Repositories.RepositoriesImpl
{
    public class AccountRepositoryImpl : IAccountRepository
    {
        public ApplicationDbContext appDbContext;

        public AccountRepositoryImpl(ApplicationDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ActionResult<User>> CreateAccount(User newUser)
        {
            User found = await appDbContext.Users.FirstOrDefaultAsync(u => (u.Email == newUser.Email || u.Username == newUser.Username));
            if (found == null)
            {
                appDbContext.Users.Add(newUser);
                await appDbContext.SaveChangesAsync();
                return newUser;
            } else
            {
                if(found.Username.Equals(newUser.Username))
                {
                    found.Username = "Exists";
                }else if(found.Email.Equals(newUser.Email))
                {
                    found.Email = "Exists";
                }
                found.Password = "";
                found.schedules = new List<Schedule>();
            }
            return found;
        }

        public async Task<ActionResult<User>> GetUser(int userId)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(i => i.Id == userId);
        }

        public async Task<ActionResult<User>> Login(LoginRequestDTO loginRequestDTO)
        {
            return await appDbContext.Users.Include(user => user.schedules).ThenInclude(schedule => schedule.classes).ThenInclude(c => c.course).FirstOrDefaultAsync(i => (loginRequestDTO.Username == i.Username && loginRequestDTO.Password == i.Password));
        }
    }
}
