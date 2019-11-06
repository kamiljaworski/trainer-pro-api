using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainerPro.Api.Helpers.Models;
using TrainerPro.Core.DTOs;
using TrainerPro.Core.Identities;
using TrainerPro.Services.Interfaces;

namespace TrainerPro.Api.Controllers.Account
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainerDTO>>> GetTrainers()
        {
            var trainers = await _trainerService.GetTrainersAsync();

            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainerDTO>> GetTrainerByIdAsync(string id)
        {
            var trainer = await _trainerService.GetTrainerByIdAsync(id);

            if (trainer == null)
                return new ObjectResult("This user does not exist") { StatusCode = 400 };

            return Ok(trainer);
        }
    }
}
