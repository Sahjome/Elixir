﻿
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
<<<<<<< HEAD
using Plugin.CurrentActivity;
=======
using MediaManager.Forms.Platforms.Android;
using MediaManager;
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b

namespace Elixer.Droid
{
    [Activity(Label = "Elixer", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
<<<<<<< HEAD
            //CrossMediaManager.Current.Init(this);
            base.OnCreate(savedInstanceState);
            //VideoViewRenderer.Init();
            CrossCurrentActivity.Current.Init(this, savedInstanceState);

=======
            CrossMediaManager.Current.Init(this);
            base.OnCreate(savedInstanceState);
            //VideoViewRenderer.Init();
            
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        //{
        //    Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}