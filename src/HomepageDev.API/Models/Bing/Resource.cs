using Newtonsoft.Json;
using System.Collections.Generic;

namespace HomepageDev.API.Models.Bing
{
    public class Resource
    {
        [JsonProperty("__type")]
        public string Type { get; set; }
        [JsonProperty("bbox")]
        public IList<double> Bbox { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("point")]
        public Point Point { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }
        [JsonProperty("confidence")]
        public string Confidence { get; set; }
        [JsonProperty("entityType")]
        public string EntityType { get; set; }
        [JsonProperty("geocodePoints")]
        public IList<GeocodePoint> GeocodePoints { get; set; }
        [JsonProperty("matchCodes")]
        public IList<string> MatchCodes { get; set; }
    }
}
