using CoursePlanner_Backend.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services
{
    public interface IAccountService
    {
        Task<ActionResult<AccountReturnDTO>> AccountCreate(AccountCreateDTO accountCreateDTO);
        Task<ActionResult<AccountReturnDTO>> Login(LoginRequestDTO loginRequestDTO);
    }
}
