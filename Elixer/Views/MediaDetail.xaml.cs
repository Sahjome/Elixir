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
    public partial class MediaDetail : ContentPage
    {
        MediaDetailViewModel viewModel;
        Models.Media media;
        public MediaDetail(MediaDetailViewModel viewModel)
        {
            InitializeComponent();
            GetType(media.type);
            BindingContext = this.BindingContext = viewModel;
        }
        private void GetType(string type)
        {
            if (type == "Text")
            {
                textView.IsVisible = true;
                viewModel.GetTextFromText(media.file);
            }
            else if (type == "PDF")
            {
                textView.IsVisible = true;
                viewModel.GetTextFromPDF(media.file);
            }
            //else if (type == "Document")
            //{
            //    textView.IsVisible = true;
            //    GetTextFromWord(media.file);
            //}
            else if (type == "Diet")
            {
                textView.IsVisible = true;
                viewModel.GetTextFromText(media.file);
            }
            else if (type == "Audio")
            {
                player.IsVisible = true;
                viewModel.GetTextFromText(media.file);
            }
            else if (type == "Video")
            {
                player.IsVisible = true;
                viewModel.GetTextFromText(media.file);
            }
        }
    }
}