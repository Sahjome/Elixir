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
    public partial class Groups : TabbedPage
    {
        public Groups()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("Groups"))
            {
                var menuName = Application.Current.Properties["Groups"].ToString();
                if (menuName == "Life Group")
                {
                    this.CurrentPage = Children[1];
                }
            }
        }
    }
}