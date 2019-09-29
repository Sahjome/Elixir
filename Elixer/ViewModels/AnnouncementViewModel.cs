using Elixer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Elixer.ViewModels
{
    public class AnnouncementViewModel
    {
        //  get all the rows in dictionary
        //Announcement ann = new Announcement();
        Announcement ann;
       
        public Command LoadItemsCommand { get; set; }
        public AnnouncementViewModel()
        {
            //Title = "Browse";
             Dictionary<string, object> info = ann.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .ToDictionary(prop => prop.Name, prop => prop.GetValue(ann, null));
             
            var Items = Task.Run( () => GetAnnouncement());
            
        }
        public async Task<List<Announcement>> GetAnnouncement()
        {
            HttpClient http = new HttpClient();
            var res = await http.GetStringAsync("http://10.0.0.2:44388/api/getting");
            var all = JsonConvert.DeserializeObject<List<Announcement>>(res);
            return all;
        }
    }
}
