using System.Collections;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using weatherprogramwallpaper.JsonHandling;
using JsonReader = weatherprogramwallpaper.JsonHandling.JsonReader;

namespace weatherprogramwallpaper;

public class ChangeWallpaper
{
    private static string jsonSettingsPath = "D:/SteamLibrary/steamapps/workshop/content/431960/2276095638/project.json";
    private static ArrayList commands = new ArrayList();

    public static async Task Main(string[] args)
    {
       
        await JsonWriterWeather.GetJsonDataAndWrite();
        WeatherObject weatherObject = JsonReader.createWeatherObject();
        makeChangesToSecondMonitor(weatherObject, commands);

        string commandTextNavD = "D:";
        string commandTextNavWPEngine = "cd D:/SteamLibrary/steamapps/common/wallpaper_engine";
        string commandApplyChanges = "wallpaper64.exe -control applyProperties";
        runCommands(commands);
        

    }

    private static async Task makeChangesToSecondMonitor(WeatherObject weatherObject, ArrayList commands)
    {
       
        string jsonSettings = File.ReadAllText(jsonSettingsPath);
        dynamic jsonObj = JsonConvert.DeserializeObject(jsonSettings);

        if (IsRaining(weatherObject.Humidity))
        {
            jsonObj["general"]["properties"]["rainonoff"]["value"] = "true";
            addCommandToArrayList("rainonoff", true);
            

        }
        else
        {
            jsonObj["general"]["properties"]["rainonoff"]["value"] = "false";
            addCommandToArrayList("rainonoff", false);

        }

        if (IsSunset(weatherObject.Sunrise, weatherObject.Sunset))
        {
            jsonObj["general"]["properties"]["heavenlylightsonoff"]["value"] = "true";
            jsonObj["general"]["properties"]["moreemberlightsonoff"]["value"] = "true";
            jsonObj["general"]["properties"]["soundinteractivefirefliesonoff"]["value"] = "true";
            jsonObj["general"]["properties"]["clockonoff"]["value"] = "true";
            addCommandToArrayList("clockonoff", true);
            addCommandToArrayList("heavenlylightsonoff", true);
            addCommandToArrayList("moremeberlightsonoff", true);
            addCommandToArrayList("soundinteractivefirefliesonoff", true);
            
        }
        else
        { 
            jsonObj["general"]["properties"]["heavenlylightsonoff"]["value"] = "false";
            jsonObj["general"]["properties"]["moreemberlightsonoff"]["value"] = "false";
            jsonObj["general"]["properties"]["soundinteractivefirefliesonoff"]["value"] = "false";
            addCommandToArrayList("clockonoff", false);
            addCommandToArrayList("heavenlylightsonoff", false);
            addCommandToArrayList("moremeberlightsonoff", false);
            addCommandToArrayList("soundinteractivefirefliesonoff", false);
        }

        if (IsCloudy(weatherObject.Clouds))
        {
            jsonObj["general"]["properties"]["foggycloudyaironoff"]["value"] = "true";
            addCommandToArrayList("foggycloudyaironoff", true);

            
        }
        else
        {
            jsonObj["general"]["properties"]["foggycloudyaironoff"]["value"] = "false";
            addCommandToArrayList("foggycloudyaironoff", false);
        }
        
        if (IsWindy(weatherObject.Windspeed))
        { 
            jsonObj["general"]["properties"]["leavesonoff"]["value"] = "true";   
            addCommandToArrayList("leavesonoff", true);
        }
        else
        {
            jsonObj["general"]["properties"]["leavesonoff"]["value"] = "false";   
            addCommandToArrayList("leavesonoff", false);

        }

        await using (StreamWriter file = File.CreateText(jsonSettingsPath))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, jsonObj);
        }
    }

    private static bool IsRaining(int humidity)
    {
        if (humidity >= 95)
        {
            return true;
        }
        return false;
    }

   
    private static bool IsSunset(DateTime sunrise, DateTime sunset)
    {
        int result = DateTime.Compare(DateTime.Now, sunrise);
        if (result > 0)
        {
            return true;
           
        }
        return false;

    }
    

    private static bool IsWindy(double windspeed)
    {
        if (windspeed >= 7.5)
        {
            return true;
        }
        return false;
    }
    private static bool IsCloudy(double clouds)
    {
        if (clouds > 75)
        {
            return true;
        }
        return false;
    }

    public static async Task runCommands(ArrayList commands)
    {
        //Build .BAT file
        string workingDirectory = Environment.CurrentDirectory;
        string path = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        string batFileName = path + @"\" + Guid.NewGuid() + ".bat";

       await using (StreamWriter batFile = new StreamWriter(batFileName))
        {
            batFile.WriteLine("D:");
            batFile.WriteLine("cd D:/SteamLibrary/steamapps/common/wallpaper_engine");
            string finalCommand = "";
            foreach (var command in commands)
            {
                finalCommand = "wallpaper64.exe -control applyProperties -properties RAW~({";
                finalCommand += command;
                finalCommand += "})~END";
                batFile.WriteLine(finalCommand);
                Console.WriteLine(command);
            }
            batFile.Close();
        }
       
       ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + batFileName);   
       processInfo.CreateNoWindow = true;
       processInfo.UseShellExecute = false;
       Process process = Process.Start(processInfo);
       process.WaitForExit();
       process.Close();
       File.Delete(batFileName);
    }

    public static void addCommandToArrayList(string command, bool value)
    {
        Console.WriteLine("Handling " + command);
        string formattedCommand = "";
        //string dblQuotes = "\"\"";
        formattedCommand += "\"" + command + "\"" + ":" + value.ToString().ToLower();
        commands.Add(formattedCommand);


    }
}


