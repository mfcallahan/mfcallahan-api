using System.Collections.Generic;

namespace HomepageDev.Data.POCOs
{
    public class MyGmrsRepeatersResponse
    {
        public bool authenticated { get; set; }
        public string RequestStatus { get; set; }
        public List<MyGmrsRepeater> repeaters { get; set; }
    }

    public class MyGmrsRepeater
    {
        public string id { get; set; }
        public string name { get; set; }
        public string frequencyOut { get; set; }
        public string toneIn { get; set; }
        public Location location { get; set; }
        public string radius { get; set; }
        public string haat { get; set; }
        public string status { get; set; }
    }

    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}