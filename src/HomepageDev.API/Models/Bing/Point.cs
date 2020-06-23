using Newtonsoft.Json;
using System.Collections.Generic;

namespace HomepageDev.API.Models.Bing
{
    public class Point
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("coordinates")]
        public IList<double> Coordinates { get; set; }
    }
}
