using System;
using System.Collections.Generic;
using System.Text;
using TrainerPro.Core.Identities;

namespace TrainerPro.Core.Entities
{
    public class TrainingPlan
    {
        //ID | UserID | Date
        public int TrainingPlanId { get; set; }
        public ApplicationUser UserId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<TrainingPlanExercise> TrainingPlanExercises { get; set; }
    }
}
