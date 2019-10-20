namespace TrainerPro.Core.Entities
{
    using System.Collections.Generic;
    using TrainerPro.Core.Identities;

    public class AccountType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
