using System.ComponentModel.DataAnnotations;

namespace TrainerPro.Core.DTOs
{
    public class AssignToTrainerDTO
    {
        [Required]
        public string TrainerId { get; set; }
    }
}
