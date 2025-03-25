using CoursePlanner_Backend.Controllers.Repositories;
using CoursePlanner_Backend.Model.DTOs;
using CoursePlanner_Backend.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoursePlanner_Backend.Controllers.Services.ServicesImpl
{
    public class AccountServiceImpl : IAccountService
    {
        public IAccountRepository accountRepository;

        public AccountServiceImpl (IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public async Task<ActionResult<AccountReturnDTO>> AccountCreate(AccountCreateDTO accountCreateDTO)
        {
            User newUser = new User();
            newUser.Username = accountCreateDTO.Username;
            newUser.Password = accountCreateDTO.Password;
            newUser.Email = accountCreateDTO.Email;
            newUser.schedules = new List<Schedule>();
            newUser.Admin = accountCreateDTO.Admin;

            ActionResult<User> result = await accountRepository.CreateAccount(newUser);
            AccountReturnDTO user = new AccountReturnDTO();
            user.ConvertToDTO(newUser);
            return user;
        }

        public async Task<ActionResult<AccountReturnDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            ActionResult<User> result = await accountRepository.Login(loginRequestDTO);
            //if this user doesnt exist this action result will be error code, just return error code
            AccountReturnDTO user = new AccountReturnDTO();
            user.ConvertToDTO(result.Value);
            return new ActionResult<AccountReturnDTO>(user);
        }
    }
}
