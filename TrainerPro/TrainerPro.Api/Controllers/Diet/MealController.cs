using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;
using TrainerPro.Services.Interfaces;

namespace TrainerPro.Api.Controllers.Diet
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddMealDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);
            try
            {
                await _mealService.AddMealAsync(model);
            }
            catch (Exception e)
            {
                return Ok(new { message = e.Message });
            }
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMealByIdAsync(int id)
        {
            await _mealService.DeleteMealByIdAsync(id);

            return new ObjectResult("Meal has been deleted.");
        }
    }
}
