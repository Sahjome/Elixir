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
    public partial class Committee : ContentPage
    {
        public Committee()
        {
            InitializeComponent();
            BindingContext = join;
            string name = surname + ", " + firstname + " " + "othername";
            BindingContext = name;
        }
        string grp;

        void Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int sel = picker.SelectedIndex;

            grp = (sel == 0) ? "Church Office" : (sel == 1) ? "ForeRunner" : (sel == 2) ? "Sprcial Duties" : (sel == 3) ? 
                "Word House" : (sel == 4) ? "Watch Tower" : (sel == 5) ? "Firm Foundation" : (sel == 6) ? "Power and Sound" : null;
        }

        string join = "We believe that God gives everyone gifts and talents, and we should use them to serve one another in love. " +
            "Service to God and His Church is a vital part of our culture in CLF, and provides an opportunity for us to develop " +
            "our talents, discover hidden giftings and advance the Body of Christ.\r\nFill the Sign-Up Form to find out where " +
            "you can serve in Church with the skills you have.";
        string firstname = Application.Current.Properties["Firstname"].ToString();
        string surname = Application.Current.Properties["Surname"].ToString();
        string othername = Application.Current.Properties["Othername"].ToString();
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
                    await DisplayAlert("Response", "Please check your input.", "OK");
                }
                else
                {
                    GroupClass clas = new GroupClass
                    {
                        Group = grp,
                        Firstname = Details.Username = firstname,
                        Surname = Details.Surname = surname,
                        Othername = Details.Othername = othername
                    };
                    var json = JsonConvert.SerializeObject(clas);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpClient http = new HttpClient();
                    var res = http.PostAsync("https://localhost:44388/api/comm", content);
                    Dictionary<string, object> data = new Dictionary<string, object>
                    {
                        {"Success", HttpStatusCode.OK },
                        {"Failed", HttpStatusCode.BadRequest }
                    };
                    if (res.Result == data["Success"])
                    {
                        Application.Current.Properties["Committee"] = grp;
                        await DisplayAlert("Success", "Application sent.", "OK");
                    }
                    else
                    {
                        DependencyService.Get<Toast>().Show("Try Again");
                    }
                }
            }
            catch (Exception)
            {
                DependencyService.Get<Toast>().Show("Try Again");
            }

        }
    }
}