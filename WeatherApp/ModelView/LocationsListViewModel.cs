using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WeatherApp.Model;

namespace WeatherApp.ModelView
{
    internal class LocationsListViewModel : BaseViewModel
    {
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
            FillTestLocations(15);
        }

        private void FillTestLocations(int locationCount)
        {
            Entries = new ObservableCollection<UserLocation>();
            for (var i = 0; i < locationCount; i++)
            {
                Entries.Add(new UserLocation{ID=i, Name = "Location #" + i});
            }
        }
    }
}
