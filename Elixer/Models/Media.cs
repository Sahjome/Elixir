using System;
using System.Collections.Generic;
using System.Text;

namespace Elixer.Models
{
    public class Media
    {
        public int id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string file { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string diet { get; set; }
        public string details { get; set; }
        public DateTime updated_at { get; set; }
    }
}
