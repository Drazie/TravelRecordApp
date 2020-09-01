using System;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TravelRecordApp.Model;

namespace TravelRecordApp
{
    public partial class App : Application
    {
        

        public static string DatabaseLocation = string.Empty;

        public static MobileServiceClient client = new MobileServiceClient("https://travelrecord1.azurewebsites.net");

        public static Users user = new Users();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            DatabaseLocation = databaseLocation;

            MainPage = new NavigationPage(new MainPage());

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
