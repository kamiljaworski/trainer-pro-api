using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;
using TrainerPro.Core.Enums;
using TrainerPro.DAL;
using TrainerPro.Services.Interfaces;

namespace TrainerPro.Services.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly TrainerProContext _dbContext;

        public TrainerService(TrainerProContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TrainerDTO>> GetTrainers()
        {
            return await _dbContext.Users
                .Where(x => x.AccountTypeId == (int)AccountType.Trainer)
                .Select(x => new TrainerDTO
                {
                    Username = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                }).ToListAsync();
        }
    }
}
