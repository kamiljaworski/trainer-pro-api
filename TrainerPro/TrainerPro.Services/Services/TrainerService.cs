using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;
using TrainerPro.Core.Enums;
using TrainerPro.Core.Identities;
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

        public async Task<IEnumerable<TrainerDTO>> GetTrainersAsync()
        {
            var trainers = await _dbContext.Users
                .Where(x => x.AccountTypeId == (int)AccountType.Trainer)
                .Select(x => new TrainerDTO
                {
                    Id = x.Id.ToString(),
                    Username = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                }).ToListAsync();

            if (trainers == null)
                throw new InvalidOperationException("There are no users with AccountType 2");

            return trainers;
        }

        public async Task<TrainerDTO> GetTrainerByIdAsync(string id)
        {
            var trainer = await _dbContext.Users.SingleOrDefaultAsync(t => t.Id == Guid.Parse(id));

            if (trainer == null)
                throw new InvalidOperationException("This trainer doesn't exist.");

            return GetTrainerDTOFromUserEntity(trainer);
        }

        private TrainerDTO GetTrainerDTOFromUserEntity(ApplicationUser trainer)
        {
            return new TrainerDTO
            {
                Id = trainer.Id.ToString(),
                Username = trainer.UserName,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                Email = trainer.Email
            };
        }
    }
}
