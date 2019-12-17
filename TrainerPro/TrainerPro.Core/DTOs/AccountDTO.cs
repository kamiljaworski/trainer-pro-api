namespace TrainerPro.Core.DTOs
{
    public class AccountDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public decimal? Weight { get; set; }
        public int? Height { get; set; }
        public int AccountTypeId { get; set; }
    }
}