namespace TrainerPro.Core.DTOs
{
    public class UserMealDTO
    {
        public string UserId { get; set; }
        public string Day { get; set; }
        public string BreakfastMealName { get; set; }
        public int BreakfastMealId { get; set; }
        public string LunchMealName { get; set; }
        public int LunchMealId { get; set; }
        public string DinnerMealName { get; set; }
        public int DinnerMealId { get; set; }
    }
}