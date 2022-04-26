using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using weatherprogramwallpaper.WebCalls;
namespace weatherprogramwallpaper.JsonHandling;

public class JsonWriterWeather
{
    public static async Task GetJsonDataAndWrite()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        await using (StreamWriter file = File.CreateText(path + "/weatherInfo.json"))
        {
            file.Close();
            var data = await GetWeatherFromOpenWeatherMap.GetWeatherResponse();
            await File.WriteAllTextAsync(@path + "/weatherInfo.json",
                GetWeatherFromOpenWeatherMap.GetWeatherResponse().Result.ToString());


        }



    }
}