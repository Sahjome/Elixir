using System;
using System.Collections.Generic;
using System.Text;

namespace Elixer.Models
{
    public class Announcement
    {
        public string title { get; set; }
        public string type { get; set; }
        public string file { get; set; }
        public string description { get; set; }
        public DateTime ipdated_at { get; set; }
        
    }
}
