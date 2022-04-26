using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherprogramwallpaper

{
    public class WeatherObject
    {
        string locationOfSearch;
        DateTime dateCaptured;
        DateTime sunrise;
        DateTime sunset;
        double windspeed;
        double clouds;
        int humidity;
        int visibility;
        public string LocationOfSearch
        {
            get => locationOfSearch;
            set => locationOfSearch = value ?? throw new ArgumentNullException(nameof(value));
        }

        public DateTime DateCaptured
        {
            get => dateCaptured;
            set => dateCaptured = value;
        }

        public DateTime Sunrise
        {
            get => sunrise;
            set => sunrise = value;
        }

        public DateTime Sunset
        {
            get => sunset;
            set => sunset = value;
        }

        public double Windspeed
        {
            get => windspeed;
            set => windspeed = value;
        }

        public double Clouds
        {
            get => clouds;
            set => clouds = value;
        }

        public int Humidity
        {
            get => humidity;
            set => humidity = value;
        }

        public int Visibility
        {
            get => visibility;
            set => visibility = value;
        }

        

        public WeatherObject(string locationOfSearch, DateTime dateCaptured, DateTime sunrise, DateTime sunset, double windspeed, double clouds, int humidity, int visibility)
        {
            this.locationOfSearch = locationOfSearch;
            this.dateCaptured = dateCaptured;
            this.sunrise = sunrise;
            this.sunset = sunset;
            this.windspeed = windspeed;
            this.clouds = clouds;
            this.humidity = humidity;
            this.visibility = visibility;
        }

        public WeatherObject()
        {
            
        }
    }
}
