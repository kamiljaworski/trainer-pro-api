using System;
using System.Collections.Generic;
using System.Text;

namespace TrainerPro.Core.Entities
{
    public class MealProduct
    {
        //ID | MealID | ProductID | Quantity
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int Quantity { get; set; }
    }
}
