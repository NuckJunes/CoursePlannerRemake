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
            appDbContext.Users.Add(newUser);
            await appDbContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<ActionResult<User>> Login(LoginRequestDTO loginRequestDTO)
        {
            return await appDbContext.Users.Include(user => user.schedules).FirstOrDefaultAsync(i => (loginRequestDTO.Username == i.Username && loginRequestDTO.Password == i.Password));
        }
    }
}
