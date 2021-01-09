using System;
using System.Collections.Generic;

namespace web.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public User? Owner { get; set; }
        public Group? Group { get; set; }
        public DateTime DateCreated { get; set; }
    }
}