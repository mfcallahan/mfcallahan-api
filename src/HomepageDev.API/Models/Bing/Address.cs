using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.API.Models.Bing
{
    [ExcludeFromCodeCoverage]
    public class Address
    {
        [JsonProperty("countryRegion")]
        public string CountryRegion { get; set; }
        [JsonProperty("formattedAddress")]
        public string FormattedAddress { get; set; }
        [JsonProperty("countryRegionIso2")]
        public string CountryRegionIso2 { get; set; }
    }
}
