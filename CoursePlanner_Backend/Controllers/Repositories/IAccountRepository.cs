using CoursePlanner_Backend.Model.DTOs;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Repositories
{
    public interface IAccountRepository
    {
        Task<ActionResult<User>> CreateAccount(User newUser);
        Task<ActionResult<User>> Login(LoginRequestDTO loginRequestDTO);
    }
}
