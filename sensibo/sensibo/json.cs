using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensibo.sensibo
{
    class json
    {
    }
    public class Room
    {
        public string name { get; set; }
        public string icon { get; set; }
    }

    public class Pod
    {
        public string id { get; set; }
        public Room room { get; set; }

    }

    public class pods
    {
        public string status { get; set; }
        public List<Pod> result { get; set; }
    }




    public class AcState
    {
        public bool on { get; set; }
        public int targetTemperature { get; set; }
        public string temperatureUnit { get; set; }
        public string mode { get; set; }
        public string fanLevel { get; set; }
    }

    [Newtonsoft.Json.JsonObject(Title = "AcState")]
    public class JsonAcState
    {
        public SetAcState acState { get; set; }
    }
    public class SetAcState
    {
        public bool on { get; set; }
        public int targetTemperature { get; set; }
        public string mode { get; set; }
        public string fanLevel { get; set; }
    }

    public class Result
    {
        public string status { get; set; }
        public AcState acState { get; set; }
    }

    public class acstatus
    {
        public string status { get; set; }
        public bool moreResults { get; set; }
        public List<Result> result { get; set; }
    }


    public class Time
    {
        public int secondsAgo { get; set; }
        public string time { get; set; }
    }

    public class measurmentvalues
    {
        public Time time { get; set; }
        public double temperature { get; set; }
        public double humidity { get; set; }
    }

    public class measurements
    {
        public string status { get; set; }
        public List<measurmentvalues> result { get; set; }
    }




    public class RequestID
    {
        public string id { get; set; }
    }

    public class setResult
    {
        public string status { get; set; }
        public RequestID result { get; set; }
    }

}
