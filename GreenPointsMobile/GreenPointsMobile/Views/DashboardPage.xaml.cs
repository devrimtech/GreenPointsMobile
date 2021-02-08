using System;
using System.Diagnostics;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenPointsMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        static readonly HttpClient client = new HttpClient();
        public DashboardPage()
        {
            InitializeComponent();
            GetData();
        }

        private async void GetData()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:5001/api/GreenPointItems/1/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.ReadLine();
                Debug.WriteLine(responseBody);
                Console.WriteLine(responseBody);
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}