using Elixer.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elixer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailerView : ContentPage
    {
        MediaTemplate template;
        GroupsViewModel viewModel;
        public DetailerView()
        {
            InitializeComponent();
            BindingContext = viewModel = new GroupsViewModel();
            //var media = viewModel.GetAnnouncement();
            //foreach(var med in media)
            //{
            //    listView.Children.Add(template);
            //}
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Models.Media;
            if (item == null)
                return;

            await Navigation.PushModalAsync(new MediaDetail(new MediaDetailViewModel(item)));

            // Manually deselect item.
            //listView.SelectedItem = null;
        }

        //private void Loader()
        //{
        //    object med = (viewModel.LoadItemsCommand.Execute();
        //    listView.Children.Add
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.media.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}