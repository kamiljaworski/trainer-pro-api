namespace TrainerPro.Api.Controllers.Account
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainerPro.Services.Interfaces;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsAssignedToTrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public ClientsAssignedToTrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var username = User.Claims.Where(c => c.Type == "username").First().Value;
            var result = await _trainerService.GetClientsAssignedToTrainer(username);

            return Ok(new { result });
        }
    }
}
