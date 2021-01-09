using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace web.Models
{
    public class User : IdentityUser 
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public ICollection<GroupUser>? GroupUsers { get; set; }
        public DateTime Date { get; set; }
    }
}