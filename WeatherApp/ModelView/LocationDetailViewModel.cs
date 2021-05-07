using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

            _ = getWeatherAsync();
           
        }

        private async Task getWeatherAsync()
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?q="+ UserLocation.Name +"&appid=bda36c03a06ee5e92467b7ccb9ecbacc");

            string weatherCurrent = (string)JObject.Parse(content)["main"]["temp"];
            string weatherMax = (string)JObject.Parse(content)["main"]["temp_max"];
            string weatherMin = (string)JObject.Parse(content)["main"]["temp_min"];
            string weatherIcon = (string)JObject.Parse(content)["weather"][0]["icon"];

            CurrentTemperature = convertKelvinToC(Convert.ToDouble(weatherCurrent));
            MinimumTemperature = convertKelvinToC(Convert.ToDouble(weatherMin));
            MaximumTemperature = convertKelvinToC(Convert.ToDouble(weatherMax));
            WeatherIcon = weatherIcon;
           
        }

        private double convertKelvinToC(double k)
        {
            return k - 273.15;
        }

        private double _maximumTemperature = 0.00;
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

        private double _minimumTemperature = 0.00;
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



        private double _currentTemperature = 0.00;
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

                    ImageURL = "https://openweathermap.org/img/wn/"+ _weatherIcon + "@2x.png";
                    //OnPropertyChanged();
                }
            }
        }

        private string _imageURL = "https://openweathermap.org/img/wn/01d@2x.png";
        public string ImageURL
        {
            get { return _imageURL; }
            set
            {
                if (_imageURL != value)
                {
                    _imageURL = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
