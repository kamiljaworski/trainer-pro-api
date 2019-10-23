namespace TrainerPro.Core.Identities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using TrainerPro.Core.Entities;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
    }
}
