using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace weatherprogramwallpaper.JsonHandling;
using weatherprogramwallpaper;

public class JsonReader
{

    public static WeatherObject createWeatherObject()
    {
        //Remove on build.
        //Get directory of app resources json, which has API key and Location
        WeatherObject weatherObject = new WeatherObject();
        string workingDirectory = Environment.CurrentDirectory;
        string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        ;
        string pathTarget =  path + "/weatherInfo.json";
        string jsonWeather = System.IO.File.ReadAllText(pathTarget);



        dynamic weatherData = JsonConvert.DeserializeObject(jsonWeather) ?? throw new InvalidOperationException();
        

        weatherObject.LocationOfSearch = weatherData.name;
        weatherObject.DateCaptured = DateTime.Now;
        weatherObject.Sunrise = getDateTimeFromUnix(weatherData.sys.sunrise);
        weatherObject.Sunset = getDateTimeFromUnix(weatherData.sys.sunset);
        weatherObject.Windspeed = weatherData.wind.speed;
        weatherObject.Clouds = weatherData.clouds.all;
        weatherObject.Humidity = weatherData.main.humidity;
        weatherObject.Visibility = weatherData.visibility;

        return weatherObject;
    }

    private static DateTime getDateTimeFromUnix(dynamic datetimeunix)
    {
        var formatted = new DateTime(1970, 1, 1);
        double datetime = datetimeunix;
        return formatted.AddSeconds(datetime);
    }
}