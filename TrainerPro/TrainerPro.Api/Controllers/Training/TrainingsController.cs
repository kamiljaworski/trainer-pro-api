﻿namespace TrainerPro.Api.Controllers.Training
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TrainerPro.Core.DTOs;
    using TrainerPro.Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrainingsController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingsController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var username = User.Claims.Where(c => c.Type == "username").First().Value;
            var result = await _trainingService.GetTrainingsByUsernameAndDayAsync(username);

            return Ok(result);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsernameAsync(string username)
        {
            var result = await _trainingService.GetTrainingsByUsernameAndDayAsync(username);

            return Ok(result);
        }

        [HttpGet("{username}/{day}")]
        public async Task<IActionResult> GetByUsernameAndDayAsync(string username, string day)
        {
            var result = await _trainingService.GetTrainingsByUsernameAndDayAsync(username, day);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AddOrUpdateTrainingDTO model)
        {
            await _trainingService.AddOrUpdateTrainingAsync(model);

            return Ok();
        }
    }
}