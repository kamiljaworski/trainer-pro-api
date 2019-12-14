namespace TrainerPro.Core.Entities
{

    using System.Collections.Generic;
    public class Meal
    {
        //ID | Title/Name  |  TotalMealKcal - to bym wyliczal na bieżąco
        public int MealId { get; set; }
        public string Title { get; set; }
        public ICollection<MealProduct> MealProducts { get; set; }
        public ICollection<UserMeal> UserMeals { get; set; }
    }
}
