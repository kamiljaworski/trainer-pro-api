using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;
using TrainerPro.Core.Identities;
using TrainerPro.Core.Models;
using TrainerPro.DAL;
using TrainerPro.Services.Interfaces;

namespace TrainerPro.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly TrainerProContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountService(TrainerProContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AccountDTO> GetAccountByUsernameAsync(string username)
        {
            var user = await _dbContext.Users.SingleAsync(x => x.NormalizedUserName == username.ToUpper());

            return new AccountDTO
            {
                Id = user.Id.ToString(),
                Username = user.UserName,
                Email = user.Email,
                AccountTypeId = user.AccountTypeId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Height = user.Height,
                Weight = user.Weight,
                Sex = user.Sex
            };
        }

        public async Task UpdateAccountAsync(string username, UpdateAccountDTO model)
        {
            var user = await _dbContext.Users.SingleAsync(x => x.NormalizedUserName == username.ToUpper());

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Weight = model.Weight;
            user.Height = model.Height;
            user.Sex = string.IsNullOrWhiteSpace(model.Sex) ? null : model.Sex.First().ToString().ToUpper();

            await _dbContext.SaveChangesAsync();
        }

        public async Task RegisterAsync(RegisterDTO model)
        {
            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                AccountTypeId = model.AccountTypeId
            }, model.Password);

            if (!result.Succeeded)
                throw new InvalidOperationException(string.Join(";", result.Errors.Select(x => x.Description)));
        }

        public async Task<TokenModel> LoginAsync(LoginDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (!result.Succeeded)
                throw new InvalidOperationException("User with given username and/or password doesn't exists");

            var user = await _userManager.FindByNameAsync(model.Username);

            return new TokenModel
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                AccountType = (await _dbContext.AccountTypes.SingleAsync(at => at.Id == user.AccountTypeId)).Name,
                AccountTypeId = user.AccountTypeId
            };
        }
    }
}
