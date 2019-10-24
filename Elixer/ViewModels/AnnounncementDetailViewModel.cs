using Elixer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elixer.ViewModels
{
    public class AnnounncementDetailViewModel : MyBaseViewModel
    {
        public Announcement ann { get; set; }

        public AnnounncementDetailViewModel(Announcement item = null)
        {
            Title = item?.title;
            ann = item;
        }
    }
}
