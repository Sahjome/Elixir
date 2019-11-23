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
    public partial class AlumnusMenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public AlumnusMenuPage()
        {
            InitializeComponent();
            new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new HomeMenuItem {Id = MenuItemType.Giving, Title="Giving" },
                new HomeMenuItem {Id = MenuItemType.Announcements, Title="Announcements" },
                new HomeMenuItem {Id = MenuItemType.Media, Title="Media" },
                //new HomeMenuItem {Id = MenuItemType.Groups, Title="Groups" },
                //new HomeMenuItem {Id = MenuItemType.Counselling, Title="Counselling" },
                new HomeMenuItem {Id = MenuItemType.Settings, Title="Settings" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}