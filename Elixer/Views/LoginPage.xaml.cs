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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Mover();
            BindingContext = this;
        }

        void Required()
        {
            List<Entry> entries = new List<Entry>
            {
                username, password
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

            public void Mover()
        {
            //username.Focus();
            username.Completed += (s, e) => password.Focus();
            password.Completed += (s, e) => Login_Clicked(s, e);
        }
        protected override void OnAppearing()
        {
            loginBtn.Clicked += Login_Clicked;
        }

        public async void Login_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(username.Text) || string.IsNullOrWhiteSpace(password.Text))
            {
                DependencyService.Get<Toast>().Show("Please check your input");
                Required();
            }
            else
            { 
                string _username = Application.Current.Properties["Username"].ToString();
                string _email = Application.Current.Properties["Email"].ToString();
                string _password = Application.Current.Properties["Password"].ToString();
                if (Application.Current.Properties.ContainsKey("Username") && Application.Current.Properties.ContainsKey("Password"))
                {
                    if((username.Text == _username ||username.Text == _email) && password.Text == _password)
                    {
                        //await Navigation.PushModalAsync(new NavigationPage(new MainPage()))
                        App.Current.MainPage = new MainPage();
                    }
                    else
                    {
                        await DisplayAlert("Response", "Wrong login credentials", "OK");
                        //DependencyService.Get<Toast>().Show("Try again");
                    }
                }
                else if (Application.Current.Properties.ContainsKey("Username") && !Application.Current.Properties.ContainsKey("Password"))
                {
                    //verify the credentials of the user from the api
                    Dictionary<string, object> data = new Dictionary<string, object>
                    {
                        {"username", username.Text },
                        {"password", password.Text }
                    };
                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpClient http = new HttpClient();
                    var res = await http.PostAsync("https://localhost:44388/api/login", content);
                    
                    if (res.IsSuccessStatusCode)
                    {
                        Application.Current.Properties["Password"] = password.Text;
                        App.Current.MainPage = new MainPage();
                    }
                    else
                    {
                        DependencyService.Get<Toast>().Show("Try Again");
                    }
                }
            }
        }
        //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        public async Task Clickred()
        {
           Application.Current.MainPage = new SignUpPage();
        }
        public async Task ForgotPassword()
        {
            bool reset = await DisplayAlert("Reset Password", "Your current password will be deleted", "OK", "Cancel");
            if (reset)
            {
                if (Application.Current.Properties.ContainsKey("Password"))
                {
                    Application.Current.Properties.Remove("Password");
                    //call the mailing api
                    Dictionary<string, object> data = new Dictionary<string, object>
                    {
                        {"username",  Application.Current.Properties["Email"]},
                        {"message", "forgot password" }
                    };
                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpClient http = new HttpClient();
                    var res = await http.PostAsync("https://localhost:44388/api/mailer", content);

                    if (res.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Response", "Check your mail, a new password has been sent.", "OK");
                    }
                    else
                    {
                        DependencyService.Get<Toast>().Show("Try Again");
                    }
                }
                else
                {
                    DependencyService.Get<Toast>().Show("No Password");
                }
            }
            
        }

        public ICommand clickCommand => new Command(async () => await Clickred());
        public ICommand clickCommand1 => new Command(async () => await ForgotPassword());
    }
}