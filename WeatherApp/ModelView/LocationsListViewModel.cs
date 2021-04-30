using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using WeatherApp.GeoLocation;
using WeatherApp.Model;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml.Diagnostics;

namespace WeatherApp.ModelView
{
    internal class LocationsListViewModel : BaseViewModel
    {
        private UserLocation currentLocation;
        private ObservableCollection<UserLocation> _entries;
        public ObservableCollection<UserLocation> Entries
        {
            get => _entries;
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }

        public LocationsListViewModel()
        {
            _entries = new ObservableCollection<UserLocation>();
            InitLocations();            
        }

        private void InitLocations()
        {
            // TODO ask for currentLocation and add as first item
            
           
            listenPositionChanges();

            App.Database.GetItemsAsync().Result.ForEach((UserLocation location) =>
            {
                _entries.Add(location);
            });
        }

        private void listenPositionChanges()
        {
            CrossGeolocator.Current.PositionChanged += async (object sender, PositionEventArgs e) =>
            {
                var placemarks = await Geocoding.GetPlacemarksAsync(e.Position.Latitude, e.Position.Longitude);
                UserLocation currentLocation = new UserLocation(placemarks.First().Locality);

                if (this.currentLocation == null)
                    _entries.Insert(0, currentLocation);
                else
                    _entries[0] = currentLocation;

                this.currentLocation = currentLocation;
            };
        }

        public bool isCurrentLocation(UserLocation userLoc)
        {
            return userLoc.ID.Equals(currentLocation.ID);
        }

        public void AddLocation(UserLocation userLoc)
        {
            App.Database.SaveItemAsync(userLoc);
            _entries.Add(userLoc);
        }
    }
}
