﻿namespace TrainerPro.Api.Helpers.Models
{
    public class EmailSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
    }
}