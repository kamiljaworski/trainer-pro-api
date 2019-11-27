using System;
using System.Collections.Generic;
using System.Text;

namespace TrainerPro.Core.Entities
{
    public class TrainingPlan
    {
        //ID | UserID | Date
        public int TraininfPlanId { get; set; }
        public int UserId { get; set; }
        public Asp Product { get; set; }
        public DateTime Date { get; set; }
        public ICollection<TrainingPlanExercise> TrainingPlanExercises { get; set; }
    }
}
