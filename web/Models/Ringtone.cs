using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Ringtone
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FileLocation { get; set; }
        public ICollection<Event>? Events { get; set; }
    }
}