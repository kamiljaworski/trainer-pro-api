namespace TrainerPro.Api.Controllers.Diet
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainerPro.Core.DTOs;
    using TrainerPro.Services.Interfaces;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMealsController : ControllerBase
    {
        private readonly IMealService _mealService;

        public UserMealsController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var username = User.Claims.Where(c => c.Type == "username").First().Value;
            var result = await _mealService.GetUserMealsByUsernameAsync(username);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddOrUpdateUserMealDTO model)
        {
            await _mealService.AddOrUpdateUserMealAsync(model);

            return Ok();
        }
    }
}
