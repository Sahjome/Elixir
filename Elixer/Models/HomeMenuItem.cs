using System;
using System.Collections.Generic;
using System.Text;

namespace Elixer.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Giving,
        Announcements,
        Media,
        Groups,
        Counselling,
        Settings
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        //public string icon { get; set; }
    }
}
