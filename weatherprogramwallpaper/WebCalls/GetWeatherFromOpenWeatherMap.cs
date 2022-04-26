using System.Diagnostics;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace weatherprogramwallpaper.WebCalls;

public class GetWeatherFromOpenWeatherMap
{
    static readonly HttpClient client = new HttpClient();
    

    

    private static string FormulateUrl()
    {
        //Remove on build.
        //Get directory of app resources json, which has API key and Location
        string workingDirectory = Environment.CurrentDirectory;
        string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        ;
        string pathTarget = path + "/appResources.json";
        string jsonSettings = System.IO.File.ReadAllText(pathTarget);

        try
        {
            //Build the URL using API and Location from appResources.json
            dynamic settings = JsonConvert.DeserializeObject(jsonSettings) ?? throw new InvalidOperationException();
            string urlPath = "https://api.openweathermap.org/data/2.5/weather?q=" + settings.Path.Location + "&appid=" + settings.Path.APIKey;
            return urlPath;
        }
        catch (InvalidOperationException ex)
        {
            Debug.WriteLine(ex.StackTrace);
        }

        return "No response";
    }

    public static async Task<object> GetWeatherResponse()
    {
        
        try
        {
            HttpResponseMessage response = await client.GetAsync(FormulateUrl());
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JsonSerializer serializer = new JsonSerializer();
            Console.WriteLine("Response " + responseBody);
            return responseBody;
        }
        catch(HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");	
            Console.WriteLine("Message :{0} ",e.Message);
        }

        return "No response.";
    }
}