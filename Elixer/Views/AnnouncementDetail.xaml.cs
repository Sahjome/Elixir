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
    public partial class AnnouncementDetail : ContentPage
    {
        AnnounncementDetailViewModel ViewModel;
        public AnnouncementDetail(AnnounncementDetailViewModel ViewModel)
        {
            InitializeComponent();
            BindingContext = this.BindingContext = ViewModel;
        }
    }
}