using System;
using System.Windows.Input;
using Elixer.Models;
using Xamarin.Forms;

namespace Elixer.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            about = "Christ Love Fellowship was founded on Obafemi Awolowo University, Ile-Ife, in 1985" +
                " by Kemi Ndieli and Toyin Okutinyang, with Rev. Inyang Okutinyang as the first Senior Pastor. " +
                "Currently under the leadership of Pastor ‘Tola Oladiji, the tenth Senior Pastor, we are still " +
                "fulfilling the mandate God gave to us over three decades ago. \vThis is not just a church, we are " +
                "a family of love where you can grow in your relationship with God and build great friendships " +
                "with other people on your journey to fulfilling God’s purpose for your life. \vOur Vision is " +
                "found in Ephesians 4:12 – “For the perfecting of the saints for the work of the ministry, for" +
                " the edifying of the body of Christ”, and our Mission Statement is “To train up believers in " +
                "Spirit, Word and Practice, so that they may in turn go out and impart their world.”";
            
            //OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

<<<<<<< HEAD
        //public ICommand clickCommand = new Command(() => return  { get; }
=======
        //public ICommand OpenWebCommand { get; }
>>>>>>> a8d0f6e84b26199dd65d5ca307869bd631eaab3b
    }
}