namespace TrainerPro.Services.Interfaces
{
    using System.Threading.Tasks;
    using TrainerPro.Core.DTOs;
    using TrainerPro.Core.Models;

    public interface IAccountService
    {
        Task<AccountDTO> GetAccountByUsernameAsync(string username);
        Task UpdateAccountAsync(string username, UpdateAccountDTO model);
        Task RegisterAsync(RegisterDTO model);
        Task<TokenModel> LoginAsync(LoginDTO model);
    }
}
