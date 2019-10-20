namespace TrainerPro.Core.Identities
{
    using Microsoft.AspNetCore.Identity;
    using TrainerPro.Core.Entities;

    public class ApplicationUser : IdentityUser<string>
    {
        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
    }
}
