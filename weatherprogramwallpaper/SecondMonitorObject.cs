namespace weatherprogramwallpaper;

public class SecondMonitorObject
{
     public class Clockonoff
    {
        public int order { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public bool value { get; set; }
    }

    public class Foggycloudyaironoff
    {
        public int order { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public bool value { get; set; }
    }

    public class Heavenlylightsonoff
    {
        public int order { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public bool value { get; set; }
    }

    public class Leavesonoff
    {
        public int order { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public bool value { get; set; }
    }

    public class Moreemberlightsonoff
    {
        public int order { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public bool value { get; set; }
    }

    public class Rainonoff
    {
        public int order { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public bool value { get; set; }
    }

    public class Schemecolor
    {
        public int order { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Soundinteractivefirefliesonoff
    {
        public int order { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public bool value { get; set; }
    }

    public class Properties
    {
        public Clockonoff clockonoff { get; set; }
        public Foggycloudyaironoff foggycloudyaironoff { get; set; }
        public Heavenlylightsonoff heavenlylightsonoff { get; set; }
        public Leavesonoff leavesonoff { get; set; }
        public Moreemberlightsonoff moreemberlightsonoff { get; set; }
        public Rainonoff rainonoff { get; set; }
        public Schemecolor schemecolor { get; set; }
        public Soundinteractivefirefliesonoff soundinteractivefirefliesonoff { get; set; }
    }

    public class General
    {
        public Properties properties { get; set; }
        public bool supportsaudioprocessing { get; set; }
    }

    public class Root
    {
        public bool approved { get; set; }
        public string contentrating { get; set; }
        public string description { get; set; }
        public string file { get; set; }
        public General general { get; set; }
        public string preview { get; set; }
        public List<string> tags { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public int version { get; set; }
        public string visibility { get; set; }
        public string workshopid { get; set; }
        public string workshopurl { get; set; }
    }
}