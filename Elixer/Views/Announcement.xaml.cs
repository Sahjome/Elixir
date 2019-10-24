using Elixer.Models;
using Elixer.ViewModels;
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
    public partial class Announcement : ContentPage
    {
        AnnouncementViewModel viewModel;
        public Announcement()
        {
            InitializeComponent();
            BindingContext = viewModel = new AnnouncementViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Models.Announcement;
            if (item == null)
                return;

            await Navigation.PushAsync(new AnnouncementDetail(new AnnounncementDetailViewModel(item)));

            // Manually deselect item.
            listView.SelectedItem = null;
        }

        //async void AddItem_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.ann.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}