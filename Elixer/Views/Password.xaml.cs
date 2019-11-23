using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elixer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Password : ContentPage
    {
        public Password()
        {
            InitializeComponent();
            confirm.Focused += (s, e) => confirm.TextChanged += (x, y) => Compare();
        }

        private readonly string oldPassword = Application.Current.Properties["Password"].ToString();

        void Compare()
        {
            if(confirm.Text != @new.Text)
            {
                confirm.BackgroundColor = Color.Red;
                confirm.Placeholder += "*";
                submit.Clicked += (s, e) => submit.IsEnabled = false;
            }
        }

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            if((!string.IsNullOrEmpty(old.Text)) || (!string.IsNullOrEmpty(@new.Text)) || (!string.IsNullOrEmpty(confirm.Text)))
            {
                if (old.Text != oldPassword)
                {
                    await DisplayAlert("Response", "Password incorrect", "OK");
                }
                else
                {
                    Application.Current.Properties.Remove("Password");
                    Application.Current.Properties["Password"] = @new.Text;
                    await DisplayAlert("Success", "Password saved", "OK");

                }
            }
            else
            {
                    await DisplayAlert("Response", "Please fill all fields correctly", "OK");
            }
        }
    }
}