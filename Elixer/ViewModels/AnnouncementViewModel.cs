using Elixer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Elixer.ViewModels
{
    public class AnnouncementViewModel : MyBaseViewModel
    {
        //  get all the rows in dictionary
        //Announcement ann = new Announcement();
<<<<<<< HEAD
        public List<Announcement> ann { get; set; }
=======
        public List<Announcement> ann;
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
       
        public Command LoadItemsCommand { get; set; }
        public AnnouncementViewModel()
        {
            Title = "Announcements";
            // Dictionary<string, object> info = ann.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            //.ToDictionary(prop => prop.Name, prop => prop.GetValue(ann, null));


            //var Items = Task.Run( ()=> GetAnnouncement());
            ann = new List<Announcement>();
            Task.Run( () => GetAnnouncement());

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        
        public async Task<List<Announcement>> GetAnnouncement()
        {
            try
            {
                HttpClient http = new HttpClient();
                var res = await http.GetStringAsync("https://localhost:44388/api/getting");
                var all = JsonConvert.DeserializeObject<List<Announcement>>(res);
                //return all;
                if(all == null)
                {
<<<<<<< HEAD
                    var mann = new List<Announcement>
                    {
                       new Announcement{id=1, description="no announcements", title="Announcements", updated_at=DateTime.Now, file="clf.png"}
                    };
                    foreach (var dat in mann)
                        ann.Add(dat);
=======
                    ann = new List<Announcement>
                    {
                       new Announcement{id=1, description="no announcements", title="Announcements", updated_at=DateTime.Now.Date, file="clf.png"}
                    };
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
                    return ann;              
                }
                else
                {
<<<<<<< HEAD
                    foreach (var dat in all)
                        ann.Add(dat);
=======
                    all = ann;
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
                }
                return ann;
            }
            catch(Exception ex)
            {
<<<<<<< HEAD
                var mann = new List<Announcement>
                {
                    new Announcement{id=1, description="Error: "+ex.Message, title="Announcements", updated_at=DateTime.Now, file="clf.png"}
                };
                foreach (var dat in mann)
                    ann.Add(dat);
=======
                ann = new List<Announcement>
                {
                    new Announcement{id=1, description="Error: "+ex.Message, title="Announcements", updated_at=DateTime.Now.Date, file="clf.png"}
                };
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
                return ann;
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ann.Clear();
                var items = await GetAnnouncement();
                foreach (var item in items)
                {
                    ann.Add(item);
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
    }
}
