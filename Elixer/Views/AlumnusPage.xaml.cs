using Elixer.Models;
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
    public partial class AlumnusPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public AlumnusPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.About, (NavigationPage)Detail);
        }
        public async Task NavigateFromMenu(int id)
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