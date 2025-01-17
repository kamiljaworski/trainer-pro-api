﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrainerPro.Core.DTOs
{
    public class ClientDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public int? Height { get; set; }
        public decimal? Weight { get; set; }
    }
}
