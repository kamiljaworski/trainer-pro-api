namespace TrainerPro.Api.Controllers.Account
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
    public class AssignedTrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public AssignedTrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var username = User.Claims.Where(c => c.Type == "username").First().Value;
            var result = await _trainerService.GetTrainerAssignedToClientAsync(username);

            return Ok(new { result });
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] AssignToTrainerDTO model)
        {
            var username = User.Claims.Where(c => c.Type == "username").First().Value;
            await _trainerService.AssignClientToTrainerAsync(username, model.TrainerId);

            return Ok();
        }
    }
}
