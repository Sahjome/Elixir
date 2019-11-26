using Elixer.Models;
using Elixer.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elixer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LifeGroup : ContentPage
    {
        public LifeGroup()
        {
            InitializeComponent();
            BindingContext = join;
<<<<<<< HEAD
            string name = surname + ", " + firstname + " " + "othername";
            BindingContext = name;
        }
        string grp;

        void Group_SelectedIndexChanged(object sender, EventArgs e)
=======
        }
        string grp;

        void Mem_SelectedIndexChanged(object sender, EventArgs e)
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
        {
            var picker = (Picker)sender;
            int sel = picker.SelectedIndex;

            grp = (sel == 0) ? "Campus" : (sel == 1) ? "Maintenance" : (sel == 2) ? "Ede Road" : (sel == 3) ? "Ibadan Road" : (sel == 4) ?
                "Mayfair" : (sel == 5) ? "OUI" : null;
        }

        string join = "LifeGroups are our small group meetings that hold every Friday both on Campus and off Campus. They provide an " +
            "opportunity for you to connect with other Christlovers in a comfortable and relaxed atmosphere. In a LifeGroup, " +
            "you have a close network of people to pray with and grow together in understanding God’s word.\r\nReady " +
            "to join? Fill the Sign-Up Form to get started.";
<<<<<<< HEAD
        string firstname = Application.Current.Properties["Firstname"].ToString();
        string surname = Application.Current.Properties["Surname"].ToString();
        string othername = Application.Current.Properties["Othername"].ToString();
=======
        
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b

        protected override void OnAppearing()
        {
            submitBtn.Clicked += Submit_Clicked;
        }

        async void Submit_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(grp))
                {
<<<<<<< HEAD
                    await DisplayAlert("Response", "Please check your input.", "OK");
=======
                    await DisplayAlert("Response","Please check your input.","OK");
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
                }
                else
                {
                    GroupClass clas = new GroupClass
                    {
                        Group = grp,
<<<<<<< HEAD
                        Firstname = Details.Username = firstname,
                        Surname = Details.Surname = surname,
                        Othername = Details.Othername = othername
=======
                        Username = Details.Username
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
                    };
                    var json = JsonConvert.SerializeObject(clas);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpClient http = new HttpClient();
                    var res = http.PostAsync("https://localhost:44388/api/group", content);
                    Dictionary<string, object> data = new Dictionary<string, object>
                    {
                        {"Success", HttpStatusCode.OK },
                        {"Failed", HttpStatusCode.BadRequest }
                    };
                    if (res.Result == data["Success"])
                    {
<<<<<<< HEAD
                        Application.Current.Properties["LGroup"] = grp;
=======
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
                        await DisplayAlert("Success", "Application sent.","OK");   
                    }
                    else
                    {
                        DependencyService.Get<Toast>().Show("Try Again");
                    }
                }
            }
            catch(Exception)
            {
                DependencyService.Get<Toast>().Show("Try Again");
            }

        }
    }
}