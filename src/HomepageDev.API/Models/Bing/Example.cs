using Newtonsoft.Json;
using System.Collections.Generic;

namespace HomepageDev.API.Models.Bing
{
    public class Example
    {
        [JsonProperty("authenticationResultCode")]
        public string AuthenticationResultCode { get; set; }
        [JsonProperty("brandLogoUri")]
        public string BrandLogoUri { get; set; }
        [JsonProperty("copyright")]
        public string Copyright { get; set; }
        [JsonProperty("resourceSets")]
        public IList<ResourceSet> ResourceSets { get; set; }
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("statusDescription")]
        public string StatusDescription { get; set; }
        [JsonProperty("traceId")]
        public string TraceId { get; set; }
    }
}
