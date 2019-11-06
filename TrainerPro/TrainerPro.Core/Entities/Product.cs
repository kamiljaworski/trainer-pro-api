using System;
using System.Collections.Generic;
using System.Text;

namespace TrainerPro.Core.Entities
{
    public class Product
    {
        //ID | Name| Carbohydrates/100g | Fat/100g |Protein/100g | Kcal/100g | MealId | 
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double CarbsPer100g { get; set; }
        public double FatPer100g { get; set; }
        public double ProteinPer100g { get; set; }
        public double KcalPer100g { get; set; }
        public ICollection<MealProduct> MealProducts { get; set; }
    }
}
