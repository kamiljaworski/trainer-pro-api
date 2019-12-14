using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;
using TrainerPro.Services.Interfaces;

namespace TrainerPro.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _ExerciseService;

        public ExerciseController(IExerciseService ExerciseService)
        {
            _ExerciseService = ExerciseService;
        }

        [HttpGet]
        public async Task<ActionResult<GetExerciseDTO>> GetAsync()
        {
            var Exercises = await _ExerciseService.GetExercisesAsync();

            return Ok(Exercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var Exercise = await _ExerciseService.GetExerciseByIdAsync(id);

            if (Exercise == null)
                return new ObjectResult("This Exercise does not exist") { StatusCode = 400 };

            return Ok(Exercise);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddExerciseDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);
            try
            {
                await _ExerciseService.AddExerciseAsync(model);
            }
            catch (Exception e)
            {
                return Ok(new { message = e.Message });
            }
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<AddExerciseDTO>> PutExerciseAsync([FromBody] AddExerciseDTO model)
        {
            var Exercise = await _ExerciseService.UpdateExerciseAsync(model);

            return Ok(Exercise);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExerciseByIdAsync(int id)
        {
            await _ExerciseService.DeleteExerciseByIdAsync(id);

            return new ObjectResult("Exercise has been deleted.");
        }

    }
}
