namespace TrainerPro.Core.Entities
{
    using System;
    using TrainerPro.Core.Identities;

    public class UserMeal
    {
        public Guid UserId { get; set; }
        public ApplicationUser  User { get; set; }

        public int MealId { get; set; }
        public Meal Meal { get; set; }

        public string Day { get; set; }
        public string MealOfDay { get; set; }
    }
}
