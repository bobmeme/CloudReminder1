using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime EventDate { get; set; }
        public User? Owner { get; set; }
        public Group? Group { get; set; }
        public Ringtone? Ringtone { get; set; }
    }
}