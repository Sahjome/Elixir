﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Elixer.Services;
using Toast = Elixer.Services.Toast;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(Elixer.Droid.Toast_Android))]
namespace Elixer.Droid
{

    public class Toast_Android : Toast
    {
        public void Show(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}