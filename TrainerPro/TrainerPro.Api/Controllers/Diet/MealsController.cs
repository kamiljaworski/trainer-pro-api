namespace TrainerPro.Api.Controllers.Diet
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TrainerPro.Core.DTOs;
    using TrainerPro.Services.Interfaces;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealsController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _mealService.GetMealsAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddOrUpdateMealDTO model)
        {
            await _mealService.AddOrUpdateMealAsync(model);

            return Ok();
        }
    }
}
