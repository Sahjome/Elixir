using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Elixer.Models;

namespace Elixer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.About, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            //if (Application.Current.Properties["Status"].ToString() == "Student")
            if(Application.Current.Properties.ContainsKey("Status"))
            {
                if (!MenuPages.ContainsKey(id))
                {
<<<<<<< HEAD
                    switch (id)
                    {
                        case (int)MenuItemType.About:
                            MenuPages.Add(id, new NavigationPage(new AboutPage()));
                            break;
                        case (int)MenuItemType.Browse:
                            MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                            break;
                        case (int)MenuItemType.Giving:
                            MenuPages.Add(id, new NavigationPage(new Giving()));
                            break;
                        case (int)MenuItemType.Announcements:
                            MenuPages.Add(id, new NavigationPage(new Announcement()));
                            break;
                        case (int)MenuItemType.Media:
                            MenuPages.Add(id, new NavigationPage(new Media()));
                            break;
                        case (int)MenuItemType.Groups:
                            MenuPages.Add(id, new NavigationPage(new Groups()));
                            break;
                        case (int)MenuItemType.Counselling:
                            MenuPages.Add(id, new NavigationPage(new Counselling()));
                            break;
                        case (int)MenuItemType.Settings:
                            MenuPages.Add(id, new NavigationPage(new Settings()));
                            break;
                    }
                }

            }
            else
            {
                if (!MenuPages.ContainsKey(id))
                {
                    switch (id)
                    {
                        case (int)MenuItemType.About:
                            MenuPages.Add(id, new NavigationPage(new AboutPage()));
                            break;
                        case (int)MenuItemType.Browse:
                            MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                            break;
                        case (int)MenuItemType.Giving:
                            MenuPages.Add(id, new NavigationPage(new Giving()));
                            break;
                        case (int)MenuItemType.Announcements:
                            MenuPages.Add(id, new NavigationPage(new Announcement()));
                            break;
                        case (int)MenuItemType.Media:
                            MenuPages.Add(id, new NavigationPage(new Media()));
                            break;
                        //case (int)MenuItemType.Groups:
                        //    MenuPages.Add(id, new NavigationPage(new Groups()));
                        //    break;
                        //case (int)MenuItemType.Counselling:
                        //    MenuPages.Add(id, new NavigationPage(new Counselling()));
                        //    break;
                        case (int)MenuItemType.Settings:
                            MenuPages.Add(id, new NavigationPage(new Settings()));
                            break;
                    }
=======
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.Giving:
                        MenuPages.Add(id, new NavigationPage(new Giving()));
                        break;
                    case (int)MenuItemType.Announcements:
                        MenuPages.Add(id, new NavigationPage(new Announcement()));
                        break;
                    case (int)MenuItemType.Media:
                        MenuPages.Add(id, new NavigationPage(new Media()));
                        break;
                    case (int)MenuItemType.Groups:
                        MenuPages.Add(id, new NavigationPage(new Groups()));
                        break;
                    case (int)MenuItemType.Counselling:
                        MenuPages.Add(id, new NavigationPage(new Counselling()));
                        break;
                    case (int)MenuItemType.Settings:
                        MenuPages.Add(id, new NavigationPage(new Settings()));
                        break;
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}