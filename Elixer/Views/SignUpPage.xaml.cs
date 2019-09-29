using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elixer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
       
        public SignUpPage()
        {
            InitializeComponent();
            form.IsVisible = false;
            formtitle.IsVisible = false;
            
        }
        
        void Required()
        {
            List<Entry> entries = new List<Entry>
            {
                fname, sname, uname, email, pass, phone,
               
            };
            foreach (var dat in entries)
            {
                if (string.IsNullOrWhiteSpace(dat.Text))
                {
                    //dat.Placeholder.Insert(-1, "*");
                    dat.Placeholder += "*";
                    dat.PlaceholderColor = Color.Red;
                }
            }
                
        }

        Dictionary<string, Entry> clope = new Dictionary<string, Entry>();

        //void Tery(Dictionary<string, object> data)
        //{
        //    clope.Add(fname.Text, fname);
        //    clope.Add(sname.Text, sname);
        //    foreach(Entry dat in clope)
        //    {
        //        if (string.IsNullOrWhiteSpace(dat.t))
        //        {
        //            entr.PlaceholderColor = Color.Red;
        //        }
        //    }
        //}
        
        void Mover()
        {
            fname.Focus();
            fname.Completed += (s, e) => sname.Focus();
            sname.Completed += (s, e) => oname.Focus();
            oname.Completed += (s, e) => uname.Focus();
            uname.Completed += (s, e) => email.Focus();
            email.Completed += (s, e) => phone.Focus();
            phone.Completed += (s, e) => pass.Focus();
            pass.Completed += (s, e) => conpass.Focus();
            conpass.Completed += (s, e) => haddy.Focus();
            haddy.Completed += (s, e) => dept.Focus();
            dept.Completed += (s, e) => raddy.Focus();
            raddy.Completed += (s, e) => occupation.Focus();
            occupation.Completed += (s, e) => dob.Focus();
            dob.DateSelected += (s, e) => grad.Focus();
            grad.DateSelected += (s, e) => Submit_Clicked(s, e);
        }

        public bool Vericheck(string a, string b)
        {
            string.Compare(a, b);
            return true;
        }

        void Mem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int sel = picker.SelectedIndex;
            //form.IsVisible = true;
            if (sel == 0)
            {
                Mover();
                //member = "Alumnus";
                form.IsVisible = true;
                formtitle.IsVisible = true;
                intro.IsVisible = false;
                student.IsVisible = false;
                alumnus.IsVisible = true;
                gradyr.IsVisible = true;
                typefirst.IsVisible = false;
                memtype.SelectedIndex = sel;
            }
            else
            {
                Mover();
                //member = "Student";
                form.IsVisible = true;
                formtitle.IsVisible = true;
                intro.IsVisible = false;
                typefirst.IsVisible = false;
                student.IsVisible = true;
                alumnus.IsVisible = false;
                gradyr.IsVisible = false;
                memtype.SelectedIndex = sel;
            }

            //return member;

        }

        
        public async void Submit_Clicked(object sender, EventArgs e)
        {

            //check entry
            if (string.IsNullOrWhiteSpace(fname.Text) || string.IsNullOrWhiteSpace(sname.Text) || 
                string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(phone.Text) || 
                string.IsNullOrWhiteSpace(pass.Text) || string.IsNullOrWhiteSpace(uname.Text))
            {
                await DisplayAlert("Error", "Please make sure all required fields are filled properly ", "OK");
                Required();
                //Tery(fname);   
            }
            else
            {
                var coin = Vericheck(pass.Text, conpass.Text);
                if(coin == true)
                {
                    //member = memtype.SelectedItem.ToString();//for member type
                    //verify that all the credentials are not in db and insert thru api
                    await DisplayAlert("Success", "Welcome " + fname.Text + " " + oname.Text + " " + sname.Text, "OK");
                    await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
                }
                else
                {
                    //comp.IsVisible = true;
                }
            }
        }
        public async void Clickred()
        {
            await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
        }

        public ICommand ClickCommand => new Command(async () => Clickred());
    }
}