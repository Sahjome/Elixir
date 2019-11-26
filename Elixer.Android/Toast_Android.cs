using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
<<<<<<< HEAD
using Elixer.Services;
using Toast = Elixer.Services.Toast;
=======
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(Elixer.Droid.Toast_Android))]
namespace Elixer.Droid
{

<<<<<<< HEAD
    public class Toast_Android : Toast
=======
    public class Toast_Android : Services.Toast
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
    {
        public void Show(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}