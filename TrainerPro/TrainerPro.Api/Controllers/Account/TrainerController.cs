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
        public async Task<IEnumerable<TrainerDTO>> GetTrainers()
        {
            return await _trainerService.GetTrainers();
        }
    }
}
