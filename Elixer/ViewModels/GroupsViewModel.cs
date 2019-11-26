<<<<<<< HEAD
﻿using Elixer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Elixer.ViewModels
{
    public class GroupsViewModel : MyBaseViewModel
    {
        public List<Media> media { get; set; }
        public Command LoadItemsCommand { get; set; }
        public GroupsViewModel()
        {
            Title = "Detailer";
            media = new List<Media>();
            Task.Run(() => GetAnnouncement());

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        public List<Media> GetAnnouncement()
        {
            var mann = new List<Media>
            {
               new Media{ id=1, description="We are celebrating today", title="Celebration", image="clf.png",
                   details ="we in the western part say hello", type="Media", updated_at=DateTime.Now},
               new Media{ id=2, description="We are celebrating tonight", title="Dedication", image="clf.png",
                   details ="we in the southern part say hello", type="Advertisement", updated_at=DateTime.Now},
               new Media{ id=3, description="We are celebrating yesterday", title="Thanksgiving", image="clf.png",
                   details ="we in the eastern part say hello", type="Warning", updated_at=DateTime.Now},
                new Media{ id=4, description="We are celebrating tomorrow", title="Birthday", image="clf.png",
                    details ="we in the northern part say hello", type="Message", updated_at=DateTime.Now},
                new Media{ id=4, description="We are celebrating tomorrow", title="Birthday", image="clf.png",
                    details ="we in the northern part say hello", type="Message", updated_at=DateTime.Now}
                ,new Media{ id=4, description="We are celebrating tomorrow", title="Birthday", image="clf.png",
                    details ="we in the northern part say hello", type="Message", updated_at=DateTime.Now},
                new Media{ id=4, description="We are celebrating tomorrow", title="Birthday", image="clf.png",
                    details ="we in the northern part say hello", type="Message", updated_at=DateTime.Now},
                new Media{ id=4, description="We are celebrating tomorrow", title="Birthday", image="clf.png",
                    details ="we in the northern part say hello", type="Message", updated_at=DateTime.Now},
                new Media{ id=4, description="We are celebrating tomorrow", title="Birthday", image="clf.png",
                    details ="we in the northern part say hello", type="Message", updated_at=DateTime.Now},
            };
            foreach (var dat in mann)
                media.Add(dat);
            return media;
        }

       
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                media.Clear();
                var items = await Task.Run(() => GetAnnouncement());
                foreach (var item in items)
                {
                    media.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
=======
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Elixer.ViewModels
{
    class GroupsViewModel
    {
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
    }
}
