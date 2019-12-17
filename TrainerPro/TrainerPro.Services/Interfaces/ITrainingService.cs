namespace TrainerPro.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TrainerPro.Core.DTOs;

    public interface ITrainingService
    {
        Task<IEnumerable<TrainingDTO>> GetTrainingsByUsernameAsync(string username);
        Task AddTrainingAsync(AddTrainingDTO model);
    }
}
