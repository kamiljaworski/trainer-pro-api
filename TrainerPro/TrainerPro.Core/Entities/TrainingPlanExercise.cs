using System;
using System.Collections.Generic;
using System.Text;

namespace TrainerPro.Core.Entities
{
    public class TrainingPlanExercise
    {
        //ID | TrainingPlanID | ExerciseID | NumberOfSets| NumberOfReps | Weight[kg] | RecommendedTime | TimeSpent
        //RecomNumberOfSets| RecomNumberOfReps | RecomWeight[kg] |
        public int TrainingPlanExerciseId { get; set; }
        
        public int TrainingPlanId { get; set; }
        public TrainingPlan TrainingPlan { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int RecommendedNumberOfSets { get; set; }
        public int RecommendedNumberOfReps { get; set; }
        public int RecommendedWeight { get; set; }
        public TimeSpan RecommendedTime { get; set; }
        public int NumberOfSets { get; set; }
        public int NumberOfReps { get; set; }
        public int Weight { get; set; }
        public TimeSpan TimeSpent { get; set; }

    }
}
