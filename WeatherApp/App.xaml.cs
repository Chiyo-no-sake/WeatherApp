using System;
using WeatherApp.DB;
using WeatherApp.GeoLocation;
using WeatherApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    public partial class App : Application
    {
        private static LocationsDB database;

        public static LocationsDB Database
        {
            get
            {
                if (database == null)
                    database = new LocationsDB();
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            GeolocationController.StartListener();

            var nav = new NavigationPage(new LocationsListPage())
            {
                BarBackgroundColor = Color.LightGreen,
                BarTextColor = Color.White
            };

            MainPage = nav;
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
