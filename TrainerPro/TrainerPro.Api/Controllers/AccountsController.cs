namespace TrainerPro.Api.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
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
        private IEmailSender _emailSender;

        public AccountsController(UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            await _userManager.CreateAsync(new ApplicationUser { 
                Email = model.Email, 
                UserName = model.Username, 
                AccountTypeId = model.AccountTypeId, 
                PasswordHash = model.Password 
            });

            var sampleSubject = "TEST";
            var htmlMessage = "<div><h2>GOWNO TEST REJESTRACJI</h2></div>";

            await _emailSender.SendEmailAsync(model.Email, sampleSubject, htmlMessage);

            return Ok();
        }
    }
}
