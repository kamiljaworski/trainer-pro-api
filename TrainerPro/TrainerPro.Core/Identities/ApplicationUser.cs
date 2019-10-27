﻿namespace TrainerPro.Core.Identities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using TrainerPro.Core.Entities;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
    }
}
