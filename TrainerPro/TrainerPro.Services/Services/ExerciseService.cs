using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;
using TrainerPro.Core.Entities;
using TrainerPro.DAL;
using TrainerPro.Services.Interfaces;

namespace TrainerPro.Services.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly TrainerProContext _dbContext;

        public ExerciseService(TrainerProContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddExerciseDTO> AddExerciseAsync(AddExerciseDTO model)
        {
            var ExerciseExists = await _dbContext.Exercises.AnyAsync(c => c.Name == model.Name);
            if (ExerciseExists)
                throw new InvalidOperationException("This Exercise already exist.");

            var newExercise = new Exercise
            {
                Name = model.Name,
            };

            _dbContext.Exercises.Add(newExercise);
            await _dbContext.SaveChangesAsync();

            return GetExerciseDTOFromExerciseEntity(newExercise);
        }

        public async Task<IEnumerable<GetExerciseDTO>> GetExercisesAsync()
        {
            var exercises = await _dbContext.Exercises
                .Select(p => new GetExerciseDTO
                {
                    Id = p.ExerciseId,
                    Name = p.Name,
                }).ToListAsync();

            return exercises;
        }

        public async Task<AddExerciseDTO> GetExerciseByIdAsync(int id)
        {
            var exercise = await _dbContext.Exercises.SingleOrDefaultAsync(p => p.ExerciseId == id);

            if (exercise == null)
                throw new InvalidOperationException("This Exercise doesn't exist.");

            return GetExerciseDTOFromExerciseEntity(exercise);
        }

        public async Task<AddExerciseDTO> UpdateExerciseAsync(AddExerciseDTO model)
        {
            var exercise = await _dbContext.Exercises.SingleOrDefaultAsync(c => c.Name == model.Name);

            if (exercise == null)
                throw new InvalidOperationException("This Exercise doesn't exist.");

            exercise.Name = model.Name;

            await _dbContext.SaveChangesAsync();

            return GetExerciseDTOFromExerciseEntity(exercise);
        }

        public async Task DeleteExerciseByIdAsync(int id)
        {
            var exercise = await _dbContext.Exercises.SingleOrDefaultAsync(c => c.ExerciseId == id);

            if (exercise == null)
                throw new InvalidOperationException("This Exercise doesn't exist.");

            _dbContext.Exercises.Remove(exercise);
            await _dbContext.SaveChangesAsync();
        }

        private AddExerciseDTO GetExerciseDTOFromExerciseEntity(Exercise exercise)
        {
            return new AddExerciseDTO
            {
                Name = exercise.Name,
            };
        }
    }
}
