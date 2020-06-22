using GreenPointsMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenPointsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.backgroundColor;
            //BackgroundImageSource = "background.jpg";
            Lb1_Username.TextColor = Constants.MainTextColor;
            Lb1_Password.TextColor = Constants.MainTextColor;
            //Entry_Username.TextColor = Constants.MainTextColor;
            //Entry_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconheight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();

            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);

            if(user.CheckInformation())
            {
                DisplayAlert("Login", "Login Success", "OK");
            }
            else
            {
                DisplayAlert("Login", "Login Not correct, empty username or password", "OK");
            }
        }
    }
}