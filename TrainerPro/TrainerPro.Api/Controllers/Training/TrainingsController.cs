namespace TrainerPro.Api.Controllers.Training
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

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUsernameAsync(string username)
        {
            var result = await _trainingService.GetTrainingsByUsernameAsync(username);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var username = User.Claims.Where(c => c.Type == "username").First().Value;
            var result = await _trainingService.GetTrainingsByUsernameAsync(username);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddTrainingDTO model)
        {
            var username = User.Claims.Where(c => c.Type == "username").First().Value;
            await _trainingService.AddTrainingAsync(username, model);

            return Ok();
        }
    }
}