namespace TrainerPro.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainerPro.Core.DTOs;
    using TrainerPro.Core.Entities;
    using TrainerPro.DAL;
    using TrainerPro.Services.Interfaces;

    public class TrainingService : ITrainingService
    {
        private readonly TrainerProContext _dbContext;

        public TrainingService(TrainerProContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TrainingDTO>> GetTrainingsByUsernameAsync(string username)
        {
            var user = await _dbContext.Users.SingleAsync(x => x.NormalizedUserName == username.ToUpper());

            return await _dbContext.Trainings
                .Where(x => x.UserId == user.Id)
                .Select(x => new TrainingDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Day = x.Day,
                    Series = x.Series,
                    Repeats = x.Repeats
                })
                .ToListAsync();
        }

        public async Task AddTrainingAsync(string username, AddTrainingDTO model)
        {
            var user = await _dbContext.Users.SingleAsync(x => x.NormalizedUserName == username.ToUpper());

            var training = new Training
            {
                Name = model.Name,
                Repeats = model.Repeats,
                Series = model.Series,
                Day = model.Day,
                UserId = user.Id
            };

            await _dbContext.Trainings.AddAsync(training);
            await _dbContext.SaveChangesAsync();
        }
    }
}
