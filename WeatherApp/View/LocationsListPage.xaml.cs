using System;
using WeatherApp.Model;
using WeatherApp.ModelView;
using Xamarin.Forms;

namespace WeatherApp.View
{
    public partial class LocationsListPage : ContentPage
    {
        private LocationsListViewModel locationsHolder;
        public LocationsListPage()
        {
            InitializeComponent();
            locationsHolder = new LocationsListViewModel();
            BindingContext = locationsHolder;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void OnItemAdded(object sender, EventArgs e)
        {
            promptAndAddItem();
        }

        async void promptAndAddItem()
        {
            string result = await DisplayPromptAsync("Insert new Location", "Insert Location Name:");
            locationsHolder.AddLocation(new UserLocation(result));
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is null)
                return;

            Navigation.PushAsync(new LocationDetailsPage()
            {
                BindingContext = e.SelectedItem as Model.UserLocation
            });
        }
    }
}