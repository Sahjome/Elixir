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
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elixer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
       
        public SignUpPage()
        {
            InitializeComponent();
            form.IsVisible = false;
            formtitle.IsVisible = false;
            BindingContext = this;
            
        }

        string _sex;
        void Required()
        {
            List<Entry> entries = new List<Entry>
            {
                fname, sname, uname, email, pass, phone,
               
            };
            foreach (var dat in entries)
            {
                if (string.IsNullOrWhiteSpace(dat.Text))
                {
                    //dat.Placeholder.Insert(-1, "*");
                    dat.Placeholder = dat.Placeholder+"*";
                    dat.PlaceholderColor = Color.Red;
                }
            }
               
        }

        private void Sex_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int sel = picker.SelectedIndex;
            _sex = (sel == 0) ? "female" : (sel == 1) ? "male" : null;
            //_sex = sel.ToString();

        }
        void Mover()
        {
            fname.Focus();
            fname.Completed += (s, e) => sname.Focus();
            sname.Completed += (s, e) => oname.Focus();
            oname.Completed += (s, e) => uname.Focus();
            uname.Completed += (s, e) => email.Focus();
            email.Completed += (s, e) => phone.Focus();
            phone.Completed += (s, e) => pass.Focus();
            pass.Completed += (s, e) => conpass.Focus();
            conpass.Completed += (s, e) => haddy.Focus();
            haddy.Completed += (s, e) => dept.Focus();
            dept.Completed += (s, e) => raddy.Focus();
            raddy.Completed += (s, e) => occupation.Focus();
            occupation.Completed += (s, e) => dob.Focus();
            dob.DateSelected += (s, e) => grad.Focus();
            grad.DateSelected += (s, e) => Submit_Clicked(s, e);
        }

        public bool Vericheck(string a, string b)
        {
            string.Compare(a, b);
            return true;
        }

        void Mem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int sel = picker.SelectedIndex;
            //form.IsVisible = true;
            if (sel == 0)
            {
                Mover();
                //member = "Alumnus";
                form.IsVisible = true;
                formtitle.IsVisible = true;
                intro.IsVisible = false;
                student.IsVisible = false;
                alumnus.IsVisible = true;
                gradyr.IsVisible = true;
                typefirst.IsVisible = false;
                memtype.SelectedIndex = sel;
            }
            else
            {
                Mover();
                //member = "Student";
                form.IsVisible = true;
                formtitle.IsVisible = true;
                intro.IsVisible = false;
                typefirst.IsVisible = false;
                student.IsVisible = true;
                alumnus.IsVisible = false;
                gradyr.IsVisible = false;
                memtype.SelectedIndex = sel;
            }

            //return member;

        }

        protected override void OnAppearing()
        {
            submit.Clicked += Submit_Clicked;
        }

        public async void Submit_Clicked(object sender, EventArgs e)
        {
            if(string.Equals(uname.Text, "Pastor"))
                await DisplayAlert("Error", "Username cannot be "+uname.Text, "OK");
            //check entry
            if (string.IsNullOrWhiteSpace(fname.Text) || string.IsNullOrWhiteSpace(sname.Text) || 
                string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(phone.Text) || 
                string.IsNullOrWhiteSpace(pass.Text) || string.Equals(uname.Text, "Pastor") || string.IsNullOrWhiteSpace(uname.Text) || string.IsNullOrEmpty(_sex))
            {
                await DisplayAlert("Error", "Please make sure all required fields are filled properly ", "OK");
                Required();
            }
            else
            {
                var coin = Vericheck(pass.Text, conpass.Text);
                if(coin)
                {
                    //member = memtype.SelectedItem.ToString();//for member type
                    //verify that all the credentials are not in db and insert thru api 
                    string status = memtype.SelectedItem.ToString();
                    string address = (string.IsNullOrEmpty(raddy.Text)) ? (haddy.Text) : raddy.Text;
                    Dictionary<string, object> prof = new Dictionary<string, object>
                    {
                        { "firstname", fname.Text },
                        { "surname", sname.Text},
                        { "email", email.Text },
                        { "phone", phone.Text },
                        { "username", uname.Text },
                        { "sex", _sex },
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
                        Application.Current.Properties["Firstname"] = fname.Text;
                        Application.Current.Properties["Surname"] = sname.Text;
                        Application.Current.Properties["Email"] = email.Text;
                        Application.Current.Properties["Phone"] = phone.Text;
                        Application.Current.Properties["Username"] = uname.Text;
                        Application.Current.Properties["Sex"] = _sex;
                        Application.Current.Properties["DOB"] = dob.Date;
                        Application.Current.Properties["Status"] = status;
                        Application.Current.Properties["Dept"] = dept.Text;
                        Application.Current.Properties["Grad"] = grad.Date;
                        Application.Current.Properties["Othername"] = oname.Text;
                        Application.Current.Properties["Address"] = address;
                        Application.Current.Properties["Occupation"] = occupation.Text;
                        Application.Current.Properties["Password"] = pass.Text;
                        await DisplayAlert("Success", "Welcome " + fname.Text + " " + oname.Text + " " + sname.Text, "OK");
                        //await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
                        Application.Current.MainPage = new LoginPage();

                    }
                    else
                    {
                        DependencyService.Get<Toast>().Show("Try Again");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Please confirm your password","OK");
                }
            }
        }
        public async Task Clickred()
        {
            //await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
            Application.Current.MainPage = new LoginPage();
        }

        public ICommand clickCommand => new Command(async () => await Clickred());
    }
}