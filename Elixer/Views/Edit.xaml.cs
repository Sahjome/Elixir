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
    public partial class Edit : ContentPage
    {
        Profiles profile = new Profiles();
        public Edit()
        {
            InitializeComponent();
            profile.Firstname = Application.Current.Properties["Firstname"].ToString();
            profile.Surname = Application.Current.Properties["Surname"].ToString();
            profile.Othername = Application.Current.Properties["Othername"].ToString();
            profile.Username = Application.Current.Properties["Username"].ToString();
            profile.Email = Application.Current.Properties["Email"].ToString();
            profile.Sex = Application.Current.Properties["Sex"].ToString();
            profile.Phone = Application.Current.Properties["Phone"].ToString();
            profile.Address = Application.Current.Properties["Address"].ToString();
            profile.Dept = Application.Current.Properties["Dept"].ToString();
            profile.Status = Application.Current.Properties["Status"].ToString();
            profile.DOB = DateTime.Parse(Application.Current.Properties["DOB"].ToString());
            profile.Grad = DateTime.Parse(Application.Current.Properties["Grad"].ToString());
            string occupation = Application.Current.Properties["Occupation"].ToString();
            BindingContext = profile;
            BindingContext = occupation;
        }

        string status;

        void Required()
        {
            List<Entry> entries = new List<Entry>
            {
                fname, sname, uname, email, phone,

            };
            foreach (var dat in entries)
            {
                if (string.IsNullOrWhiteSpace(dat.Text))
                {
                    //dat.Placeholder.Insert(-1, "*");
                    dat.Placeholder += "*";
                    dat.PlaceholderColor = Color.Red;
                }
            }
        }
        void Mem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            status = picker.SelectedItem.ToString();
        }

        protected override void OnAppearing()
        {
            submit.Clicked += Submit_Clicked;
        }
        async void Submit_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fname.Text) || string.IsNullOrWhiteSpace(sname.Text) ||
                string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(phone.Text) ||
                string.IsNullOrWhiteSpace(uname.Text))
            {
                await DisplayAlert("Error", "Please make sure all required fields are filled properly ", "OK");
                Required();
            }
            else
            {
                bool update = await DisplayAlert("Response", "Are you sure you want to save changes?", "Save", "Cancel");
                if (update)
                {
                    string address = (string.IsNullOrEmpty(raddy.Text)) ? (haddy.Text) : raddy.Text;
                    //continue to save
                    if (Application.Current.Properties.ContainsKey("Username"))
                    {
                        //call the update api first
                        Dictionary<string, object> prof = new Dictionary<string, object>
                        {
                            { "firstname", fname.Text },
                            { "surname", sname.Text},
                            { "email", email.Text },
                            { "phone", phone.Text },
                            { "username", uname.Text },
                            { "sex", sex.Text },
                            { "dob", dob.Date },
                            { "status", status },
                            { "department", dept.Text },
                            { "grad", grad.Date },
                            { "othername", oname.Text },
                            { "address", address }
                        };
                       
                        var json = JsonConvert.SerializeObject(prof);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        HttpClient http = new HttpClient();
                        var res = http.PostAsync("https://localhost:44388/api/profiles", content);
                        Dictionary<string, object> data = new Dictionary<string, object>
                        {
                            {"Success", HttpStatusCode.OK },
                            {"Failed", HttpStatusCode.BadRequest }
                        };
                        if (res.Result == data["Success"])
                        {
                            //save to local storage     
                            Application.Current.Properties["Firstname"] = fname.Text;
                            Application.Current.Properties["Surname"] = sname.Text;
                            Application.Current.Properties["Email"] = email.Text;
                            Application.Current.Properties["Phone"] = phone.Text;
                            Application.Current.Properties["Username"] = uname.Text;
                            Application.Current.Properties["Sex"] = sex.Text;
                            Application.Current.Properties["DOB"] = dob.Date;
                            Application.Current.Properties["Status"] = status;
                            Application.Current.Properties["Dept"] = dept.Text;
                            Application.Current.Properties["Grad"] = grad.Date;
                            Application.Current.Properties["Othername"] = oname.Text;
                            Application.Current.Properties["Address"] = address;
                            Application.Current.Properties["Occupation"] = occupation.Text;
                            await DisplayAlert("Success", "Saved.", "OK");
                        }
                        else
                        {
                            DependencyService.Get<Toast>().Show("Error, Try Again");
                        }
                    }
                    else
                    {
                        DependencyService.Get<Toast>().Show("Error, Try Again");
                    }
                }
            }
        }
    }
}