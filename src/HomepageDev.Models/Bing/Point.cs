using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.Models.Bing
{
    [ExcludeFromCodeCoverage]
    public class Point
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("coordinates")]
        public IList<double> Coordinates { get; set; }
    }
}
