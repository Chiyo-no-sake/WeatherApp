using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Model;
using Xamarin.Forms;

namespace WeatherApp.ModelView
{
    public class LocationDetailViewModel : BaseViewModel
    {
        UserLocation _userLocation;

        public UserLocation UserLocation
        {
            get { return _userLocation; }
            set
            {
                _userLocation = value;
                OnPropertyChanged();
            }
        }

        public LocationDetailViewModel(UserLocation userLocation)
        {
            UserLocation = userLocation;
        }

        private double _maximumTemperature = 0.03;
        public double MaximumTemperature
        {
            get { return _maximumTemperature; }
            set
            {
                if (_maximumTemperature != value)
                {
                    _maximumTemperature = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _minimumTemperature = 0.01;
        public double MinimumTemperature
        {
            get { return _minimumTemperature; }
            set
            {
                if (_minimumTemperature != value)
                {
                    _minimumTemperature = value;
                    OnPropertyChanged();
                }
            }
        }



        private double _currentTemperature = 0.02;
        public double CurrentTemperature
        {
            get { return _currentTemperature; }
            set
            {
                if (_currentTemperature != value)
                {
                    _currentTemperature = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _weatherIcon;
        public string WeatherIcon
        {
            get { return _weatherIcon; }
            set
            {
                if (_weatherIcon != value)
                {
                    _weatherIcon = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
