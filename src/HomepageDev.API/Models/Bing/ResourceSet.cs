using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HomepageDev.API.Models.Bing
{
    public class ResourceSet
    {
        [JsonProperty("estimatedTotal")]
        public int EstimatedTotal { get; set; }
        [JsonProperty("resources")]
        public IList<Resource> Resources { get; set; }
    }

}
