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
            var result = await _mealService.GetUserMealsByUsernameAndDayAsync(username);

            return Ok(result);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsernameAsync(string username)
        {
            var result = await _mealService.GetUserMealsByUsernameAndDayAsync(username);

            return Ok(result);
        }


        [HttpGet("{username}/{day}")]
        public async Task<IActionResult> GetByUsernameAndDayAsync(string username, string day)
        {
            var result = await _mealService.GetUserMealsByUsernameAndDayAsync(username, day);

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
