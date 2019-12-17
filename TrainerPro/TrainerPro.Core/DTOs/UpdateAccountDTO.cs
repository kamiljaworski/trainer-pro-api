namespace TrainerPro.Core.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateAccountDTO
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public decimal? Weight { get; set; }

        public int? Height { get; set; }

        public string Sex { get; set; }
    }
}
