<<<<<<< HEAD
﻿using Elixer.Models;
using System;
=======
﻿using System;
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elixer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Counselling : ContentPage
    {
<<<<<<< HEAD
        Details details;
        public Counselling()
        {
            InitializeComponent();
            BindingContext = uname;
        }

        string uname = Details.Username;

        private async void Submit_Clicked(object sender, EventArgs e)
        {
            //call the api to send mail
=======
        public Counselling()
        {
            InitializeComponent();
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
        }
    }
}