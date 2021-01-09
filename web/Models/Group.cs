using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Event>? Events { get; set; }
        public ICollection<Message>? Messages { get; set; }
        public ICollection<GroupUser>? GroupUsers { get; set; }
    }
}