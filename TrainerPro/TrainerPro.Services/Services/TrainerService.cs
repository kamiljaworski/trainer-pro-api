namespace TrainerPro.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainerPro.Core.DTOs;
    using TrainerPro.Core.Enums;
    using TrainerPro.Core.Identities;
    using TrainerPro.DAL;
    using TrainerPro.Services.Interfaces;

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

            return trainers;
        }

        public async Task<TrainerDTO> GetTrainerByIdAsync(string id)
        {
            var trainer = await _dbContext.Users.SingleOrDefaultAsync(t => t.Id == Guid.Parse(id));

            if (trainer == null)
                throw new InvalidOperationException("This trainer doesn't exist.");

            return GetTrainerDTOFromUserEntity(trainer);
        }

        public async Task<TrainerDTO> GetTrainerAssignedToClientAsync(string clientUsername)
        {
            var client = await _dbContext.Users.SingleAsync(x => x.NormalizedUserName == clientUsername.ToUpper());

            if (client.AccountTypeId != (int)AccountType.Client)
                throw new InvalidOperationException("Trainer cannot have assigned trainer");

            if (client.TrainerId == null)
                return null;

            var trainer = await _dbContext.Users.SingleAsync(x => x.Id == client.TrainerId);

            return new TrainerDTO
            {
                Id = trainer.Id.ToString(),
                Email = trainer.Email,
                FirstName = trainer.FirstName,
                LastName = trainer.FirstName,
                Username = trainer.UserName
            };
        }

        public async Task AssignClientToTrainerAsync(string clientUsername, string trainerId)
        {
            var client = await _dbContext.Users.SingleAsync(x => x.NormalizedUserName == clientUsername.ToUpper());
            var trainer = await _dbContext.Users.SingleAsync(x => x.Id == Guid.Parse(trainerId));

            if (client.AccountTypeId != (int)AccountType.Client || trainer.AccountTypeId != (int)AccountType.Trainer)
                throw new InvalidOperationException("Trainer cannot be assinged to trainer");

            client.TrainerId = trainer.Id;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClientDTO>> GetClientsAssignedToTrainer(string trainerUsername)
        {
            var trainer = await _dbContext.Users.SingleAsync(x => x.NormalizedUserName == trainerUsername.ToUpper());

            if (trainer.AccountTypeId != (int)AccountType.Trainer)
                throw new InvalidOperationException("Client cannot have assigned clients");

            return await _dbContext.Users
                .Where(x => x.TrainerId == trainer.Id && x.AccountTypeId == (int)AccountType.Client)
                .Select(x => new ClientDTO
                {
                    Id = x.Id.ToString(),
                    Username = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Height = x.Height,
                    Sex = x.Sex,
                    Weight = x.Weight
                })
                .ToListAsync();
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
