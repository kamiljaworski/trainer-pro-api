using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainerPro.Api.Helpers.Models;
using TrainerPro.Core.Identities;
using TrainerPro.Services.Interfaces;

namespace TrainerPro.Api.Controllers.Account
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService trainerService;
        private readonly JwtSettings _jwtSettings;

        public TrainerController(ITrainerService trainerService, JwtSettings jwtSettings)
        {
            _accountService = accountService;
            _jwtSettings = jwtSettings;
        }

        [HttpGet]
        public async Task<ApplicationUser> GetTrainers()
        {
            var trainers = await _accountService.GetTrainers();
            return trainers;
        }

    }
}
