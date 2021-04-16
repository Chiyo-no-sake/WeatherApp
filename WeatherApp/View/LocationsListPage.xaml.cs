using System;
using WeatherApp.ModelView;
using Xamarin.Forms;

namespace WeatherApp.View
{
    public partial class LocationsListPage : ContentPage
    {
        public LocationsListPage()
        {
            InitializeComponent();
            BindingContext = new LocationsListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void OnItemAdded(object sender, EventArgs e)
        {
            DisplayAlert("Item Added", "An item was added to the list", "OK");
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