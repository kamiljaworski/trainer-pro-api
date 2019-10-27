using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
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
                throw new InvalidOperationException("This user is already existing");
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
                Email = user.Email,
                AccountType = (await _dbContext.AccountTypes.SingleAsync(at => at.Id == user.AccountTypeId)).Name,
                AccountTypeId = user.AccountTypeId
            };
        }
    }
}
