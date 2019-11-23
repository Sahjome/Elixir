using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elixer.Models
{
    public class Pictures
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string avatar { get; set; }
    }
}
