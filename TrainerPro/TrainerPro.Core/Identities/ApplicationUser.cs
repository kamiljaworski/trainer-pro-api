namespace TrainerPro.Core.Identities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using TrainerPro.Core.Entities;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
        public ICollection<TrainingPlan> TrainingPlans { get; set; }
    }
}
