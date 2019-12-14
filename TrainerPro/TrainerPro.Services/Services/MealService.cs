namespace TrainerPro.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainerPro.Core.DTOs;
    using TrainerPro.Core.Entities;
    using TrainerPro.DAL;
    using TrainerPro.Services.Interfaces;

    public class MealService : IMealService
    {
        private readonly TrainerProContext _dbContext;

        public MealService(TrainerProContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MealDTO>> GetMealsAsync()
        {
            return await _dbContext.Meals
                .Include(x => x.MealProducts)
                .ThenInclude(m => m.Product)
                .Select(x => new MealDTO
                {
                    Id = x.MealId,
                    Title = x.Title,
                    Products = x.MealProducts
                        .Select(m => new MealProductDTO
                        {
                            ProductId = m.ProductId,
                            Weight = m.Quantity * 100,
                            Kcal = m.Quantity * m.Product.KcalPer100g
                        })
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task AddOrUpdateMealAsync(AddOrUpdateMealDTO model)
        {
            if (model.Id > 0)
            {
                var meal = await _dbContext.Meals.SingleAsync(x => x.MealId == model.Id);
                var mealProducts = await _dbContext.MealProducts.Where(x => x.MealId == model.Id).ToListAsync();
                _dbContext.MealProducts.RemoveRange(mealProducts);
                await _dbContext.SaveChangesAsync();

                meal.Title = model.Title;
                var newMealProducts = model.Products.Select(x => new MealProduct
                {
                    MealId = meal.MealId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity
                })
                .ToList();

                await _dbContext.MealProducts.AddRangeAsync(newMealProducts);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                var meal = new Meal
                {
                    Title = model.Title,
                    MealProducts = model.Products.Select(x => new MealProduct
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity
                    }).ToList()
                };

                await _dbContext.Meals.AddAsync(meal);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
