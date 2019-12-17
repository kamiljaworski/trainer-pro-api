namespace TrainerPro.Core.Identities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using TrainerPro.Core.Entities;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
        public decimal? Weight { get; set; }
        public int? Height { get; set; }
        public string Sex { get; set; }

        public Guid? TrainerId { get; set; }
        public ApplicationUser Trainer { get; set; }
        public ICollection<ApplicationUser> Clients { get; set; }

        public ICollection<Training> Trainings { get; set; }
        public ICollection<UserMeal> UserMeals { get; set; }
    }
}
