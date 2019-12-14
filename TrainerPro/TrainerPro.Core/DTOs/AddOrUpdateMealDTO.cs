namespace TrainerPro.Core.DTOs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddOrUpdateMealDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public IEnumerable<AddOrUpdateMealProductDTO> Products { get; set; }
    }

    public class AddOrUpdateMealProductDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
