﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;

namespace TrainerPro.Services.Interfaces
{
    public interface ITrainerService
    {
        Task<IEnumerable<TrainerDTO>> GetTrainers();
    }
}