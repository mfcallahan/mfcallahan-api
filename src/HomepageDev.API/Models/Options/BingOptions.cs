using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.API.Models.Options
{
    [ExcludeFromCodeCoverage]
    public class BingOptions
    {
        public string ApiKey { get; set; }
        public string ApiRootUrl { get; set; }
        public string GeocodeSingleAddressEndpoint { get; set; }
        public int MaxResults { get; set; }
        public int IncludeNeighborhood { get; set; }
    }
}
