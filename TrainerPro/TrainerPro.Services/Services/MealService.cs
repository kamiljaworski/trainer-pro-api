using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainerPro.DAL;
using TrainerPro.Services.Interfaces;

namespace TrainerPro.Services.Services
{
    public class MealService : IMealService
    {
        private readonly TrainerProContext _dbContext;

        public MealService(TrainerProContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<AddMealDTO> AddMealAsync(AddMealDTO model)
        //{

        //}

        //public async Task<IEnumerable<GetMealDTO>> GetMealsAsync()
        //{

        //}

        //public async Task<AddMealDTO> GetMealByIdAsync(int id)
        //{

        //}

        //public async Task<AddMealDTO> UpdateMealAsync(AddMealDTO model)
        //{

        //}

        public async Task DeleteMealByIdAsync(int id)
        {
            var Meal = await _dbContext.Meals.SingleOrDefaultAsync(c => c.MealId == id);

            if (Meal == null)
                throw new InvalidOperationException("This Meal doesn't exist.");

            _dbContext.Meals.Remove(Meal);
            await _dbContext.SaveChangesAsync();
        }

        //private AddMealDTO GetMealDTOFromMealEntity(Meal Meal)
        //{

        //}
    }
}
