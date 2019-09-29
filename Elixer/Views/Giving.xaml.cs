using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elixer.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elixer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Giving : ContentPage
    {
        public Giving()
        {
            Contents give = new Contents();
            give.talk = "\"Honor the Lord with your substance and with the first fruits of your increase;" +
                " so your barns will be filled with plenty, and your vats will overflow with new wine.\" – Proverbs 3:9; ";
            give.offering = "Offerings and Tithes:\nBank: Ecobank\nAccount Name: Christ Love Fellowship\nAccount Number: 4152002779";
            give.tithe = "Building Seeds:\nBank: GT Bank\nAccount Name: Christ Love Fellowship\nAccount Number: 0037295634";
            InitializeComponent();
            Title = "Giving";
            
            BindingContext = give;
            
        }
       
    }

    
}