namespace TrainerPro.Services.Interfaces
{
    using System.Threading.Tasks;
    using TrainerPro.Core.DTOs;
    using TrainerPro.Core.Identities;
    using TrainerPro.Core.Models;

    public interface IAccountService
    {
        Task RegisterAsync(RegisterDTO model);
        Task<TokenModel> LoginAsync(LoginDTO model);
        Task<ApplicationUser> GetTrainers();
    }
}
