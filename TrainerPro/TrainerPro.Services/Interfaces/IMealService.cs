namespace TrainerPro.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TrainerPro.Core.DTOs;

    public interface IMealService
    {
        Task AddOrUpdateMealAsync(AddOrUpdateMealDTO model);
        Task<IEnumerable<MealDTO>> GetMealsAsync();
        Task<IEnumerable<UserMealDTO>> GetUserMealsByUsernameAsync(string username);
        Task AddOrUpdateUserMealAsync(AddOrUpdateUserMealDTO model);
    }
}
