namespace TrainerPro.Api.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TrainerPro.Core.Enums;
    using TrainerPro.Core.Identities;
    using TrainerPro.Core.ViewModels;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            await _userManager.CreateAsync(new ApplicationUser { UserName = model.Username, AccountTypeId = (int)AccountType.Client }, model.Password);

            return Ok();
        }
    }
}
