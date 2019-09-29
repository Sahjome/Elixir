using System;
using System.Collections.Generic;
using System.Linq;
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
                    dat.Placeholder += "*";
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
        public async void Signup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SignUpPage()));
        }

       
        public async void Login_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(username.Text) || string.IsNullOrWhiteSpace(password.Text))
            {
                await DisplayAlert("Error", "Please check your input", "OK");
                Required();
            }
            //verify the credentials of the user from the api
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
        //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        public async void Clickred()
        {
            await Navigation.PushModalAsync(new NavigationPage(new SignUpPage()));
        }

        public ICommand ClickCommand => new Command(async () => Clickred());
    }
}