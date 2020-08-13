using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.Models.Bing
{
    [ExcludeFromCodeCoverage]
    public class GeocodePoint
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("coordinates")]
        public IList<double> Coordinates { get; set; }
        [JsonProperty("calculationMethod")]
        public string CalculationMethod { get; set; }
        [JsonProperty("usageTypes")]
        public IList<string> UsageTypes { get; set; }
    }
}
