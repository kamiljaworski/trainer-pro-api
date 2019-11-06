using System;
using System.Collections.Generic;
using System.Text;

namespace TrainerPro.Core.DTOs
{
    public class GetProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CarbsPer100g { get; set; }
        public double FatPer100g { get; set; }
        public double ProteinPer100g { get; set; }
        public double KcalPer100g { get; set; }
    }
}
