<<<<<<< HEAD
﻿using Elixer.Services;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elixer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
<<<<<<< HEAD
            Notifications();
            BindingContext = this;
        }

        public ICommand clickCommand2 => new Command(() => Application.Current.MainPage = new Password());
        public ICommand clickCommand1 => new Command(() => Application.Current.MainPage = new Edit());
        public ICommand clickCommand => new Command(async () => await SelectPictureAsync());

        private async Task SelectPictureAsync()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                DependencyService.Get<Toast>().Show("unsupported photo");
                return;
            }
            try
            {
                Stream stream = null;
                var photo = await CrossMedia.Current.PickPhotoAsync().ConfigureAwait(true);

                if (photo == null)
                    return;

                stream = photo.GetStream();
                photo.Dispose();
                var avatar = (object)ImageSource.FromStream(() => stream);
                avatar = Application.Current.Properties["Avatar"];
            }
            catch(Exception ex)
            {
                DependencyService.Get<Toast>().Show("Error, try again");
            }
        }
        void Notifications()
        {
            Application.Current.Properties["Notification"] = (notifications.IsToggled == false) ? "false" : "true";
=======
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
        }
    }
}