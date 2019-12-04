using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;

namespace TrainerPro.Services.Interfaces
{
    public interface IMealService
    {
        Task<AddMealDTO> AddMealAsync(AddMealDTO model);
        Task DeleteMealByIdAsync(int id);
    }
}
