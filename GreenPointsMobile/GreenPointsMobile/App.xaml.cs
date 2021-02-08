using GreenPointsMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenPointsMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.DashboardPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
