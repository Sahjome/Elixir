﻿using Elixer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Elixer.ViewModels
{
   
    public class MediaViewModel : MyBaseViewModel
    {
        public List<Media> media { get; set; }
        public Command LoadItemsCommand { get; set; }

        public MediaViewModel()
        {
            media = new List<Media>();
            Task.Run(() => GetAnnouncement());

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

       public async Task<List<Media>> GetAnnouncement()
       {
            try
            {
                HttpClient http = new HttpClient();
                var res = await http.GetStringAsync("https://localhost:44388/api/media");
                var all = JsonConvert.DeserializeObject<List<Media>>(res);
                //return all;
                if (all == null)
                {
                   var medias = new List<Media>
                    {
                        new Media{id=1, description="no announcements", title="Announcements11", updated_at=DateTime.Now.Date, image="clf.png"}
                    };
                    foreach (var med in medias)
                        media.Add(med);
                    return media;
                }
                else
                {
                    foreach (var med in all)
                        media.Add(med);
                }
                return media;
            }
            catch (Exception ex)
            {
                var medias = new List<Media>
                {
                    new Media{id=1, description="Error: "+ex.Message, title="Announcements2", updated_at=DateTime.Now.Date, image="clf.png"}
                };
                foreach (var med in medias)
                    media.Add(med);
                return media;
            }
       }
    async Task ExecuteLoadItemsCommand()
    {
        if (IsBusy)
            return;

        IsBusy = true;

        try
        {
            media.Clear();
            var items = await GetAnnouncement();
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
    }


    
    
}
