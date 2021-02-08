using System;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using GreenPointsMobile.Testing;

namespace GreenPointsMobile.Views
{
    public partial class MainPage : ContentPage
    {
        Constants.Constants constant = new Constants.Constants();
        Secrets secrets = new Secrets();
        public MainPage()
        {
            InitializeComponent();
        }

        async void SignInProcedure(System.Object sender, System.EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(secrets.APIKEY));
            try
            {
                /*UserEmail.Text = RegisteredEmail.Length > 0 ? UserEmail.Text = RegisteredEmail : UserEmail.Text = UserEmail.Text;*/
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserEmail.Text, UserPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                await Navigation.PushAsync(new DashboardPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid email or password", "OK");
            }
        }

        async void ChangeRegister(System.Object sender, System.EventArgs e)
        {
            constant.Registered = true;

            if (constant.Registered)
            {
                Btn_Signin.IsVisible = false;
                Btn_Register.IsVisible = true;
                changeRegister.IsVisible = false;
                changeLogin.IsVisible = true;
            }
            await Navigation.PushAsync(new DashboardPage());
        }

        void ChangeLogin(System.Object sender, System.EventArgs e)
        {
            constant.Registered = false;

            if (!constant.Registered)
            {
                Btn_Signin.IsVisible = true;
                Btn_Register.IsVisible = false;
                changeRegister.IsVisible = true;
                changeLogin.IsVisible = false;
            }
        }

        async void RegisterButton(System.Object sender, System.EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(secrets.APIKEY));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserEmail.Text, UserPassword.Text);
                string gettoken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Alert", "Registered, Please Sign in!", "OK");
                await Navigation.PushAsync(new DashboardPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

    }
}