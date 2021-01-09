using System;
using System.Collections.Generic;

namespace web.Models
{
    public class GroupUser
    {
        
        public string UserId { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
        public User User { get; set; }
    }
}