using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.ModelView;
using Xamarin.Forms;

namespace WeatherApp.Model
{
    public class UserLocation { 
        public UserLocation(){}

        public UserLocation(string name)
        {
            this.Name = name;
            this.ID = "050-" + DateTime.Now.Year + "-" + Name.PadLeft(4, '0');
           
        }

        public string ID { get; set; }
        public string Name { get; set; }

     

    }
}
