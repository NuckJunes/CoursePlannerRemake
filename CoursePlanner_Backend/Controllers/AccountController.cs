using CoursePlanner_Backend.Controllers.Services;
using CoursePlanner_Backend.Model.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IAccountService accountService;
        public AccountController(IAccountService accoutService) 
        { 
            this.accountService = accoutService;
        }

        [HttpPost("/login")]
        public async Task<ActionResult<AccountReturnDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            return await this.accountService.Login(loginRequestDTO);
        }

        [HttpPost("/account")]
        public async Task<ActionResult<AccountReturnDTO>> CreateAccount(AccountCreateDTO accountCreateDTO)
        {
            return await this.accountService.AccountCreate(accountCreateDTO);
        }
    }
}
