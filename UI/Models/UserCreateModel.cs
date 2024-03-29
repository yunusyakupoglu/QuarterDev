﻿using Microsoft.AspNetCore.Http;

namespace UI.Models
{
    public class UserCreateModel
    {
        public string ImagePath { get; set; }
        public IFormFile FileDoc { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
