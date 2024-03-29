﻿using OL;
using System.Collections.Generic;

namespace DTOs
{
    public class AppUserListDto : IDto
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }

        public List<ObjAppUserRole> AppUserRoles { get; set; }
        public List<ObjBlogAppUser> BlogAppUsers { get; set; }
    }
}
