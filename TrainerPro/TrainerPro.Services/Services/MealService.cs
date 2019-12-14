namespace TrainerPro.Services.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TrainerPro.Core.DTOs;
    using TrainerPro.Core.Entities;
    using TrainerPro.Core.Enums;
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

        public async Task<IEnumerable<UserMealDTO>> GetUserMealsByUsernameAsync(string username)
        {
            var user = await _dbContext.Users.SingleAsync(x => x.NormalizedUserName == username.ToUpper());

            var meals = await _dbContext.UserMeals
                .Include(x => x.Meal)
                .Where(x => x.UserId == user.Id)
                .ToListAsync();

            return meals.GroupBy(x => x.Day)
                .Select(g => new UserMealDTO
                {
                    UserId = g.First().UserId.ToString(),
                    Day = g.Key,
                    BreakfastMealId = g.First(x => x.MealOfDay == MealOfDay.Breakfast.ToString()).MealId,
                    BreakfastMealName = g.First(x => x.MealOfDay == MealOfDay.Breakfast.ToString()).Meal.Title,
                    LunchMealId = g.First(x => x.MealOfDay == MealOfDay.Lunch.ToString()).MealId,
                    LunchMealName = g.First(x => x.MealOfDay == MealOfDay.Lunch.ToString()).Meal.Title,
                    DinnerMealId = g.First(x => x.MealOfDay == MealOfDay.Dinner.ToString()).MealId,
                    DinnerMealName = g.First(x => x.MealOfDay == MealOfDay.Dinner.ToString()).Meal.Title
                })
                .ToList();
        }

        public async Task AddOrUpdateUserMealAsync(AddOrUpdateUserMealDTO model)
        {
            var user = await _dbContext.Users.SingleAsync(x => x.NormalizedUserName == model.Username.ToUpper());
            var userMeals = await _dbContext.UserMeals.Where(x => x.UserId == user.Id && x.Day == model.Day).ToListAsync();

            if (userMeals.Any())
                _dbContext.RemoveRange(userMeals);

            var newMeals = new List<UserMeal>
            {
                new UserMeal
                {
                    UserId = user.Id,
                    Day = model.Day,
                    MealOfDay = MealOfDay.Breakfast.ToString(),
                    MealId = model.BreakfastMealId
                },
                new UserMeal
                {
                    UserId = user.Id,
                    Day = model.Day,
                    MealOfDay =MealOfDay.Lunch.ToString(),
                    MealId = model.LunchMealId
                },
                new UserMeal
                {
                    UserId = user.Id,
                    Day = model.Day,
                    MealOfDay = MealOfDay.Dinner.ToString(),
                    MealId = model.DinnerMealId
                }
            };

            await _dbContext.UserMeals.AddRangeAsync(newMeals);
            await _dbContext.SaveChangesAsync();
        }
    }
}
