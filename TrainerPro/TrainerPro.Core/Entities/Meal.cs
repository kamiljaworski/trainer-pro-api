using System;
using System.Collections.Generic;
using System.Text;

namespace TrainerPro.Core.Entities
{
    public class Meal
    {
        //ID | Title/Name  |  TotalMealKcal - to bym wyliczal na bieżąco
        public int MealId { get; set; }
        public string Title { get; set; }
        public ICollection<MealProduct> MealProducts { get; set; }
    }
}
