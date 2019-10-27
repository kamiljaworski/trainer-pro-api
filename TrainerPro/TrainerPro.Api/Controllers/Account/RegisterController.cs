namespace TrainerPro.Api.Controllers.Account
{
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using TrainerPro.Core.DTOs;
    using TrainerPro.Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IViewRenderService _viewRenderService;
        private readonly IEmailSender _emailSender;

        public RegisterController(IAccountService accountService, IViewRenderService viewRenderService, IEmailSender emailSender)
        {
            _accountService = accountService;
            _viewRenderService = viewRenderService;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RegisterDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            try
            {
                await _accountService.RegisterAsync(model);

                try
                {
                    var emailMessage = await _viewRenderService.RenderAsync("RegisterConfirmationEmail", model);
                    await _emailSender.SendEmailAsync(model.Email, "Potwierdzenie rejestracji w TrainerPro", emailMessage);
                }
                catch (Exception e)
                {
                    return Ok(new { message = e.Message });
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }            
        }
    }
}