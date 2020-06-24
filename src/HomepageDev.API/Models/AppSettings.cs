using HomepageDev.API.Interfaces;

namespace HomepageDev.API.Models
{
    public class AppSettings : IAppSettings
    {
        public string BingApiRootUrl { get; set; }
        public string BingApiKey { get; set; }
        public string BingGeocodeSingleAddressEndpoint { get; set; }
    }
}
