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
    public partial class Media : ContentPage
    {
        MediaViewModel viewModel;
        public Media()
        {
            InitializeComponent();
            BindingContext = viewModel = new MediaViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Models.Media;
            if (item == null)
                return;

            await Navigation.PushAsync(new MediaDetail(new MediaDetailViewModel(item)));

            // Manually deselect item.
            listView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.media.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}