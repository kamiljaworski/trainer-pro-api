using System.ComponentModel.DataAnnotations;

namespace TrainerPro.Core.DTOs
{
    public class AddOrUpdateUserMealDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
        public int BreakfastMealId { get; set; }

        [Required]
        public int LunchMealId { get; set; }

        [Required]
        public int DinnerMealId { get; set; }
    }
}