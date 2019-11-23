using System;
using System.Collections.Generic;
using System.Text;

namespace Elixer.Models
{
    public class Announcement
    {
        public int id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string file { get; set; }
        public string description { get; set; }
        public string details { get; set; }
        public DateTime updated_at { get; set; }
        
    }
}
