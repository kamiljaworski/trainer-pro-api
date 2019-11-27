using System;
using System.Collections.Generic;
using System.Text;

namespace TrainerPro.Core.Entities
{
    public class Exercise
    {
        //ID | Name | … |
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public ICollection<TrainingPlanExercise> TrainingPlanExercises { get; set; }
    }
}
