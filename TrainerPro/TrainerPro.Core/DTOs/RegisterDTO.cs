namespace TrainerPro.Core.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RepeatPassword { get; set; }

        [Required]
        public int AccountTypeId { get; set; }
    }
}
