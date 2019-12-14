namespace TrainerPro.Core.DTOs
{
    using System.Collections.Generic;
    using System.Linq;

    public class MealDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Kcal => Products.Sum(x => x.Kcal);

        public IEnumerable<MealProductDTO> Products { get; set; }
    }

    public class MealProductDTO
    {

        public int ProductId { get; set; }
        public int Weight { get; set; }
        public double Kcal { get; set; }
    }
}
