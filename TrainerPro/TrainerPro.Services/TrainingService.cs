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

        public async Task<IEnumerable<TrainingDTO>> GetTrainingsByUsernameAndDayAsync(string username, string day = null)
        {
            var user = await _dbContext.Users.SingleAsync(x => x.NormalizedUserName == username.ToUpper());
            day = string.IsNullOrEmpty(day) ? day : day.ToUpper();

            return await _dbContext.Trainings
                .Where(x => x.UserId == user.Id &&
                           (!string.IsNullOrEmpty(day) ? x.Day.ToUpper() == day : true))
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

        public async Task AddOrUpdateTrainingAsync(AddOrUpdateTrainingDTO model)
        {
            var user = await _dbContext.Users.SingleAsync(x => x.NormalizedUserName == model.Username.ToUpper());

            if (model.TrainingId != null && model.TrainingId > 0)
            {
                var training = await _dbContext.Trainings.SingleAsync(x => x.Id == model.TrainingId);

                training.Name = model.Name;
                training.Repeats = model.Repeats;
                training.Series = model.Series;
                training.Day = model.Day;
            } 
            else
            {
                var training = new Training
                {
                    Name = model.Name,
                    Repeats = model.Repeats,
                    Series = model.Series,
                    Day = model.Day,
                    UserId = user.Id
                };

                await _dbContext.Trainings.AddAsync(training);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
