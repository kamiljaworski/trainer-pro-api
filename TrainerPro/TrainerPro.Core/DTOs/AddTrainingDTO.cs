namespace TrainerPro.Core.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class AddOrUpdateTrainingDTO
    {
        public int? TrainingId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Repeats { get; set; }

        [Required]
        public int Series { get; set; }

        [Required]
        public string Day { get; set; }
    }
}