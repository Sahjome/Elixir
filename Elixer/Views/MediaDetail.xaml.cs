using Elixer.ViewModels;
using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b

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
<<<<<<< HEAD


=======
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
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
<<<<<<< HEAD

       
=======
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
    }
}