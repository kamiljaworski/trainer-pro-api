using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;
using TrainerPro.Core.Entities;
using TrainerPro.DAL;

namespace TrainerPro.Services.Services
{
    class TrainerService
    {
        private readonly TrainerProContext _dbContext;
        public TrainerService(TrainerProContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task GetTrainers()
        {
            var trainers = _dbContext.Users.Where(x => x.AccountTypeId == (int)AccountType.Trainer)
            .Select(x => new TrainerDTO
            {
                Name = x.Name,
            }).ToListAsync();

        }


    }
}
