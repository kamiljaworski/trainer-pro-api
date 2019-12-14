using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;

namespace TrainerPro.Services.Interfaces
{
    public interface IExerciseService
    {
        Task<AddExerciseDTO> AddExerciseAsync(AddExerciseDTO model);
        Task<IEnumerable<GetExerciseDTO>> GetExercisesAsync();
        Task<AddExerciseDTO> GetExerciseByIdAsync(int id);
        Task<AddExerciseDTO> UpdateExerciseAsync(AddExerciseDTO model);
        Task DeleteExerciseByIdAsync(int id);
    }
}
