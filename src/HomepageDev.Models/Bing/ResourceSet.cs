using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.Models.Bing
{
    [ExcludeFromCodeCoverage]
    public class ResourceSet
    {
        [JsonProperty("estimatedTotal")]
        public int EstimatedTotal { get; set; }
        [JsonProperty("resources")]
        public IList<Resource> Resources { get; set; }
    }

}
