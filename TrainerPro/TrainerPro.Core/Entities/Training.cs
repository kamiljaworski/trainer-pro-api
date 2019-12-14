using System;
using System.Collections.Generic;
using System.Text;
using TrainerPro.Core.Identities;

namespace TrainerPro.Core.Entities
{
    public class Training
    {
        //ID | UserID | Date
        public int Id { get; set; }
        public string Name { get; set; }
        public int Repeats { get; set; }
        public int Series { get; set; }
        public string Day { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
